using Microsoft.Data.SqlClient;

namespace WebApplication11.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Region { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    public class NorthwindDb
    {
        private string _connectionString;


        public NorthwindDb(string connectionString)
        {
            _connectionString = connectionString;
        }


        public List<Employee> GetAll()
        {
            var connection = new SqlConnection(_connectionString);
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Employees";
            connection.Open();
            var employees = new List<Employee>();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var employee = new Employee();
                employee.Id = (int)reader["EmployeeId"];
                employee.FirstName = (string)reader["FirstName"];
                employee.LastName = (string)reader["LastName"];
                employee.Region = reader.GetOrNull<string>("Region");
                employee.BirthDate = reader.GetOrNull<DateTime?>("BirthDate");
               
                employees.Add(employee);
            }

            return employees;
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
