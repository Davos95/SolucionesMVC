using Autofac;
using Autofac.Integration.Mvc;
using Inyeccion.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inyeccion.App_Start
{
    public class IoCConfiguration
    {
        public static void Configure()
        {
            //NECESITAMOS UN CONSTRUCTOR PARA EL CONTENEDOR
            //ESTE CONSTRUCTOR REGISTRA TODAS LA CLASES, VIEW, CONTROLES Y PERSONALIZADAS
            ContainerBuilder builder = new ContainerBuilder();

            //Registramos los controladores
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Registramos la vistas
            builder.RegisterSource(new ViewRegistrationSource());

            //REGISTRAMOS LAS CLASES PERSONALIZADAS
            builder.RegisterModule(new IoCModule());

            IoCModule.RegistrarRepos(builder);

            //CREAMOS EL CONTENEDOR CON EL CONSTRUCTOR (builder)
            IContainer contenedor = builder.Build();

            //INDICAMOS A NUESTRA APLICACION MVC QUE CONTENEDOR UTIIZAMOS PARA DI e IoC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(contenedor));

            
        }
    }
}