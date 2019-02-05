using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiVehiculos.Models
{
    public class Coche
    {
        public int IdCoche { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Combustible { get; set; }
        public int Precio { get; set; }
        public String Url { get; set; }
        public Coche() { }
        public Coche(int id, String marca, String modelo, String combustible, int precio, String url)
        {
            this.IdCoche = id;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Combustible = combustible;
            this.Precio = precio;
            this.Url = url;
        }
    }
}