using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoCore.Models;
using ProyectoCore.Repositories;

namespace ProyectoCore.Controllers
{
    public class DepartamentoController : Controller
    {
        IRepositoryHospital repo;
        public DepartamentoController(IRepositoryHospital repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View(this.repo.GetDepartamentos());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Departamento dept)
        {
            this.repo.InsertarDepartamento(dept.Numero, dept.Nombre, dept.Localidad);

            return RedirectToAction("Index");
        }

    }
}