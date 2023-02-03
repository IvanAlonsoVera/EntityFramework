using PrimerEjercicioAJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerEjercicioAJAX
{
    public partial class urlCombo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static List<Empleado> LLenarCombo()
        {
            using(var context = new NORTHWNDEntities())
            {
                var query = context.Employees
                    .Select(em => new Empleado
                    {
                        EmpleadoId = em.EmployeeID,
                        NombreCompleto = em.FirstName + " " + em.LastName,
                    }).ToList();
                return query;
            }
        }
    }
}