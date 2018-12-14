using PracticasMVC.Helper;
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
        HelperVideos videos;
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

        public ActionResult TablaMultiplicarHTML()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TablaMultiplicarHTML(int? num)
        {
            String html = "<table class='table table-bordered'>";
            for (int i = 1; i <= 10; i++)
            {
                int resultado = num.Value * i;
                html += "<tr><td>" + i + " x " + num + "</td><td>"+resultado+"</td></tr>";
            }
            html += "</table>";
            ViewBag.HTML = html;
            return View();
        }

        public ActionResult VideosYoutube()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VideosYoutube(String video)
        {
            if(video.Trim() != "")
            {
                String html = "<iframe width = '560' height = '315'";
                if (video.IndexOf('=') > -1)
                {
                    String code = video.Split('=')[1];
                     html += " src='https://www.youtube.com/embed/"+code+"' frameborder = '0' allow = 'accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen ></ iframe >";
                } else if(video.Split('/').Length == 4)
                {
                    String[] array = video.Split('/');
                    String code = array[array.Length - 1];
                    html += " src='https://www.youtube.com/embed/" + code+ "' frameborder = '0' allow = 'accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen > </iframe>";
                } else
                {
                    html += " src='" + video + "' frameborder = '0' allow = 'accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen > </iframe>";
                }
                
                ViewBag.youtubeVideo = html;
            }
            
            return View();
        }

        // GET: ListaVideosYoutube
        public ActionResult ListaVideosYoutube()
        {
            videos = new HelperVideos();

            ViewBag.selectVideos = videos.GetVideos();
            return View();
        }

        //POST: ListaVideosYoutube
        [HttpPost]
        public ActionResult ListaVideosYoutube(String code)
        {
            videos = new HelperVideos();

            String html = "<iframe width = '560' height = '315'";
            html += " src='https://www.youtube.com/embed/" + code + "' frameborder = '0' allow = 'accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen ></ iframe >";

            ViewBag.selectVideos = videos.GetVideos();
            foreach (Videos item in ViewBag.selectVideos)
            {
                if (item.video == code)
                {
                    ViewBag.nombreVideo = item.texto;
                }
            }
            ViewBag.video = html;
            return View();
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