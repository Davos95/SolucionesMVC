using Autofac;
using Inyeccion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inyeccion.IoC
{
    public class IoCModule: Module
    {

        public static void RegistrarRepos(ContainerBuilder builder)
        {
            //AQUI DECIMOS QUE REPO INYECAMOS Y COMO SE REALIZA REGISTRADO EL TIPO CON SU INTERFACE
            builder.RegisterType<RepositoryProductos>().As<IRepositoryProductos>().InstancePerRequest();



        }

        //protected override void Load(ContainerBuilder builder)
        //{
        //    //builder.Register(z => new Clase());
            

        //    builder.Register(z => new RepositoryProductos()).InstancePerRequest();

        //    //.SingleInstance();
        //    //.InstancePerRequest();

        //    base.Load(builder);
        //}
    }
}