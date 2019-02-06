using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCore.Models
{
    public class Deportivo : ICoche
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int VelocidadMaxima { get; set; }
        public int VelocidadActual { get; set; }
        public string Imagen { get; set; }

        public Deportivo()
        {
            this.Marca = "Marca desconocida 1";
            this.Modelo = "Parece rápido";
            this.Imagen = "coche_amarillo.jpg";
            this.VelocidadMaxima = 250;
            this.VelocidadActual = 0;
        }

        public Deportivo(String marca, String modelo, String imagen, int velocidadmaxima)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Imagen = imagen;
            this.VelocidadMaxima = velocidadmaxima;
        }

        public void Acelerar()
        {
            this.VelocidadActual += 40;
            if (this.VelocidadActual > this.VelocidadMaxima)
            {
                this.VelocidadActual = this.VelocidadMaxima;
            }
        }

        public void Frenar()
        {
            this.VelocidadActual -= 40;
            if (this.VelocidadActual < 0)
            {
                this.VelocidadActual = 0;
            }
        }
    }
}
