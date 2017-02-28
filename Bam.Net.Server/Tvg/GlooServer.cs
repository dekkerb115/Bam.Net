using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bam.Net.Logging;
using System.IO;
using System.Reflection;
using Bam.Net.Configuration;
using System.Timers;
using Bam.Net.ServiceProxy.Secure;

namespace Bam.Net.Server.Tvg
{
    public class GlooServer: SimpleServer<GlooResponder>
    {
        public GlooServer(BamConf conf, ILogger logger)
            : base(new GlooResponder(conf, logger), logger)
        {
            Responder.Initialize();
            CreatedOrChangedHandler = (o, fsea) =>
            {
                ReloadServices(fsea);
            };
            RenamedHandler = (o, rea) =>
            {
                DirectoryInfo dir = GetDirectory(rea.FullPath);
                if (dir != null)
                {
                    TryReloadServices(dir);
                }
            };
            ServiceTypes = new HashSet<Type>();
        }

        public override void Start()
        {
            ServiceTypes.Clear();
            MonitorDirectories.Each(new { Server = this }, (ctx, dir) =>
            {
                ctx.Server.TryReloadServices(new DirectoryInfo(dir));
            });
            base.Start();
        }
        protected HashSet<Type> ServiceTypes { get; private set; }
        Timer reloadDelay;
        private void ReloadServices(FileSystemEventArgs fsea)
        {
            if(reloadDelay != null)
            {
                reloadDelay.Stop();
                reloadDelay.Dispose();
            }

            reloadDelay = new Timer(3000);
            reloadDelay.Elapsed += (o, args) =>
            {
                string path = fsea.FullPath;

                DirectoryInfo directory = GetDirectory(path);
                if (directory != null)
                {
                    TryReloadServices(directory);
                }
            };
            reloadDelay.AutoReset = false;
            reloadDelay.Enabled = true;            
        }

        private static DirectoryInfo GetDirectory(string path)
        {
            DirectoryInfo directory = null;
            if (File.Exists(path))
            {
                directory = new FileInfo(path).Directory;
            }
            else if (Directory.Exists(path))
            {
                directory = new DirectoryInfo(path);
            }
            return directory;
        }

        private void TryReloadServices(DirectoryInfo directory)
        {
            try
            {
                List<string> excludeNamespaces = new List<string>();
                excludeNamespaces.AddRange(DefaultConfiguration.GetAppSetting("ExcludeNamespaces").DelimitSplit(",", "|"));
                List<string> excludeClasses = new List<string>();
                excludeClasses.AddRange(DefaultConfiguration.GetAppSetting("ExcludeClasses").DelimitSplit(",", "|"));

                DefaultConfiguration
                .GetAppSetting("AssemblySearchPattern")
                .Or("*Services.dll,*Proxyables.dll,*Gloo.dll")
                .DelimitSplit(",", "|")
                .Each(new { Directory = directory, ExcludeNamespaces = excludeNamespaces, ExcludeClasses = excludeClasses },
                (ctx, searchPattern) =>
                {
                    FileInfo[] files = ctx.Directory.GetFiles(searchPattern, SearchOption.AllDirectories);
                    foreach(FileInfo file in files)
                    {
                        try
                        {
                            Assembly toLoad = Assembly.LoadFrom(file.FullName);
                            Type[] types = toLoad.GetTypes().Where(type => !ctx.ExcludeNamespaces.Contains(type.Namespace) &&
                                    !ctx.ExcludeClasses.Contains(type.Name) &&
                                    type.HasCustomAttributeOfType<ProxyAttribute>()).ToArray();
                            foreach(Type t in types)
                            {
                                ServiceTypes.Add(t);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddEntry("An exception occurred loading services from file {0}: {1}", LogEventType.Warning, ex, file.FullName, ex.Message);
                        }
                    }
                });
                RegisterProxiedClasses();
            }
            catch (Exception ex)
            {
                Logger.AddEntry("An exception occurred loading services: {0}", ex, ex.Message);
            }
        }

        private ServiceProxyResponder RegisterProxiedClasses()
        {
            GlooResponder gloo = (GlooResponder)Responder;
            ServiceProxyResponder responder = gloo.ServiceProxyResponder;
            ServiceTypes.Each(new { Logger = Logger, Responder = responder }, (ctx, serviceType) =>
            {                
                ctx.Responder.RemoveCommonService(serviceType);
                ctx.Responder.AddCommonService(serviceType, GetServiceRetriever(serviceType));
                ctx.Logger.AddEntry("Added service: {0}", serviceType.FullName);
            });
            IApiKeyResolver apiKeyResolver = (IApiKeyResolver)GetServiceRetriever(typeof(IApiKeyResolver))();
            responder.CommonSecureChannel.ApiKeyResolver = apiKeyResolver;
            responder.AppSecureChannels.Values.Each(sc => sc.ApiKeyResolver = apiKeyResolver);
            return responder;
        }

        static GlooRegistry _glooRegistry;
        private Func<object> GetServiceRetriever(Type type)
        {
            Type glooRegistryContainer = type.Assembly.GetTypes().Where(t => t.HasCustomAttributeOfType<GlooContainerAttribute>()).FirstOrDefault();
            if(glooRegistryContainer != null && _glooRegistry == null)
            {
                MethodInfo provider = glooRegistryContainer.GetMethods().Where(mi => mi.HasCustomAttributeOfType<GlooRegistryProviderAttribute>() || mi.Name.Equals("Get")).FirstOrDefault();
                _glooRegistry = (GlooRegistry)provider.Invoke(null, null);
            }
            return _glooRegistry == null ? (Func<object>)(() => type.Construct()): (Func<object>)(() => _glooRegistry.Get(type));
        }                
    }
}
