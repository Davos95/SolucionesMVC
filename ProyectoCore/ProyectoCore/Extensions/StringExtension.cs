using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCore.Extensions
{
    public static class StringExtension
    {

        public static int GetNumeroPalabras(this String texto)
        {
            return texto.Split(' ').Count();

        }
    }
}
