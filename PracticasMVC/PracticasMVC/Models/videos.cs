using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticasMVC.Models
{
    public class Videos
    {
       public String texto { get; set; }
       public String video { get; set; }
        public Videos(String t, String v)
        {
            this.texto = t;
            this.video = v;
        }

    }
}