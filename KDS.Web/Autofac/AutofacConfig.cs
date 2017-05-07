using Autofac;
using Autofac.Integration.Mvc;
using KDS.Application.Services;
using KDS.Domain.Seedwork;
using KDS.Domain.Services;
using KDS.Infraestructure.Data;
using KDS.Infraestructure.Data.Repositories;
using System.Reflection;
using System.Web.Mvc;

namespace KDS.Web.Autofac
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(PtoPreparacionRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(PtoPreparacionService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            //builder.RegisterAssemblyTypes(typeof(PtoPreparacionAppService).Assembly)
            //    .Where(t => t.Name.EndsWith("AppService"))
            //    .AsImplementedInterfaces()
            //    .InstancePerRequest();

            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}