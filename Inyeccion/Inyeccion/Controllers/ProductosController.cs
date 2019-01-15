using Inyeccion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;

namespace Inyeccion.Controllers
{
    public class ProductosController : Controller
    {
        IRepositoryProductos repo;


        public ProductosController(IRepositoryProductos repo)
        {
            this.repo = repo;
        }

        // GET: Productos
        public ActionResult Index()
        {
            return View(this.repo.GetProductos());
        }
    }
}