using PracticasMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace PracticasMVC.Controllers.Practicas
{
    public class PracticasController : Controller
    {
        // GET: Practicas
        public ActionResult Index()
        {
            return View();
        }

        // GET: SumarNumeros
        public ActionResult SumarNumeros()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SumarNumeros(int? num1, int? num2)
        {
            if(num1 is null)
            {
                num1 = 0;
            }
            if(num2 is null)
            {
                num2 = 0;
            }
            ViewBag.Suma = num1 + num2;
            return View();
        }
        // GET: NumeroDoble
        public ActionResult NumeroDoble(int? numGet)
        {
            List<int> numeros = new List<int>();
            Random random = new Random();
            int num1 = random.Next(1, 20);
            for (int i = 0; i < num1; i++)
            {
                numeros.Add(random.Next(1, 100));
            }
            ViewBag.numeros = numeros;

            if (numGet != null) {
                ViewBag.numDoble = numGet * 2;
            }
            return View();
        }
        
        public ActionResult TablaDeMultiplicar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TablaDeMultiplicar(int? num)
        {
            List<int> numeros = new List<int>();
            if(num != null)
            {
                for (int i = 1; i < 11; i++)
                {
                    numeros.Add(i * num.Value);
                }
                ViewBag.numeros = numeros;
            } else
            {
                 
            }
            
            return View();
        }

        //GET: TablaDeMultiplicarConObjetos
        public ActionResult TablaDeMultiplicarConObjetos()
        {
            return View();
        }

        //POST: TablaDeMultiplicarConObjetos
        [HttpPost]
        public ActionResult TablaDeMultiplicarConObjetos(int? num)
        {
            Numero numero = new Numero(num.Value);
            if (num != null)
            {
                numero = new Numero(num.Value);
            } else
            {
                numero = new Numero(1);
            }

            for (int i = 1; i <= 10; i++)
            {
                numero.multiplicaciones.Add( numero.numero * i);
            }
            
            
            return View(numero);
        }

        //Metodo web para funcionar con AJAX
        [WebMethod]
        public int Sumar(String numeros)
        {
            int total = 0;
            String[] nums = numeros.Split(';');
            
            foreach (String n in nums)
            {
                if(n != "") {
                    total += int.Parse(n);
                }
                
            }
            return total;
        }
    }
}