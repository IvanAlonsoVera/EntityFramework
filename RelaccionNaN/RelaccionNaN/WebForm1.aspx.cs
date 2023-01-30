using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RelaccionNaN
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //solamente la primera vez
            //meterDatos();
            if (!IsPostBack)
            {
                //meterDatos();
                cargarProyectos();
                cargarCientificos();
            }
        }
        private void cargarCientificos()
        {
            using (var db = new Model1Container())
            {
                var cientificos = db.Cientificos
                    .ToList();
                ddlCientificos.DataSource = cientificos;
                ddlCientificos.DataValueField = "Id_Cientifico";
                ddlCientificos.DataTextField = "Nombre_Cientifico";
                ddlCientificos.DataBind();
            }
        }
        private void cargarProyectos()
        {
            using (var db = new Model1Container())
            {
                var query = db.Proyectos.ToList();
                ddlProyectos.DataSource = query;
                ddlProyectos.DataValueField = "Id_Proyecto";
                ddlProyectos.DataTextField = "Nombre_Proyecto";
                ddlProyectos.DataBind();
            }
        }
        private void meterDatos()
        {
            using (var db = new Model1Container())
            {
                Proyecto proyecto1 = new Proyecto()
                {
                    Nombre_Proyecto = "Helio Liquido",
                    Horas = 230
                };
                db.Proyectos.Add(proyecto1);
                Proyecto proyecto2 = new Proyecto()
                {
                    Nombre_Proyecto = "Superconductores",
                    Horas = 238
                };
                db.Proyectos.Add(proyecto2);
                Cientifico cientifico1 = new Cientifico()
                {
                    Nombre_Cientifico = "Jose Sanchez",
                    DNI = "154644F"
                };
                db.Cientificos.Add(cientifico1);
                Cientifico cientifico2 = new Cientifico()
                {
                    Nombre_Cientifico = "Juan Gonzalez",
                    DNI = "4646561T"
                };
                db.Cientificos.Add(cientifico2);
                db.SaveChanges();
            }
        }
        protected void ddlProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCientificosProyecto(Convert.ToInt32(ddlProyectos.SelectedValue));
        }
        private void cargarCientificosProyecto(int v)
        {
            using (var db = new Model1Container())
            {
                var cientificos = db.Proyectos
                    .Where(p => p.Id_Proyecto == v)
                    .SelectMany(p => p.Cientifico).ToList();
                if (cientificos.Count() > 0)
                {
                    gvCientificosProyecto.DataSource = cientificos;
                }
                else
                {
                    gvCientificosProyecto.DataSource = null;
                }
                gvCientificosProyecto.DataBind();
            }
        }
        protected void ddlCientificos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarProyectosCientifico(Convert.ToInt32(ddlCientificos.SelectedValue));
        }
        private void cargarProyectosCientifico(int v)
        {
            using (var db = new Model1Container())
            {
                var proyectos = db.Cientificos
                    .Where(c => c.Id_Cientifico == v)
                    .SelectMany(c => c.Proyecto).ToList();
                if (proyectos.Count() > 0)
                {
                    gvProyectosCientifico.DataSource = proyectos;
                }
                else
                {
                    gvProyectosCientifico.DataSource = null;
                }
                gvCientificosProyecto.DataBind();
            }
        }
        protected void btnAsociar_Click(object sender, EventArgs e)
        {
            generarProyectoCientifico(Convert.ToInt32(ddlCientificos.SelectedValue),
                Convert.ToInt32(ddlProyectos.SelectedValue));
            cargarCientificosProyecto(Convert.ToInt32(ddlProyectos.SelectedValue));
            cargarProyectosCientifico(Convert.ToInt32(ddlCientificos.SelectedValue));
        }
        private void generarProyectoCientifico(int v1, int v2)
        {
            using (var db = new Model1Container())
            {
                var cientificos = db.Cientificos.SingleOrDefault(c => c.Id_Cientifico == v1);
                if (cientificos != null)
                {
                    var proyecto = db.Proyectos.SingleOrDefault(p => p.Id_Proyecto == v2);
                    if (proyecto != null)
                    {
                        //Cientifico y proyecto existen (se puede asignar un proyecto a
                        //un cientifico)
                        if (!cientificos.Proyecto.Any(p => p == proyecto))
                        {
                            cientificos.Proyecto.Add(proyecto);
                            db.SaveChanges();
                        }
                    }
                }
            }
        }

    }
}