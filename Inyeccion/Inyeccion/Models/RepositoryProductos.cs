using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inyeccion.Models
{
    public class RepositoryProductos : IRepositoryProductos
    {
        List<Producto> productos;
        public RepositoryProductos()
        {
            this.CrearProductos();
        }

        public List<Producto> GetProductos()
        {
            return productos;
        }

        private void CrearProductos()
        {
            productos = new List<Producto>();
            productos.AddRange(new Producto[] {
                new Producto()
                {
                    Nombre = "Xiaomi 8 pro", Imagen="1.jpg", Precio=500
                },
                new Producto()
                {
                    Nombre = "Samsung Galasy note 9", Imagen="2.jpg", Precio=900
                },
                new Producto()
                {
                    Nombre = "Xiaomi Redmi 4x", Imagen="3.jpg", Precio=110
                }
            });
        }
    }
}