using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerAjax
{
    public partial class Calculadora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static int GetSumar(String valor1, String valor2)
        {
            int dato1 = Convert.ToInt32(valor1);
            int dato2 = Convert.ToInt32(valor2);
            int resultado = Sumar(dato1,dato2);
            return resultado;
        }
        private static int Sumar(int dato1,int dato2)
        {
            return dato1 + dato2;
        }
        public static int GetRestar(String valor1, String valor2)
        {
            int dato1 = Convert.ToInt32(valor1);
            int dato2 = Convert.ToInt32(valor2);
            int resultado = Restar(dato1, dato2);
            return resultado;
        }
        private static int Restar(int dato1, int dato2)
        {
            return dato1 - dato2;
        }
        public static int GetMultiplicar(String valor1, String valor2)
        {
            int dato1 = Convert.ToInt32(valor1);
            int dato2 = Convert.ToInt32(valor2);
            int resultado = Multiplicar(dato1, dato2);
            return resultado;
        }
        private static int Multiplicar(int dato1, int dato2)
        {
            return dato1 * dato2;
        }
        public static int GetDividir(String valor1, String valor2)
        {
            int dato1 = Convert.ToInt32(valor1);
            int dato2 = Convert.ToInt32(valor2);
            int resultado = Dividir(dato1, dato2);
            return resultado;
        }
        private static int Dividir(int dato1, int dato2)
        {
            return dato1 / dato2;
        }
    }
}