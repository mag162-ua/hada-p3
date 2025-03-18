using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.ComponentModel;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarProductos();
            }
        }
        private void CargarProductos()
        {
            string connStr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using(SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT name FROM Categories";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Category.DataSource = reader;
                Category.DataTextField = "name";
                Category.DataValueField = "id";
                Category.DataBind();
                reader.Close();
            }
            Category.Items.Insert(0, new ListItem("Select a category", "0"));

        }

        protected void ButtonCreate_Action(object sender, EventArgs e)
        {
            string ProductoSeleccionado = Category.SelectedItem.Text;
            string idSeleccionado = Category.SelectedValue;
            
        }
}