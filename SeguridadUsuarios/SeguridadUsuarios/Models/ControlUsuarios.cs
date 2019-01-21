using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeguridadUsuarios.Models
{
    public class ControlUsuarios
    {
        //UNA PROPIEDAD PARA DEVOLVERNOS EL ROLE
        //EN REALIDAD NOS DEVOLVERIA UN OBJETO USER
        public String role { get; set; }
        //UN METODO DE VALIDACION
        public bool ExisteUsuario(String usuario, String password)
        {
            //Tendremos los usuarios con distinto ROLE
            //USER USER Y ADMIN ADMIN
            if(usuario.ToUpper() == "ADMIN" && password.ToUpper() == "ADMIN")
            {
                this.role = "ADMINISTRADOR";
                return true;
            } else if(usuario.ToUpper() == "USER" && password.ToUpper() == "USER")
            {
                this.role = "USUARIO";
                return true;
            } else
            {
                return false;
            }
        }
    }
}