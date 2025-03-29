using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Web;
using System.Configuration.Provider;


namespace library
{
    public class CADCategory
    {
        private string constring;

        public CADCategory()
        {
            this.constring =ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            /*@"Server=(LocalDB)\MSSQLLocalDB;
                   AttachDbFilename=|DataDirectory|\Database.mdf;
                   Integrated Security=True;";*/
        }

        // Método para leer una categoría específica
        public bool Read(ENCategory en)
        {
            bool found = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    string query = "SELECT Name FROM Categories WHERE Id = @Name";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", en.Name);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.Name = reader["Name"].ToString();
                                found = true;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL en Read: {ex.Message}");
            }
            return found;
        }

        // Método para obtener todas las categorías
        public List<ENCategory> ReadAll()
        {
            List<ENCategory> categories = new List<ENCategory>();

            try
            {
                //SqlConnection conn = new SqlConnection(constring);
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    //Console.WriteLine("a");
                    conn.Open();
                    string query = "SELECT * FROM Categories";
                //SqlCommand cmd = new SqlCommand(query, conn);
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //categories.Add(new ENCategory(reader["Name"].ToString()));
                                string name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader["Name"].ToString();
                                categories.Add(new ENCategory(name));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
               
                Console.WriteLine($"Error SQL en ReadAll: {ex.Message}");
                //throw new Exception("Error al leer las categorías desde la base de datos.", ex);
                //throw new Exception($"Error en ReadAll: {ex.Message} \nStackTrace: {ex.StackTrace}", ex);
            }

            return categories;
        }
    }
}
