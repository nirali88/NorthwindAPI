using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac.Integration.WebApi;
using NorthWind.DATA.Infrastructure;
using NorthWind.DATA.Repositories;
using NorthWind.Service;
using System.Web.Http;
using NorthWindWebAPI.Mappings;

namespace NorthWindWebAPI
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutoFac();
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutoFac()
        {
            var builder = new ContainerBuilder();
            var configuration = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(ProductService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();

            // Set the WebApi dependency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = resolver;
        }
    }
}