using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using VIS360.Common.Services;
using VIS360.Controllers;
using VIS360.Core.Interfaces;
using VIS360.Infrastructure;


namespace VIS360.App_Start
{
    public class AutofacInitializer
    {
        public static void Initialize(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            //Context
            builder.RegisterType<Context>().As<Context>().InstancePerRequest();

            //Services
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();

            //Controllers
            builder.RegisterType<UserController>().InstancePerRequest();
            builder.RegisterType<CovidController>().InstancePerRequest();

            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}