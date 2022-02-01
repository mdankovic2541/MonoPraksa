using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using Uni.Model;
using Uni.Model.Common;
using Uni.Repository;
using Uni.Repository.Common;
using Uni.Service;
using Uni.Service.Common;

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

            builder.RegisterType<StudentService>()
                   .As<IStudentService>()
                   .InstancePerRequest();

            builder.RegisterType<SmjerService>()
                   .As<IStudentController>()
                   .InstancePerRequest();

            builder.RegisterType<StudentRepository>()
                  .As<IStudentRepository>()
                  .InstancePerRequest();

            builder.RegisterType<SmjerRepository>()
                   .As<ISmjerRepository>()
                   .InstancePerRequest();

            builder.RegisterType<Student>()
                  .As<IStudent>()
                  .InstancePerRequest();

            builder.RegisterType<Smjer>()
                   .As<ISmjer>()
                   .InstancePerRequest();

                   
            
            Container = builder.Build();

            return Container;
        }
    }
}