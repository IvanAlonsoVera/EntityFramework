using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonaEntity
{
    public partial class PersonaEntity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new Model1Container())
            {

                //var person = new PersonaEntidad
                //{
                //    DNI = "23365526L",
                //    Nombre = "Ivan",
                //    Apellido = "Alonso",
                //    Sueldo = 1500
                //};
                //context.PersonaEntidad.Add(person); 
                //person = new PersonaEntidad
                //{
                //    DNI = "02290092M",
                //    Nombre = "Manuel",
                //    Apellido = "Arias",
                //    Sueldo = 2800
                //};
                //context.PersonaEntidad.Add(person);
                //person = new PersonaEntidad
                //{
                //    DNI = "56965658G",
                //    Nombre = "Jean",
                //    Apellido = "Cantoral",
                //    Sueldo = 900
                //};
                //context.PersonaEntidad.Add(person);
                //person = new PersonaEntidad
                //{
                //    DNI = "46516161S",
                //    Nombre = "Pepe",
                //    Apellido = "Martin",
                //    Sueldo = 600
                //};
                //context.PersonaEntidad.Add(person);
                //context.SaveChanges();

                var query = context.PersonaEntidad.ToList();


                gv1.DataSource= query;
                gv1.DataBind();
            }
        }
    }
}