using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCore.Models
{
    public interface ICoche
    {
         String Marca { get; set; }
         String Modelo { get; set; }
         int VelocidadMaxima { get; set; }
         int VelocidadActual { get; set; }
         String Imagen { get; set; }
        
        void Acelerar();
        void Frenar();
        
    }
}
