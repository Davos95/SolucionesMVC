using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inyeccion.Models
{
    public interface IRepositoryProductos
    {
        //SOLAMENTE SE DECLARA SU FUNCIONALIDAD, NO LLEVA IMPLEMENTACION EN MI CLASE REPO,
        //NECESITAMOS UN METODO GetProductos()
        List<Producto> GetProductos(); 
    }
}
