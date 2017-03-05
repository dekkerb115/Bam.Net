using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bam.Net.Server;
using Bam.Net.Logging;
using Bam.Net.ServiceProxy;
using System.IO;

namespace Bam.Net.Server.Tvg
{
    public abstract class SimpleServer<R> where R: IResponder
    {
        HttpServer _server;
        public SimpleServer(R responder, ILogger logger)
        {
            this.Responder = responder;
            this.Logger = logger;
            this.CreatedOrChangedHandler = (o, a) => { };
            this.RenamedHandler = (o, a) => { };
            this.HostPrefixes = new HostPrefix[] { new HostPrefix { Port = 8080, HostName = "localhost", Ssl = false } };
            this.MonitorDirectories = new string[] { Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) };
        }

        /// <summary>
        /// An array of hosts that this server will respond to
        /// </summary>
        public HostPrefix[] HostPrefixes { get; set; }
        
        /// <summary>
        /// The responder
        /// </summary>
        public IResponder Responder { get; set; }
        
        /// <summary>
        /// The logger
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// The FileSystemWatchers; one each for create, changed and renamed
        /// </summary>
        public List<FileSystemWatcher> FileSystemWatchers { get; protected set; }

        /// <summary>
        /// An array of directories to monitor for
        /// created, changed or renamed files
        /// </summary>
        public string[] MonitorDirectories { get; set; }

        /// <summary>
        /// The delegate that will be subscribed to the Create
        /// and Changed handler of the underlying FileSystemWatcher(s)
        /// </summary>
        public FileSystemEventHandler CreatedOrChangedHandler { get; set; }

        public virtual void Start()
        {
            Logger.RestartLoggingThread();
            this.FileSystemWatchers = new List<FileSystemWatcher>();
            this.WireEventHandlers();
            _server.Start(HostPrefixes);
        }
        public virtual void Stop()
        {
            Logger.StopLoggingThread();
            _server.Stop();
        }
        /// <summary>
        /// The delegate that will be subscribed to the renamed event of the underlying
        /// FileSystemWatcher(s)
        /// </summary>
        public RenamedEventHandler RenamedHandler { get; set; }

        /// <summary>
        /// Wire the event handlers
        /// </summary>
        protected void WireEventHandlers()
        {
            _server = new HttpServer(Logger ?? Log.Default);
            WireServerRequestHandler();
            WireResponderEventHandlers();
            MonitorDirectories.Each(directory =>
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                FileSystemWatchers.Add(directoryInfo.OnChange(CreatedOrChangedHandler));
                FileSystemWatchers.Add(directoryInfo.OnCreated(CreatedOrChangedHandler));
                FileSystemWatchers.Add(directoryInfo.OnRenamed(RenamedHandler));
            });
        }

        private void WireServerRequestHandler()
        {
            _server.ProcessRequest += (context) =>
            {
                Responder.Respond(new HttpContextWrapper(context));
            };
        }

        private void WireResponderEventHandlers()
        {
            Responder.Responded += (r, context) =>
            {
                FlushResponse(context);
                Logger.AddEntry("*** Responded ***\r\n{0}", LogEventType.Information, context.Request.PropertiesToString());
            };
            Responder.NotResponded += (r, context) =>
            {
                FlushResponse(context);
                Logger.AddEntry("*** Didn't Respond ***\r\n{0}", LogEventType.Warning, context.Request.PropertiesToString());
            };
        }
        private static void FlushResponse(IHttpContext context, int statusCode = 200)
        {
            context.Response.StatusCode = statusCode;
            context.Response.OutputStream.Flush();
            context.Response.OutputStream.Close();
        }
    }
}