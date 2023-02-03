using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerEjercicioAJAX
{
    public partial class url3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static int GetSuma(string valor1,string valor2)
        {
            int dato1 = Convert.ToInt32(valor1);
            int dato2 = Convert.ToInt32(valor2);

            int resultado = Sumar(dato1, dato2);
            return resultado;
        }
        [System.Web.Services.WebMethod]
        public static int GetResta(string valor1, string valor2)
        {
            int dato1 = Convert.ToInt32(valor1);
            int dato2 = Convert.ToInt32(valor2);

            int resultado = Restar(dato1, dato2);
            return resultado;
        }
        [System.Web.Services.WebMethod]
        public static int GetMultiplica(string valor1, string valor2)
        {
            int dato1 = Convert.ToInt32(valor1);
            int dato2 = Convert.ToInt32(valor2);

            int resultado = Multiplicar(dato1, dato2);
            return resultado;
        }
        [System.Web.Services.WebMethod]
        public static decimal GetDivide(string valor1, string valor2)
        {
            decimal dato1 = Convert.ToDecimal(valor1);
            decimal dato2 = Convert.ToDecimal(valor2);

            decimal resultado = Dividir(dato1, dato2);
            return resultado;
        }

        private static decimal Dividir(decimal dato1, decimal dato2)
        {
            return dato1 / dato2;
        }

        private static int Multiplicar(int dato1, int dato2)
        {
            return dato1 * dato2;
        }

        private static int Restar(int dato1, int dato2)
        {
            return dato1 - dato2;
        }

        private static int Sumar(int dato1, int dato2)
        {
            return dato1 + dato2;
        }
    }
}