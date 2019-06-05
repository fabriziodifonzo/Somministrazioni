using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Extras.DynamicProxy;
using Somministrazioni.Web.Controllers;
using Somministrazioni.Web.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac.Core;
using Somministrazioni.BusinessFacade;
using log4net;
using EntityFramework.DbContextScope.Interfaces;
using EntityFramework.DbContextScope;
using Sommnistrazioni.Data.DataService.Distinte;
using Somministrazioni.Business.Components.Browsers.Distinte;
using Somministrazioni.Business.Components.Browsers.Contratti;
using Sommnistrazioni.Data.DataService.Contratti;

namespace Somministrazioni.Web.App_Start
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new AmbientDBContextLocatorModule());            
            builder.RegisterModule(new AutofacLoggingModule());

            //Distinte
            builder.RegisterModule(new DistinteBrowserModule());
            builder.RegisterModule(new DistinteDataServiceModule());

            //Contratti
            builder.RegisterModule(new ContrattiBrowserModule());
            builder.RegisterModule(new ContrattiDataServiceModule());

            //Facade
            builder.RegisterModule(new BusinessFacadeModule());

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        class DistinteDataServiceModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<DistinteDataService>()
                    .AsImplementedInterfaces()
                    .InstancePerRequest();
            }
        }

        class DistinteBrowserModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<DistinteBrowser>()
                    .AsImplementedInterfaces()
                    .InstancePerRequest();
            }
        }

        class ContrattiBrowserModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<ContrattiBrowser>()
                    .AsImplementedInterfaces()
                    .InstancePerRequest();
            }
        }

        class ContrattiDataServiceModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<ContrattiDataService>()
                    .AsImplementedInterfaces()
                    .InstancePerRequest();
            }
        }

        class AmbientDBContextLocatorModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<AmbientDbContextLocator>()
                    .AsImplementedInterfaces()
                    .InstancePerRequest();
            }
        }

        class BusinessFacadeModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<BusinessFacade.BusinessFacade>()
                    .AsImplementedInterfaces()
                    .InstancePerRequest();
            }
        }

        class AutofacLoggingModule : Autofac.Module
        {
            protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
            {
                // Handle constructor parameters.
                registration.Preparing += OnComponentPreparing;
            }

            private static void OnComponentPreparing(object sender, PreparingEventArgs e)
            {
                e.Parameters = e.Parameters.Union(
                  new[]
                  {
                    new ResolvedParameter(
                        (p, i) => p.ParameterType == typeof(ILog),
                        (p, i) => LogManager.GetLogger(p.Member.DeclaringType)
                    )
                  });
            }
        }
    }
}