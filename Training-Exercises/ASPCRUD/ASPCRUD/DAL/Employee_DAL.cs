using ASPCRUD.Models;
using Microsoft.CodeAnalysis;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ASPCRUD.DAL
{
    public class Employee_DAL
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;

        public static IConfiguration configuration { get; set; }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configuration = builder.Build();
            return configuration.GetConnectionString("DefaultConnection");
        }

        // Get all employees
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employeeList = new List<Employee>();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "SP_GetAllEmployee";

                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();

                while (dr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeId = Convert.ToInt32(dr["employee_id"]);
                    employee.FirstName = dr["first_name"].ToString();
                    employee.LastName = dr["last_name"].ToString();
                    employee.DateOfBirth = Convert.ToDateTime(dr["date_of_birth"]).Date;
                    employee.Email = dr["Email"].ToString();
                    employee.Salary = Convert.ToDouble(dr["salary"]);
                    employeeList.Add(employee);
                }
                _connection.Close();
            }
            return employeeList;

        }

        // insert/Add employee
        public bool InsertEmployee(Employee employee)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "SP_AddEmployee";
                _command.Parameters.AddWithValue("@first_name", employee.FirstName);
                _command.Parameters.AddWithValue("@last_name", employee.LastName);
                _command.Parameters.AddWithValue("@date_of_birth", employee.DateOfBirth);
                _command.Parameters.AddWithValue("@email", employee.Email);
                _command.Parameters.AddWithValue("@salary", employee.Salary);
                _connection.Open();
                _command.ExecuteNonQuery();
                _connection.Close();
            }
            return true;
        }

        //GetEmployeeById
        public Employee GetEmployeeById(int employeeId)
        {
            Employee employee = new Employee();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "SP_GetEmployeeById";
                _command.Parameters.AddWithValue("@employee_id", employeeId);

                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();

                while (dr.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(dr["employee_id"]);
                    employee.FirstName = dr["first_name"].ToString();
                    employee.LastName = dr["last_name"].ToString();
                    employee.DateOfBirth = Convert.ToDateTime(dr["date_of_birth"]).Date;
                    employee.Email = dr["Email"].ToString();
                    employee.Salary = Convert.ToDouble(dr["salary"]);
                }
                _connection.Close();
            }
            return employee;

        }


        //Update employee

        public bool Update(Employee employee)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "SP_UpdateEmployee";
                _command.Parameters.AddWithValue("@employee_id", employee.EmployeeId);
                _command.Parameters.AddWithValue("@first_name", employee.FirstName);
                _command.Parameters.AddWithValue("@last_name", employee.LastName);
                _command.Parameters.AddWithValue("@date_of_birth", employee.DateOfBirth);
                _command.Parameters.AddWithValue("@email", employee.Email);
                _command.Parameters.AddWithValue("@salary", employee.Salary);
                _connection.Open();
                _command.ExecuteNonQuery();
                _connection.Close();
            }
            return true;
        }
        public bool DeletEmployee(int EmployeeId)
        {
            int deletedRowCount = 0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "SP_DeleteEmployee";
                _command.Parameters.AddWithValue("@employee_id", EmployeeId);
                _connection.Open();
                deletedRowCount = _command.ExecuteNonQuery();
                _connection.Close();
            }
            return true;

        }
    }
}
