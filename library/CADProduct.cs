using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace library
{
    public class CADProduct
    {

        private string constring;

        public CADProduct()
        {
            this.constring = "Server=TU_SERVIDOR;Database=TU_BASE_DATOS;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;";
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
        }

        public bool Create(ENProduct en)
        {

            using (SqlConnection conn = new SqlConnection(constring))
            {
                string query = "insert into Products values "+ en.Name +","+ en.Code +"," + en.Amount +"," + en.Price +","+ en.Category +","+ en.CreationDate ;

                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.Parameters.AddWithValue("@Nombre", nombre);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    Console.WriteLine($"{rowsAffected} fila(s) insertada(s).");
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

        public bool Update(ENProduct en)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                string query = "update Products SET NOMBRE=" + en.Name + ",CODE=" + en.Code + ",AMOUNT=" + en.Amount + ",PRICE=" + en.Price + ",CATEGORY=" + en.Category + ",CREATION=" + en.CreationDate+
                    "WHERE NOMBRE=" + en.Name + ",CODE=" + en.Code + ",AMOUNT=" + en.Amount + ",PRICE=" + en.Price + ",CATEGORY=" + en.Category + ",CREATION=" + en.CreationDate;

                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.Parameters.AddWithValue("@Nombre", nombre);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    Console.WriteLine($"{rowsAffected} fila(s) insertada(s).");
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

        public bool Delete(ENProduct en)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                string query = "DELETE FROM Productos WHERE NOMBRE=" + en.Name + ",CODE=" + en.Code + ",AMOUNT=" + en.Amount + ",PRICE=" + en.Price + ",CATEGORY=" + en.Category + ",CREATION=" + en.CreationDate;

                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.Parameters.AddWithValue("@Nombre", nombre);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    Console.WriteLine($"{rowsAffected} fila(s) insertada(s).");
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

        public bool Read(ENProduct en)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                string query = "SELECT * FROM Productos WHERE NOMBRE =" + en.Name+ ",CODE=" + en.Code + ",AMOUNT=" + en.Amount + ",PRICE=" + en.Price + ",CATEGORY=" + en.Category + ",CREATION=" + en.CreationDate;

                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.Parameters.AddWithValue("@Nombre", nombre);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    Console.WriteLine($"{rowsAffected} fila(s) insertada(s).");
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

        public bool ReadFirst(ENProduct en)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                string query = "SELECT * FROM Productos WHERE ID = 1";

                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.Parameters.AddWithValue("@Nombre", nombre);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    Console.WriteLine($"{rowsAffected} fila(s) insertada(s).");
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

        public bool ReadNext(ENProduct en)
        {
            string query = "SELECT * FROM Productos WHERE ID = (SELECT ID+1 FROM Productos WHERE NOMBRE =" + en.Name + ",CODE=" + en.Code + ",AMOUNT=" + en.Amount + ",PRICE=" + en.Price + ",CATEGORY=" + en.Category + ",CREATION=" + en.CreationDate+")";

            using (SqlConnection conn = new SqlConnection(constring))
            {
                               conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.Parameters.AddWithValue("@Nombre", nombre);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    Console.WriteLine($"{rowsAffected} fila(s) insertada(s).");
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

        public bool ReadPrev(ENProduct en)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                string query = "SELECT * FROM Productos WHERE ID = (SELECT ID-1 FROM Productos WHERE NOMBRE =" + en.Name + ",CODE=" + en.Code + ",AMOUNT=" + en.Amount + ",PRICE=" + en.Price + ",CATEGORY=" + en.Category + ",CREATION=" + en.CreationDate+")";


                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.Parameters.AddWithValue("@Nombre", nombre);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    Console.WriteLine($"{rowsAffected} fila(s) insertada(s).");
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

    }
}
