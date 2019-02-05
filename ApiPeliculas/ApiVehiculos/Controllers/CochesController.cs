using ApiVehiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiVehiculos.Controllers
{
    public class CochesController : ApiController
    {
        List<Coche> listaCoches = new List<Coche>();
        public CochesController()
        {
            Coche coche = new Coche(1,"Seat","León","Gasolina",20000, "https://a.ccdn.es/nuevos/400/seat/leon/2019/5ha.jpg");
            this.listaCoches.Add(coche);
            coche = new Coche(2,"Seat", "ALTEA", "Gasolina", 18000, "https://a.ccdn.es/nuevos/400/seat/altea/2013/5mm.jpg");
            this.listaCoches.Add(coche);
            coche = new Coche(3,"Peugeot", "108", "Gasolina", 14440, "https://a.ccdn.es/nuevos/400/peugeot/108/2018/5mc.jpg");
            this.listaCoches.Add(coche);
            coche = new Coche(4, "Peugeot", "208", "Gasolina", 16810, "https://a.ccdn.es/nuevos/400/peugeot/208/2018/5ha.jpg");
            this.listaCoches.Add(coche);
            coche = new Coche(5, "Renault", "Captur", "Gasolina", 16390, "https://a.ccdn.es/nuevos/400/renault/captur/2018/5ha.jpg");
            this.listaCoches.Add(coche);
            coche = new Coche(6, "Renault", "Clio", "Diesel", 17590, "https://a.ccdn.es/nuevos/400/renault/clio/2018/5ha.jpg");
            this.listaCoches.Add(coche);
            coche = new Coche(7, "Kia", "Stinger", "Diesel", 38800, "https://a.ccdn.es/nuevos/400/kia/stinger/2019/5ha.jpg");
            this.listaCoches.Add(coche);
        }

        //GET api/<controller>
        public List<Coche> GetCoches()
        {
            return this.listaCoches;
        }

        public Coche GetCoche(int id)
        {
            Coche coche = this.listaCoches.Find(x => x.IdCoche == id);
            return coche;
        }
    }
}
