using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerEjercicioAJAX
{
    public partial class Aleatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static string BuscarNumAleatorio()
        {
            Random aleatorio = new Random();
            return aleatorio.Next(0,1000).ToString();
        }
    }
}