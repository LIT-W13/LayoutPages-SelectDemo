using Microsoft.Data.SqlClient;

namespace WebApplication11.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class NorthwindDb
    {
        private string _connectionString;


        public NorthwindDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> GetProducts()
        {
            var connection = new SqlConnection(_connectionString);
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Products";
            connection.Open();
            var reader = cmd.ExecuteReader();
            var products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = (int)reader["ProductID"],
                    Name = (string)reader["ProductName"],
                    UnitPrice = (decimal)reader["UnitPrice"]
                });
            }

            return products;

        }
    }
}
