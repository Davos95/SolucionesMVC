using ConceptosMVC.Models;
using ConceptosMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class CifradoBBDDController : Controller
    {
        RepositoryUsuarios repo;
        public CifradoBBDDController()
        {
            repo = new RepositoryUsuarios();
        }

        // GET: CifradoBBDD
        public ActionResult RegistrarUsuarios()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RegistrarUsuarios(String nombre, String username, String password)
        {
            this.repo.InsertUsuario(nombre, username, password);
            
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String username, String passwod)
        {
            Usuario usuario = this.repo.ComprobarUsuario(username, passwod);
            if(usuario != null)
            {
                ViewBag.Mensaje = "Usuario existe";
            } else
            {
                ViewBag.Mensaje = "El usuario no existe";
            }

            return View();
        }
    }
}