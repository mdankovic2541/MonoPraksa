using System.ComponentModel;

using Uni.Service;
using Uni.Service.Common;
using Autofac;

namespace MyService
{
    public class ServiceDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>()
                    .As<IStudentService>()
                    .InstancePerRequest();

            builder.RegisterType<SmjerService>()
                   .As<ISmjerService>()
                   .InstancePerRequest();

            
        }
    }
}
