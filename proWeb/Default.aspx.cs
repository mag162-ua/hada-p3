using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.ComponentModel;
using library;
using System.Diagnostics;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategory();
            }
        }
        private void CargarCategory()
        {
            ENCategory cat= new ENCategory();
            List<ENCategory> cats = cat.ReadAll();

            Category.Items.Clear();
            
            foreach (ENCategory read_cat in cats)
            {
                Category.Items.Add(new ListItem(read_cat.Name));
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(Code.Text) || Code.Text.Length > 16)
                return false;
            if (string.IsNullOrWhiteSpace(Name.Text) || Name.Text.Length > 32)
                return false;
            if (!int.TryParse(Amount.Text, out int amount) || amount < 0 || amount > 9999)
                return false;
            if (!decimal.TryParse(Price.Text, out decimal price) || price < 0 || price > 9999.99m)
                return false;
            if (!DateTime.TryParseExact(CreationDate.Text, "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime _))
                return false;
            if (Category.SelectedValue != "0" && Category.SelectedValue != "1" && Category.SelectedValue != "2" && Category.SelectedValue != "3")
                return false;

            return true;
        }

        private bool ProductExists(ENProduct product)
        {
            return product.Read();
        }

        protected void ButtonCreate_Action(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                int amount = int.Parse(Amount.Text);
                float price = float.Parse(Price.Text);
                int category = int.Parse(Category.SelectedValue);
                DateTime creationDate = DateTime.Parse(CreationDate.Text); 

                ENProduct nw_product_EN = new ENProduct(Code.Text,Name.Text,amount,price,category,creationDate);

                if (ProductExists(nw_product_EN))
                {
                    LblInfo.Text = "Error: Product already exists";
                    return;
                }
                nw_product_EN.Create();
                LblInfo.Text = "Product created successfully";
            }
            else
            {
                LblInfo.Text = "Error: Invalid input";
            }

        }
        protected void ButtonDelete_Action(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Code.Text))
            {
                int amount = int.Parse(Amount.Text);
                float price = float.Parse(Price.Text);
                int category = int.Parse(Category.SelectedValue);
                DateTime creationDate = DateTime.Parse(CreationDate.Text);

                ENProduct nw_product_EN = new ENProduct(Code.Text, Name.Text, amount, price, category, creationDate);

                if (!ProductExists(nw_product_EN))
                {
                    LblInfo.Text = "Error: Product do not exists";
                    return;
                }
                nw_product_EN.Delete();
                LblInfo.Text = "Product deleted successfully";
            }
            else
            {
                LblInfo.Text = "Error: Invalid input";
            }

        }
        protected void ButtonUpdate_Action(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                int amount = int.Parse(Amount.Text);
                float price = float.Parse(Price.Text);
                int category = int.Parse(Category.SelectedValue);
                DateTime creationDate = DateTime.Parse(CreationDate.Text);

                ENProduct nw_product_EN = new ENProduct(Code.Text, Name.Text, amount, price, category, creationDate);

                if (!ProductExists(nw_product_EN))
                {
                    LblInfo.Text = "Error: Product do not exists";
                    return;
                }
                nw_product_EN.Update();
                LblInfo.Text = "Product updated successfully";
            }
            else
            {
                LblInfo.Text = "Error: Invalid input";
            }

        }
        protected void ButtonRead_Action(object sender, EventArgs e)
        {
            int amount = int.Parse(Amount.Text);
            float price = float.Parse(Price.Text);
            int category = int.Parse(Category.SelectedValue);
            DateTime creationDate = DateTime.Parse(CreationDate.Text);

            ENProduct nw_product_EN = new ENProduct(Code.Text, Name.Text, amount, price, category, creationDate);
            nw_product_EN.Read();
        }
        protected void ButtonRF_Action(object sender, EventArgs e)
        {
            int amount = int.Parse(Amount.Text);
            float price = float.Parse(Price.Text);
            int category = int.Parse(Category.SelectedValue);
            DateTime creationDate = DateTime.Parse(CreationDate.Text);

            ENProduct nw_product_EN = new ENProduct(Code.Text, Name.Text, amount, price, category, creationDate);
            nw_product_EN.ReadFirst();
        }

        protected void ButtonPrev_Action(object sender, EventArgs e)
        {
            int amount = int.Parse(Amount.Text);
            float price = float.Parse(Price.Text);
            int category = int.Parse(Category.SelectedValue);
            DateTime creationDate = DateTime.Parse(CreationDate.Text);

            ENProduct nw_product_EN = new ENProduct(Code.Text, Name.Text, amount, price, category, creationDate);
            nw_product_EN.ReadPrev();
        }
        protected void ButtonNext_Action(object sender, EventArgs e)
        {
            int amount = int.Parse(Amount.Text);
            float price = float.Parse(Price.Text);
            int category = int.Parse(Category.SelectedValue);
            DateTime creationDate = DateTime.Parse(CreationDate.Text);

            ENProduct nw_product_EN = new ENProduct(Code.Text, Name.Text, amount, price, category, creationDate);
            nw_product_EN.ReadNext();
        }
    }
}