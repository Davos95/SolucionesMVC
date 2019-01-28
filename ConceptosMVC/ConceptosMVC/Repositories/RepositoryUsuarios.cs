using ConceptosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Repositories
{
    public class RepositoryUsuarios
    {
        HospitalContext context;
        public RepositoryUsuarios()
        {
            this.context = new HospitalContext();
        }

        public void InsertUsuario(String nombre, String username, String password)
        {
            int num = this.context.usuarios.ToList().Count();
            System.Diagnostics.Debug.WriteLine("HOLA NUMERO ES: "+ num + "||||");
            Usuario usuario = new Usuario();
            usuario.IDUSUARIO = num;
            usuario.Nombre = nombre;
            usuario.nUsuario = username;
            String salt = ModeloToolkit.GenerarSalt();
            byte[] passCifrada = ModeloToolkit.Encriptar(password, salt);
            usuario.pass = passCifrada;
            usuario.salt = salt;
            this.context.usuarios.Add(usuario);
            this.context.SaveChanges();

        }

        public Usuario ComprobarUsuario(String username, String password)
        {
            var consulta = from datos in context.usuarios
                           where datos.nUsuario == username
                           select datos;
            Usuario usuario = consulta.FirstOrDefault();
            if(usuario != null)
            {
                String salt = usuario.salt;
                byte[] datospassword = usuario.pass;
                byte[] datoscifrados = ModeloToolkit.Encriptar(password, salt);
                bool flag = true;
                if(datospassword.Length != datoscifrados.Length)
                {
                    return null;
                }
                for (int i = 0; i <= datoscifrados.Length -1; i++)
                {
                    if(datoscifrados[i].Equals(datospassword[i]) == false)
                    {
                        flag = false;
                        i = datoscifrados.Length+1;
                    }
                }
                if(flag == false)
                {
                    return null;
                } else
                {
                    return usuario;
                }
            }
            return null;
        }
        
    }
}