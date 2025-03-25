using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlTypes;

namespace library
{
    public class CADProduct
    {

        private string constring;

        public CADProduct()
        {
            // this.constring = "Server=TU_SERVIDOR;Database=TU_BASE_DATOS;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;";
            this.constring = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            //SqlConnection conn = new SqlConnection(constring);
            //conn.Open();
        }

        public bool Create(ENProduct en)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(constring))
                {
                    string query = "INSERT INTO Products (Name, Code, Amount, Price, Category, CreationDate) VALUES (@Name, @Code, @Amount, @Price, @Category, @CreationDate)";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", en.Name);
                        cmd.Parameters.AddWithValue("@Code", en.Code);
                        cmd.Parameters.AddWithValue("@Amount", en.Amount);
                        cmd.Parameters.AddWithValue("@Price", en.Price);
                        cmd.Parameters.AddWithValue("@Category", en.Category);
                        cmd.Parameters.AddWithValue("@CreationDate", en.CreationDate);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        //Console.WriteLine($"{rowsAffected} fila(s) insertada(s).");
                        if (rowsAffected == 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL en Create: {ex.Message}");
                return false;
            }
        }

        public bool Update(ENProduct en)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(constring))
                {
                    string query = "UPDATE Products SET Name = @Name, Code = @Code, Amount = @Amount, Price = @Price, Category = @Category, CreationDate = @CreationDate WHERE Code = @Code";

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", en.Name);
                        cmd.Parameters.AddWithValue("@Code", en.Code);
                        cmd.Parameters.AddWithValue("@Amount", en.Amount);
                        cmd.Parameters.AddWithValue("@Price", en.Price);
                        cmd.Parameters.AddWithValue("@Category", en.Category);
                        cmd.Parameters.AddWithValue("@CreationDate", en.CreationDate);
                        //cmd.Parameters.AddWithValue("@ID", en.ID);
                        //cmd.Parameters.AddWithValue("@Nombre", nombre);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        //Console.WriteLine($"{rowsAffected} fila(s) insertada(s).");
                        if (rowsAffected == 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL en Update: {ex.Message}");
                return false;
            }
        }

        public bool Delete(ENProduct en)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(constring))
                {

                    string query = "DELETE FROM Products WHERE Code = @Code";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Code", en.Code);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        //Console.WriteLine($"{rowsAffected} fila(s) insertada(s).");
                        if (rowsAffected == 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL en Delete: {ex.Message}");
                return false;
            }
        }

        public bool Read(ENProduct en)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(constring))
                {
                    string query = "SELECT * FROM Products WHERE Code = @Code";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@Code", en.Code);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.Name = reader["Name"].ToString();
                                en.Amount = Convert.ToInt32(reader["Amount"]);
                                en.Price = Convert.ToSingle(reader["Price"]);
                                en.Category = Convert.ToInt32(reader["Category"]);
                                en.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                                return true;
                            }
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL en Read: {ex.Message}");
                return false;
            }
        }

        public bool ReadFirst(ENProduct en)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(constring))
                {
                    string query = "SELECT TOP 1 * FROM Products ORDER BY ID ASC";

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.Code = reader["Code"].ToString();
                                en.Name = reader["Name"].ToString();
                                en.Amount = Convert.ToInt32(reader["Amount"]);
                                en.Price = Convert.ToSingle(reader["Price"]);
                                en.Category = Convert.ToInt32(reader["Category"]);
                                en.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                                return true;
                            }
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL en ReadFirst: {ex.Message}");
                return false;
            }
        }

        public bool ReadNext(ENProduct en)
        {
            try
            {
                string query = "SELECT TOP 1 * FROM Products WHERE Code > @Code ORDER BY Code ASC";

                using (SqlConnection conn = new SqlConnection(constring))
                {

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Code", en.Code);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.Code = reader["Code"].ToString();
                                en.Name = reader["Name"].ToString();
                                en.Amount = Convert.ToInt32(reader["Amount"]);
                                en.Price = Convert.ToSingle(reader["Price"]);
                                en.Category = Convert.ToInt32(reader["Category"]);
                                en.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                                return true;
                            }
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL en ReadNext: {ex.Message}");
                return false;
            }
        }

        public bool ReadPrev(ENProduct en)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(constring))
                {
                    string query = "SELECT TOP 1 * FROM Products WHERE Code < @Code ORDER BY Code DESC";

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.Code = reader["Code"].ToString();
                                en.Name = reader["Name"].ToString();
                                en.Amount = Convert.ToInt32(reader["Amount"]);
                                en.Price = Convert.ToSingle(reader["Price"]);
                                en.Category = Convert.ToInt32(reader["Category"]);
                                en.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                                return true;
                            }
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL en ReadPrev: {ex.Message}");
                return false;
            }
        }

    }
}
