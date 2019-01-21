using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using RepositoriosHospital.Contexts;
using RepositoriosHospital.Models;
using RepositoriosHospital.Repositories;

namespace InyeccionBBDD.App_Start
{
    public class IoCConfigurationAutofac
    {

        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            RegistrarControllers(builder);
            RegistrarContexts(builder);
            RegistrarRepos(builder);
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegistrarControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }
        private static void RegistrarContexts(ContainerBuilder builder)
        {
            builder.Register(z => new EntidadHospital()).InstancePerRequest();
            
            //builder.RegisterType<HospitalContextSQL>().As<IHospitalContext>().InstancePerRequest();
            //builder.RegisterType<HospitalContextMySQL>().As<IHospitalContext>().InstancePerRequest();
            //builder.RegisterType<HospitalContextOracle>().As<IHospitalContext>().InstancePerRequest();
        }
        private static void RegistrarRepos(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryDepartamento>().As<IRepositoryDepartamento>().InstancePerRequest();
            builder.RegisterType<RepositoryEmpleado>().As<IRepositoryEmpleados>().InstancePerRequest();
        }
    }
}