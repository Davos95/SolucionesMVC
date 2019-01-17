using Autofac;
using Autofac.Integration.Mvc;
using IoCServidores.Models;
using IoCServidores.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace IoCServidores.App_Start
{
    public class IoCConfiguration
    {
        //Controllers
        private static void RegistrarControladores(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }

        //Interfaces y repositorios
        private static void RegistrarRepos(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryDepartamento>().As<IRepositoryDepartamento>().InstancePerRequest();
        }

        //Clases
        private static void RegistrarClases(ContainerBuilder builder)
        {
            builder.Register(z => new HospitalContext()).InstancePerRequest();
        }

        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            RegistrarClases(builder);
            RegistrarControladores(builder);
            RegistrarRepos(builder);
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}