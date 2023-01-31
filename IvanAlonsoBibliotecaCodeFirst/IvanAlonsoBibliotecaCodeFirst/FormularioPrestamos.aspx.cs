using IvanAlonsoBibliotecaCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IvanAlonsoBibliotecaCodeFirst
{
    public partial class FormularioPrestamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                using (var context = new DbContext.Context())
                {
                    var usuarios = context.Usuarios
                        .Select(u=> new
                        {
                            u.Id,
                            u.Nombre
                        }).ToList();

                    ddlUsuario.DataSource= usuarios;
                    ddlUsuario.DataTextField = "Nombre";
                    ddlUsuario.DataValueField = "Id";
                    ddlUsuario.DataBind();

                    var Autores = context.Autores
                    .Select(a => new
                    {
                        a.Id,
                        a.Nombre
                    }).ToList();

                    ddlAutor.DataSource = Autores;
                    ddlAutor.DataTextField = "Nombre";
                    ddlAutor.DataValueField = "Id";
                    ddlAutor.DataBind();
                }
            }
            
        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        protected void ddlAutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new DbContext.Context())
            {
                var Autores = context.Libros
                    .Where(l=>l.Id == ddlAutor.SelectedIndex)
                    .Select(l => new
                    {
                        l.Id,
                        l.Titulo
                    }).ToList();

                ddlLibro.DataSource = Autores;
                ddlLibro.DataTextField = "Titulo";
                ddlLibro.DataValueField = "Id";
                ddlLibro.DataBind();
            }
        }

        protected void ddlLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            TbHoy.Text = DateTime.Now.ToString();
            TbDevolver.Text = DateTime.Now.AddDays(15).ToString();
        }

        protected void GvLibro_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Entregar")
            {
                using (var context = new DbContext.Context())
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow fila = GvLibro.Rows[index];
                    TableCell id = fila.Cells[0];
                    int idPrestamo = Convert.ToInt32(id.Text);

                    var fechadev = context.Prestamos
                        .Where(p => p.FechaDevolucion < DateTime.Now && p.Id == idPrestamo)
                        .Select(p => p).Count();
                    var query = context.Prestamos
                        .Where(p => p.Id == idPrestamo)
                        .Select(p => p).First();
                    if(fechadev == 0)
                    {
                        context.Prestamos.Remove(query);
                        context.SaveChanges();
                        CargarDatos();
                    }
                    else
                    {
                        TimeSpan difFechas = DateTime.Now - query.FechaDevolucion;
                        int dias = difFechas.Days;
                        var multa = (dias * 3);
                        Response.Write("<h1 class='text-danger'>Te has pasado de la fecha: "+dias+" Dias y tienes una multa de: "+multa+"€</h1>");
                        btnPagar.Visible=true;
                        hdnId.Value = idPrestamo.ToString();
                    }
                }
            }
        }
        protected void btnPagar_Click(object sender, EventArgs e)
        {
            var idPrestamo = Convert.ToUInt32(hdnId.Value);
            using (var context = new DbContext.Context())
            {
                var query = context.Prestamos
                    .Where(p => p.Id == idPrestamo)
                    .Select(p => p).First();
                context.Prestamos.Remove(query);
                context.SaveChanges();
                CargarDatos();
            }
                
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if(!((ddlAutor.SelectedIndex == 0)|| (ddlLibro.SelectedIndex == 0)|| (ddlUsuario.SelectedIndex == 0)))
            {
                using (var context = new DbContext.Context())
                {
                    var NPrestamos = context.Prestamos
                        .Where(p => p.Usuario.Id == ddlUsuario.SelectedIndex)
                        .Select(p => p).Count();

                    if (NPrestamos < 3)
                    {
                        var usuario = context.Usuarios
                            .FirstOrDefault(u => u.Id == ddlUsuario.SelectedIndex);

                        var libro = context.Libros
                            .FirstOrDefault(l => l.Id == ddlLibro.SelectedIndex);

                        Prestamo nuevoPrestamo = new Prestamo()
                        {
                            FechaDevolucion = Convert.ToDateTime(DateTime.Now.AddDays(15).ToShortDateString()),
                            FechaPrestamo = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                            Usuario = usuario,
                            Libro = libro,

                        };

                        context.Prestamos.Add(nuevoPrestamo);
                        context.SaveChanges();
                        CargarDatos();
                    }
                    else
                    {
                        Response.Write("<h1 class='text-danger'>Tienes demasiados libros sin devolver</h1>");
                    }
                }
            }
            else
            {
                Response.Write("<h1 class='text-danger'>Introduzca todos los datos por favor!!</h1>");
            }
        }

        private void CargarDatos()
        {
            using (var context = new DbContext.Context())
            {
                var usuarioSel = context.Usuarios
                   .FirstOrDefault(u => u.Id == ddlUsuario.SelectedIndex);


                var prestamos = context.Prestamos
                    .Where(p => p.Usuario.Id == usuarioSel.Id)
                    .Select(p => new
                    {
                        Id=p.Id,
                        ISBN = p.Libro.ISBN,
                        Autor = p.Libro.Autor.Nombre,
                        Libro = p.Libro.Titulo,
                        FechaEntrega = p.FechaPrestamo,
                        FechaDevolucion = p.FechaDevolucion
                    }).ToList();

                GvLibro.DataSource = prestamos;
                GvLibro.DataBind();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ddlUsuario.SelectedIndex = 0;
            ddlAutor.SelectedIndex = 0;
            ddlLibro.SelectedIndex = 0;
            TbHoy.Text = "";
            TbDevolver.Text = "";
            GvLibro.DataSource = "";
            GvLibro.DataBind();
        }
    }
}