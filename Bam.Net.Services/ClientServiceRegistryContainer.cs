﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bam.Net.CoreServices;
using Bam.Net.Data.Repositories;
using Bam.Net.Incubation;
using Bam.Net.Logging;
using Bam.Net.Server;
using Bam.Net.Services.Catalog;
using Bam.Net.Services.Catalog.Data;

namespace Bam.Net.Services
{
    [ServiceRegistryContainer]
    public class ClientServiceRegistryContainer
    {
        public const string RegistryName = "ClientServiceRegistry";
        static ServiceRegistry _coreServiceRegistry;
        static object _coreIncubatorLock = new object();

        [ServiceRegistryLoader(RegistryName)]
        public static ServiceRegistry GetServiceRegistry()
        {
            return _coreIncubatorLock.DoubleCheckLock(ref _coreServiceRegistry, Create);
        }

        public static ServiceRegistry Create()
        {
            AppConf conf = new AppConf(BamConf.Load(ServiceConfig.ContentRoot), ServiceConfig.ProcessName.Or(RegistryName));
            DaoRepository repo = new DaoRepository(DataSettings.Current.GetSysDatabase(nameof(CatalogRepository)), Log.Default);
            repo.AddNamespace(typeof(CatalogItem));
            CatalogRepository catalogRepo = new CatalogRepository(repo, Log.Default);
            ServiceRegistry coreReg = ApplicationServiceRegistryContainer.Create();

            ServiceRegistry reg = (ServiceRegistry)(new ServiceRegistry())
                .For<ILogger>().Use(Log.Default)
                .For<AppConf>().Use(conf)
                .For<IRepository>().Use(catalogRepo)
                .For<DaoRepository>().Use(repo)
                .For<ICatalogService>().Use<CatalogService>()
                .For<CatalogService>().Use<CatalogService>();


            reg.CombineWith(coreReg);

            return reg;
        }
    }
}
