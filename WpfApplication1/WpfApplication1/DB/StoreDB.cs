using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public static List<Category> GetCategoriesAndProducts()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from Categories", con);
            List<Category> categories = new List<Category>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int categoryId = (int) reader["CategoryId"];
                    ObservableCollection<Product> products = new ObservableCollection<Product>();
                    using (SqlCommand cmd2 = new SqlCommand("select * from Products where CategoryId = @CategoryId", con))
                    {
                        cmd2.Parameters.AddWithValue("@CategoryId", categoryId);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        
                        while (reader2.Read())
                        {
                            Product product = new Product((string)reader2["ModelNumber"],
                                (string)reader2["ModelName"], (decimal)reader2["UnitCost"], (string)reader2["Description"]);
                            products.Add(product);
                        }
                    }

                    Category category = new Category((string)reader["CategoryName"], products);
                    categories.Add(category);
                }
            }
            finally
            {
                con.Close();
            }
            return categories;
        }
    }
}
