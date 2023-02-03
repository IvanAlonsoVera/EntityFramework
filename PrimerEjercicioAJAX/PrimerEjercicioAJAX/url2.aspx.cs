using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerEjercicioAJAX
{
    public partial class url2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int dato = Convert.ToInt32(Request.Form["dato"]);
            int valor = factorial(dato);
            Response.Write(valor);
        }

        private int factorial(int dato)
        {
            if(dato < 2)
            {
                return 1;
            }
            else
            {
                return dato * factorial(dato - 1);
            }
        }
    }
}