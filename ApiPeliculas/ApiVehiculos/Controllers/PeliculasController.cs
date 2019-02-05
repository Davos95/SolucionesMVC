using ApiVehiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiVehiculos.Controllers
{
    public class PeliculasController : ApiController
    {
        public List<Pelicula> listaPeliculas = new List<Pelicula>();

        public PeliculasController()
        {
            Pelicula pelicula = new Pelicula(1, "Origen", "Dom Cobb es un ladrón con una extraña habilidad para entrar a los sueños de la gente y robarles los secretos de sus subconscientes. Su habilidad lo ha vuelto muy popular en el mundo del espionaje corporativo, pero ha tenido un gran costo en la gente que ama. Cobb obtiene la oportunidad de redimirse cuando recibe una tarea imposible: plantar una idea en la mente de una persona. Si tiene éxito, será el crimen perfecto, pero un enemigo se anticipa a sus movimientos.", new DateTime(2010, 8, 6), "https://is1-ssl.mzstatic.com/image/thumb/Video4/v4/86/ac/14/86ac14f2-8c9b-2a5a-80be-49b8ee402228/pr_source.lsr/268x0w.png");
            this.listaPeliculas.Add(pelicula);
            pelicula = new Pelicula(2, "El caballero oscuro", "Batman tiene que mantener el equilibrio entre el heroísmo y el vigilantismo para pelear contra un vil criminal conocido como el Joker, que pretende sumir Gotham City en la anarquía", new DateTime(2008, 8, 13), "https://images-na.ssl-images-amazon.com/images/I/41BorWGJegL._SX302_BO1,204,203,200_.jpg");
            this.listaPeliculas.Add(pelicula);
            pelicula = new Pelicula(3, "Piratas del Caribe: La maldición del Perla Negra", "Un herrero y un extraño pirata se unen para rescatar a una dama secuestrada de un capitán de piratas y su tripulación.", new DateTime(2003, 8, 14), "http://viveloya.com/images/stories/virtuemart/product/maldición%20del%20perla%20negra.jpg");
            this.listaPeliculas.Add(pelicula);


        }
    }
}
