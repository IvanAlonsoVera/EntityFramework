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
                
            }
            using (var context = new DbContext.Context())
            {

            }
        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlAutor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLibro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvLibro_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}