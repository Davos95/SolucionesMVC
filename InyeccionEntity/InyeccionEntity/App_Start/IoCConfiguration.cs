using Autofac;
using Autofac.Integration.Mvc;
using InyeccionEntity.Models;
using InyeccionEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace InyeccionEntity.App_Start
{
    public class IoCConfiguration
    {
        /*DEBEMOS REGISTRAR
          ----------------
        LOS CONTROLADORES
        LAS INTERFACES
        LAS CLASES PROPIAS*/

            //REGISTRAR CONTROLADORES
        private static void RegistrarControladores(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }

        //REGISTRAR INTERFACES REPO
        private static void RegistrarRepos(ContainerBuilder builder)
        {
            //AQUI INYECTAMOS EL TIPO DE REPOSITORIO (CLASE) QUE DESEAMOS PARA NUESTRO CONTROLLER
            builder.RegisterType<RepositoryHospital>().As<IRepositoryHospital>().InstancePerRequest();
        }

        //REGISTRAR CLASES

        private static void RegistrarClases(ContainerBuilder builder)
        {
            //REGISTRAMOS LOS CONTEXTOS DE LOS QUE DEPENDE LOS REPOSITORIOS
            builder.Register(z => new HospitalContext()).InstancePerRequest();
        }

        public static void Configure()
        {
            //Creamos el constructor
            ContainerBuilder builder = new ContainerBuilder();
            //Registramos las dependencias
            RegistrarControladores(builder);
            RegistrarClases(builder);
            RegistrarRepos(builder);
            //Construimos el contenedor
            IContainer container = builder.Build();
            //Indicamos a MVC que contenedor utilizara para la inyeccion de dependencias
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}