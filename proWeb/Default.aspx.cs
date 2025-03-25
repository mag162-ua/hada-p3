﻿using System;
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
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }
        private void CargarProductos()
        {

            string connStr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
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

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(Code.Text) || Code.Text.Length > 16)
            {
                LblInfo.Text += "Code is required \n";
                return false;
            }

            if (Code.Text.Length > 16)
            {
                LblInfo.Text += "Code must be 1 - 16 alphanumeric characters \n";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Name.Text))
            {
                LblInfo.Text += "Name is required \n";
                return false;
            }

            if(Name.Text.Length > 32)
            {
                LblInfo.Text += "Name must be 1- 32 letter characters \n";
                return false;
            }

            if (!int.TryParse(Amount.Text, out int amount2))
            {
                LblInfo.Text += "Amount must be a number \n";
                return false;
            }

            if (!int.TryParse(Amount.Text, out int amount) && (amount < 0 || amount > 9999))
            {
                LblInfo.Text += "Amount must be 0 - 9999 \n";
                return false;
            }

            if (!decimal.TryParse(Price.Text, out decimal price2))
            {
                LblInfo.Text += "Price must be a number \n";
                return false;
            }

            if (!decimal.TryParse(Price.Text, out decimal price) || price < 0 || price > 9999.99m)
                LblInfo.Text += "Price must be 0 - 9999.99 \n";
            return false;

            if (!DateTime.TryParseExact(CreationDate.Text, "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime _))
            {
                LblInfo.Text += "Creation date must be a valid date \n";
                return false;
            }

            if (Category.SelectedValue != "0" && Category.SelectedValue != "1" && Category.SelectedValue != "2" && Category.SelectedValue != "3")
            {
                LblInfo.Text += "Category must be a valid category \n";
                return false;
            }

            return true;
        }

        protected void ButtonCreate_Action(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                ENProduct nw_product_EN = new ENProduct(sender);
                CADProduct nw_product_CAD = new CADProduct();
                nw_product_CAD.create(nw_product_EN);
                LblInfo.Text = "Product created successfully";
            }
            else
            {
                LblInfo.Text += "Error: Invalid input";
            }

        }
        protected void ButtonDelete_Action(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Code.Text))
            {
                ENProduct nw_product_EN = new ENProduct(sender);
                CADProduct nw_product_CAD = new CADProduct();
                nw_product_CAD.delete(nw_product_EN);
                LblInfo.Text = "Product deleted successfully";
            }
            else
            {
                LblInfo.Text += "Error: Invalid input";
            }

        }
        protected void ButtonUpdate_Action(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                ENProduct nw_product_EN = new ENProduct(sender);
                CADProduct nw_product_CAD = new CADProduct();
                nw_product_CAD.update(nw_product_EN);
                LblInfo.Text = "Product updated successfully";
            }
            else
            {
                LblInfo.Text += "Error: Invalid input";
            }

        }
        protected void ButtonRead_Action(object sender, EventArgs e)
        {
            ENProduct nw_product_EN = new ENProduct(sender);
            CADProduct nw_product_CAD = new CADProduct();
            nw_product_CAD.read(nw_product_EN);
        }
        protected void ButtonRF_Action(object sender, EventArgs e)
        {
            ENProduct nw_product_EN = new ENProduct(sender);
            CADProduct nw_product_CAD = new CADProduct();
            nw_product_CAD.readFirst(nw_product_EN);
        }

        protected void ButtonPrev_Action(object sender, EventArgs e)
        {
            ENProduct nw_product_EN = new ENProduct(sender);
            CADProduct nw_product_CAD = new CADProduct();
            nw_product_CAD.readPrev(nw_product_EN);
        }
        protected void ButtonNext_Action(object sender, EventArgs e)
        {
            ENProduct nw_product_EN = new ENProduct(sender);
            CADProduct nw_product_CAD = new CADProduct();
            nw_product_CAD.readNext(nw_product_EN);
        }
    }
}