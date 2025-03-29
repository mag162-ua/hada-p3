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
using System.Runtime.Remoting.Messaging;

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
            ENCategory cat = new ENCategory();
            List<ENCategory> cats = cat.ReadAll();

            Category.Items.Clear();
            if (cats.Count == 0)
            {
                Category.Items.Add(new ListItem("No hay categorías disponibles", "0"));
            }
            else
            {
                foreach (ENCategory read_cat in cats)
                {
                    Category.Items.Add(new ListItem(read_cat.Name));
                }
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
            if (Category.SelectedIndex+1 < 1 || Category.SelectedIndex+1 > 4)
                return false;

            return true;
        }

        private bool ProductExists(ENProduct product)
        {
            ENProduct product_comp = new ENProduct(product.Code,product.Name,product.Amount,product.Price,product.Category,product.CreationDate);
            if (product_comp.Read() == true)
                return true;

            return false;
        }

        protected void ButtonCreate_Action(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                int amount = int.Parse(Amount.Text);
                float price = float.Parse(Price.Text);
                DateTime creationDate = DateTime.Parse(CreationDate.Text); 

                ENProduct nw_product_EN = new ENProduct(Code.Text,Name.Text,amount,price,Category.SelectedIndex+1,creationDate);

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
            if (!string.IsNullOrWhiteSpace(Code.Text) && Code.Text.All(char.IsLetterOrDigit) && !(Code.Text.Length > 16))
            {
                int amount = 0;
                float price = 0;
                DateTime creationDate = DateTime.Now;

                ENProduct nw_product_EN = new ENProduct(Code.Text, Name.Text, amount, price, Category.SelectedIndex+1, creationDate);

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
                DateTime creationDate = DateTime.Parse(CreationDate.Text);

                ENProduct nw_product_EN = new ENProduct(Code.Text, Name.Text, amount, price, Category.SelectedIndex + 1, creationDate);
                System.Diagnostics.Debug.WriteLine(nw_product_EN.Name);
                if (!ProductExists(nw_product_EN))
                {
                    LblInfo.Text = "Error: Product do not exists";
                    return;
                }
                System.Diagnostics.Debug.WriteLine(nw_product_EN.Name);
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
            if (!string.IsNullOrWhiteSpace(Code.Text) && Code.Text.All(char.IsLetterOrDigit) && !(Code.Text.Length > 16))
            {
                int amount = 0;
                float price = 0;
                DateTime creationDate = DateTime.Now;

                ENProduct nw_product_EN = new ENProduct(Code.Text, Name.Text, amount, price, Category.SelectedIndex+1, creationDate);
                if (!ProductExists(nw_product_EN))
                {
                    LblInfo.Text = "Error: Product do not exists";
                    return;
                }
                nw_product_EN.Read();
                Code.Text = nw_product_EN.Code;
                Name.Text = nw_product_EN.Name;
                Amount.Text = nw_product_EN.Amount.ToString();
                Category.SelectedIndex = nw_product_EN.Category-1;
                Price.Text = nw_product_EN.Price.ToString("F2");
                CreationDate.Text = nw_product_EN.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                LblInfo.Text = "Product readed successfully";
            }
            else
            {
                LblInfo.Text = "Error: Invalid input";
            }
           
        }
        protected void ButtonRF_Action(object sender, EventArgs e)
        {
            int amount = 0;
            float price = 0;
            DateTime creationDate = DateTime.Now;

            ENProduct nw_product_EN = new ENProduct(Code.Text, Name.Text, amount, price, Category.SelectedIndex+1, creationDate);
            /*if (!ProductExists(nw_product_EN))
            {
                LblInfo.Text = "Error: Product do not exists";
                return;
            }*/
            if (!nw_product_EN.ReadFirst())
            {
                LblInfo.Text = "Error: Invalid input";
                return;
            }
            Code.Text = nw_product_EN.Code;
            Name.Text = nw_product_EN.Name;
            Amount.Text = nw_product_EN.Amount.ToString();
            Category.SelectedIndex = nw_product_EN.Category - 1;
            Price.Text = nw_product_EN.Price.ToString("F2");
            CreationDate.Text = nw_product_EN.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
            LblInfo.Text = "Product readed successfully";


        }

        protected void ButtonPrev_Action(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Code.Text) && Code.Text.All(char.IsLetterOrDigit) && !(Code.Text.Length > 16))
            {
                int amount = 0;
                float price = 0;
                DateTime creationDate = DateTime.Now;

                ENProduct nw_product_EN = new ENProduct(Code.Text, Name.Text, amount, price, Category.SelectedIndex+1, creationDate);
                if (!ProductExists(nw_product_EN))
                {
                    LblInfo.Text = "Error: Product do not exists";
                    return;
                }
                nw_product_EN.ReadPrev();
                Code.Text = nw_product_EN.Code;
                Name.Text = nw_product_EN.Name;
                Amount.Text = nw_product_EN.Amount.ToString();
                Category.SelectedIndex = nw_product_EN.Category - 1;
                Price.Text = nw_product_EN.Price.ToString("F2");
                CreationDate.Text = nw_product_EN.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                LblInfo.Text = "Product readed successfully";
            }
            else
            {
                LblInfo.Text = "Error: Invalid input";
            }

        }
        protected void ButtonNext_Action(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Code.Text) && Code.Text.All(char.IsLetterOrDigit) && !(Code.Text.Length > 16))
            {
                int amount = 0;
                float price = 0;
                DateTime creationDate = DateTime.Now;

                ENProduct nw_product_EN = new ENProduct(Code.Text, Name.Text, amount, price, Category.SelectedIndex+1, creationDate);
                if (!ProductExists(nw_product_EN))
                {
                    LblInfo.Text = "Error: Product do not exists";
                    return;
                }
                nw_product_EN.ReadNext();
                Code.Text = nw_product_EN.Code;
                Name.Text = nw_product_EN.Name;
                Amount.Text = nw_product_EN.Amount.ToString();
                Category.SelectedIndex = nw_product_EN.Category - 1;
                Price.Text = nw_product_EN.Price.ToString("F2");
                CreationDate.Text = nw_product_EN.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                LblInfo.Text = "Product readed successfully";
            }
            else
            {
                LblInfo.Text = "Error: Invalid input";
            }

        }
    }
}