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
using Somministrazioni.Data.DataService.Contratti;
using Sommnistrazioni.Data.DataService.User;
using Somministrazioni.Business.Components.Managers.Users;
using System.Reflection;
using Somministrazioni.Web.Filter;

namespace Somministrazioni.Web.App_Start
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new AmbientDBContextLocatorModule());            
            builder.RegisterModule(new AutofacLoggingModule());
            builder.RegisterModule(new LogInterceptorModule());

            //Users
            builder.RegisterModule(new UsersManagerModule());
            builder.RegisterModule(new UsersDataServiceModule());

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

            builder.RegisterType<LogActionFilterAttribute>()
                    .WithParameter(new ResolvedParameter
                                    (
                                        (param, ctx) => param.ParameterType == typeof(ILog),
                                        (param, ctx) => LogManager.GetLogger(param.Member.DeclaringType)
                                     )
                                )
                    .AsActionFilterFor<Controller>()
                    .InstancePerRequest();

            builder.RegisterType<ExceptionHandlerFilterAttribute>()
                    .WithParameter(new ResolvedParameter
                                    (
                                        (param, ctx) => param.ParameterType == typeof(ILog),
                                        (param, ctx) => LogManager.GetLogger(param.Member.DeclaringType)
                                     )
                                )
                    .AsExceptionFilterFor<Controller>()
                    .InstancePerRequest();

            builder.RegisterType<AuthenticationLoginFilterAttribute>()
                    .WithParameter(new ResolvedParameter
                                    (
                                        (param, ctx) => param.ParameterType == typeof(ILog),
                                        (param, ctx) => LogManager.GetLogger(param.Member.DeclaringType)
                                     )
                                )
                    .AsAuthenticationFilterFor<LoginController>()
                    .InstancePerRequest();

            builder.RegisterType<AuthenticationFilterAttribute>()
                    .WithParameter(new ResolvedParameter
                                    (
                                        (param, ctx) => param.ParameterType == typeof(ILog),
                                        (param, ctx) => LogManager.GetLogger(param.Member.DeclaringType)
                                     )
                                )
                    .AsAuthenticationFilterFor<HomeController>()
                    .InstancePerRequest();            

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            var container = builder.Build();


            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        class LogInterceptorModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<LoggedMvcInterceptor>()
                    .WithParameter(new ResolvedParameter
                                    (
                                        (param, ctx) => param.ParameterType == typeof(ILog),
                                        (param, ctx) => LogManager.GetLogger(param.Member.DeclaringType)
                                     )
                                )
                    .InstancePerRequest();
            }
        }

        class UsersDataServiceModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                    builder.RegisterType<UsersDataService>()
                        .AsImplementedInterfaces()
                        .InstancePerRequest()
                        .EnableInterfaceInterceptors()
                        .InterceptedBy(typeof(LoggedMvcInterceptor));                    
            }            
        }

        class UsersManagerModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<UsersManager>()
                    .AsImplementedInterfaces()
                    .InstancePerRequest()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(LoggedMvcInterceptor));
            }
        }

        class DistinteDataServiceModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<DistinteDataService>()
                    .AsImplementedInterfaces()
                    .InstancePerRequest()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(LoggedMvcInterceptor));            
            }
        }

        class DistinteBrowserModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<DistinteBrowser>()
                    .AsImplementedInterfaces()
                    .InstancePerRequest()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(LoggedMvcInterceptor));

            }
        }

        class ContrattiBrowserModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<ContrattiBrowser>()
                    .AsImplementedInterfaces()
                    .InstancePerRequest()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(LoggedMvcInterceptor));

            }
        }

        class ContrattiDataServiceModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<ContrattiDataService>()
                    .AsImplementedInterfaces()
                    .InstancePerRequest()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(LoggedMvcInterceptor));

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
                    .InstancePerRequest()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(LoggedMvcInterceptor));                
            }
        }

        class AutofacLoggingModule : Autofac.Module
        {
            protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
            {
                // Handle constructor parameters.
                registration.Preparing += OnComponentPreparing;

                // Handle properties.
                registration.Activated += (sender, e) => InjectLoggerProperties(e.Instance);
            }

            private static void OnComponentPreparing(object sender, PreparingEventArgs e)
            {
                e.Parameters = e.Parameters.Union(
                  new[]
                  {
                    new ResolvedParameter(
                        (param, ctx) => param.ParameterType == typeof(ILog),
                        (param, ctx) => LogManager.GetLogger(param.Member.DeclaringType)
                    )
                  });
            }

            private static void InjectLoggerProperties(object instance)
            {
                var instanceType = instance.GetType();

                // Get all the injectable properties to set.
                // If you wanted to ensure the properties were only UNSET properties,
                // here's where you'd do it.
                var properties = instanceType
                  .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                  .Where(p => p.PropertyType == typeof(ILog) && p.CanWrite && p.GetIndexParameters().Length == 0);

                // Set the properties located.
                foreach (var propToSet in properties)
                {
                    propToSet.SetValue(instance, LogManager.GetLogger(instanceType), null);
                }
            }
        }
    }
}