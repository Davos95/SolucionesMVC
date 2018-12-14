using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticasMVC.Models
{
    public class Numero
    {
        public int numero { get; set; }
        public List<int> multiplicaciones { get; set; }
        public Numero(int num)
        {
            this.numero = num;
            multiplicaciones = new List<int>();
        }
    }
}