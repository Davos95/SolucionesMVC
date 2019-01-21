using RepositoriosHospital.Contexts;
using RepositoriosHospital.Models;
using RepositoriosHospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace InyeccionBBDD.App_Start
{
    public class IoCCOnfigurationUnity
    {
        public static void Configure()
        {
            UnityContainer container = new UnityContainer();
            RegistrarContext(container);
            RegistrarRepos(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static void RegistrarContext(UnityContainer container)
        {
            //container.RegisterType<IHospitalContext, HospitalContextSQL>();
            //container.RegisterType<IHospitalContext, EntidadHospital>();
            //container.RegisterType<IHospitalContext, HospitalContextMySQL>();
            //container.RegisterType<IHospitalContext, HospitalContextOracle>();
        }

        public static void RegistrarRepos(UnityContainer container)
        {
            container.RegisterType<IRepositoryDepartamento, RepositoryDepartamento>();
            container.RegisterType<IRepositoryEmpleados, RepositoryEmpleado>();

            //container.RegisterType<interface, clase>();
        }


    }
}