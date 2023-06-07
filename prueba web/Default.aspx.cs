using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using System.Collections.Generic;

namespace prueba_web
{
    public partial class _Default : Page
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarTabla();
            }
        }

        public void MostrarTabla()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM nombre", conexion);
            da.Fill(ds, "tabla");
            SqlCommand cmd = new SqlCommand();
            gvdNombre.DataSource = ds.Tables["tabla"];
            gvdNombre.DataBind();
        }

        public void Acciones(string consulta,string idNombre)
        {
            string funcion="";
            if (consulta == "Alta")
            {
                funcion = "INSERT INTO nombre (nombre,apellido) VALUES ('" + txtnombre.Text + "','" + txtapellido.Text + "');";
               
            }
            else if (consulta=="Modificar")
            {
                funcion = "UPDATE nombre SET nombre = '" + txtnombre.Text + "', apellido = '" + txtapellido.Text + "' WHERE id = " + idNombre;
            }
            else if (consulta=="baja")
            {
               funcion= "DELETE FROM nombre WHERE id=" + int.Parse(idNombre);
            }

            SqlCommand comando = new SqlCommand(funcion, conexion);
            conexion.Open();
            comando.ExecuteNonQuery();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlDatosNombre.Visible = false;
            pnlAlta.Visible = true;
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;
          
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            pnlDatosNombre.Visible = true;
            pnlAlta.Visible = false;
            Acciones("Alta","");
            MostrarTabla();
        }

        protected void gvdNombre_RowDeleted(object sender, GridViewDeleteEventArgs e)
        {
            Acciones("baja", gvdNombre.DataKeys[e.RowIndex].Value.ToString());
            MostrarTabla();
        }

        protected void linkActualizar_Click(object sender, EventArgs e)
        {
            pnlAlta.Visible = true;
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
            
            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
            gvdNombre.SelectedIndex = row.RowIndex;
            lblIdAlumno.Text = row.Cells[0].Text;
            txtnombre.Text = row.Cells[1].Text;
            txtapellido.Text = row.Cells[2].Text;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            pnlAlta.Visible = false;
            pnlDatosNombre.Visible = true;
            Acciones("Modificar", lblIdAlumno.Text);
            lblIdAlumno.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            MostrarTabla();
        }
    }
}