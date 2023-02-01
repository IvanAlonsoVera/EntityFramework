using EjercicioCoche_Basico_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioCoche_Basico_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "sin datos";
        }
        public ViewResult CrearCoche()
        {
            Coche coche1 = new Coche()
            {
                Color="Blanco",
                Modelo="Transit",
                Marca="Ford"
            };

            return View("Index",(object)string.Format("Marca: {0} Modelo: {1} Color: {2}",coche1.Marca,coche1.Modelo,coche1.Color));
        }
        public ViewResult CrearCliente()
        {

            string[] clientes = new string[]{ "pepe", "juan" };

            return View("Index", (object)string.Format("Nombre Cliente {0}", clientes[0]));
        }
    }
}