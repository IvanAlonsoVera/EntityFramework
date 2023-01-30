using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SegurosCodeFirst
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using(var context = new DbContext.Context())
            {
                var accidentes = context.AccidenteVehiculos
                    .Where(av => av.Vehiculo.Marca == "Ford")
                    .Select(av => new
                    {
                        av.Accidente.Fecha,
                        av.Accidente.Hora,
                        av.Accidente.Lugar
                    }).ToList();
            }
            using (var context = new DbContext.Context())
            {
                var personasAccidentadas = context.PersonaAccidentes
                    .Where(ac=>ac.Accidente.Lugar=="Paseo de la castellana 32")
                    .Select(ac => new
                    {
                        ac.Persona.Nombre,
                        ac.Persona.DNI
                    }).ToList();

                var personasMultadas = context.Multas
                    .Where(pm => pm.Lugar == "calle goya, 52")
                    .Select(pm => new
                    {
                        pm.Fecha,
                        pm.Persona.DNI,
                        pm.Vehiculo.Matricula
                    }).ToList();
            }
        }
    }
}