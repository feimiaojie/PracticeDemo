using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.DB
{
    public class StoreDB
    {
        private static string connectionString = Properties.Settings.Default.StoreDatabase;

        public static Product GetProduct(int ID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from Products where ProductId = @ProductId", con);
            cmd.Parameters.AddWithValue("@ProductId", ID);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    Product product = new Product((string)reader["ModelNumber"],
                        (string)reader["ModelName"],(decimal)reader["UnitCost"],(string)reader["Description"]);
                    return product;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                con.Close();
            }

        }

        public static List<Product> GetProducts()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from Products",con);
            List<Product> products = new List<Product>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product((string)reader["ModelNumber"],
                        (string)reader["ModelName"], (decimal)reader["UnitCost"], (string)reader["Description"]);
                    products.Add(product);
                }
            }
            finally
            {
                con.Close();
            }
            return products;
        }

    }
}
