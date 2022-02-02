using Autofac;
using Uni.Repository;
using Uni.Repository.Common;

namespace My.Repository
{
    public class RepositoryDIModule : Module
    { 
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>()
                    .As<IStudentRepository>()
                    .InstancePerRequest();

            builder.RegisterType<SmjerRepository>()
                    .As<ISmjerRepository>()
                    .InstancePerRequest();
        }
        
    }
}
