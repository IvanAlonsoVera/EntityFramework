using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntityParte1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new Model1Container())
            {

                //var person = new Persona
                //{
                //    FirstName = "Robert",
                //    MiddleName = "Allen",
                //    LastName = "Doe",
                //    PhoneNumber = "876-9865"
                //};
                //context.Personas.Add(person); person = new Persona
                //{
                //    FirstName = "John",
                //    MiddleName = "K.",
                //    LastName = "Smith",
                //    PhoneNumber = "876-9865"
                //};
                //context.Personas.Add(person);
                //context.SaveChanges();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var context = new Model1Container())
            {
                foreach (var person in context.Personas)
                {
                    Response.Write(person.FirstName + " " + person.LastName);
                    Response.Write(person.PhoneNumber + "</br>");
                }
            }
        }
    }
}