using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConceptosMVC2.Repositories
{
    public class RepositoryCulture
    {
        public void InitializeCulture(String culture)
        {
            
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);

        }
    }
}