using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComboMasTextBoxAJAX
{
    public partial class Funcionalidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        [System.Web.Services.WebMethod]
        public static List<SupplierCargar> CargarDatos()
        {
            using (var context = new NORTHWNDEntities())
            {
                var query = context.Suppliers
                    .Select(s => new SupplierCargar
                    {
                        SupplierID = s.SupplierID,
                        ContactName = s.ContactName,
                    }).ToList();
                return query;
            }
        }
        [System.Web.Services.WebMethod]
        public static Datos RellenarTextBox(string otracosa)
        {
            int idDelSupplier = Convert.ToInt32(otracosa);
            using (var context = new NORTHWNDEntities())
            {
                var query = (context.Products
                    .Where(p => p.SupplierID == idDelSupplier)
                    .OrderByDescending(p=>p.UnitsOnOrder)
                    .Select(p => new Datos
                    {
                        Nombre = p.ProductName,
                        Maximo = (short)p.UnitsOnOrder
                    })).FirstOrDefault();
                return query;
            }
        }
    }
}