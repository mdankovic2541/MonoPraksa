using Autofac;
using Autofac.Integration.WebApi;
using My.Repository;
using MyService;
using System.Reflection;
using System.Web.Http;

namespace Uni.WebWebApi.App_Start
{
    public class AutofacWebapiConfig
    {

        //https://www.c-sharpcorner.com/article/using-autofac-with-web-api/


        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new ServiceDIModule());
            builder.RegisterModule(new RepositoryDIModule());
            



            Container = builder.Build();
           

            return Container;
        }
    }
}