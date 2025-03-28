using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.SqlTypes;


namespace library
{
    public class CADCategory
    {
        private string constring;

        public CADCategory()
        {
            this.constring = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
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
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    string query = "SELECT * FROM Categories";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new ENCategory(reader["Name"].ToString()));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL en ReadAll: {ex.Message}");
            }

            return categories;
        }
    }
}
