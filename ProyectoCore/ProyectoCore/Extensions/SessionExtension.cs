using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCore.Extensions
{
    public static class SessionExtension
    {
       public static void SetObject(this ISession session, String clave, object value)
       {

       }

        public static object GetObject(this ISession session, String clave)
        {
            return null;
        }
    }
}
