using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserRegistration.Models;

namespace UserRegistration.Repository
{
	public class UserRepository
	{
		private readonly SqlConnection sqlConnection;

		public UserRepository()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["connectdatabase"].ToString();
			sqlConnection = new SqlConnection(connectionString);
		}


		//Add user
		public bool AddUser(User user)
		{
			using (SqlCommand command = new SqlCommand("SP_InsertUser", sqlConnection))
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@userFirstName", user.UserFirstName);
				command.Parameters.AddWithValue("@userLastName", user.UserLastName);
				command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth.ToString());
				command.Parameters.AddWithValue("@gender", user.Gender);
				command.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
				command.Parameters.AddWithValue("@emailAddress", user.EmailAddress);
				command.Parameters.AddWithValue("@address", user.Address);
				command.Parameters.AddWithValue("@state", user.State);
				command.Parameters.AddWithValue("@city", user.City);
				command.Parameters.AddWithValue("@username", user.Username);
				command.Parameters.AddWithValue("@password", user.Password);

				sqlConnection.Open();
				int rowsAffected = command.ExecuteNonQuery();
				sqlConnection.Close();
                return rowsAffected > 0;
            }
		}

		//View Users

		public List<User> GetAllUsers()
		{
			List<User> userList = new List<User>();
			using (SqlCommand command = new SqlCommand("SP_GetAllUsers", sqlConnection))
			{
				command.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter sqlDA = new SqlDataAdapter(command);
				DataTable dtUsers = new DataTable();

				sqlConnection.Open();
				sqlDA.Fill(dtUsers);
				sqlConnection.Close();

				foreach (DataRow dr in dtUsers.Rows)
				{
					userList.Add(new User
					{
                        UserId = Convert.ToInt32(dr["UserId"]),
						UserFirstName = dr["UserFirstName"].ToString(),
						UserLastName = dr["UserLastName"].ToString(),
                        DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString()),
                        Gender = dr["Gender"].ToString(),
						PhoneNumber = dr["PhoneNumber"].ToString(),
						EmailAddress = dr["EmailAddress"].ToString(),
						Address = dr["Address"].ToString(),
						State = dr["State"].ToString(),
						City = dr["City"].ToString(),
						Username = dr["Username"].ToString()
						//Password = dr["Password"].ToString()
                    });
				}

			}
			return userList;
        }

        //Get User By Id
        public List<User> GetUserById(int UserId)
         {
            List<User> userList = new List<User>();
            using (SqlCommand command = new SqlCommand("SP_GetUserById", sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = UserId;
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtUsers = new DataTable();

                sqlConnection.Open();
                sqlDA.Fill(dtUsers);
                sqlConnection.Close();

                foreach (DataRow dr in dtUsers.Rows)
                {
                    userList.Add(new User
                    {
                        UserId = Convert.ToInt32(dr["UserId"]),
                        UserFirstName = dr["UserFirstName"].ToString(),
                        UserLastName = dr["UserLastName"].ToString(),
                        DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString()),
                        Gender = dr["Gender"].ToString(),
                        PhoneNumber = dr["PhoneNumber"].ToString(),
                        EmailAddress = dr["EmailAddress"].ToString(),
                        Address = dr["Address"].ToString(),
                        State = dr["State"].ToString(),
                        City = dr["City"].ToString(),
                        Username = dr["Username"].ToString(),
                        //Password = dr["Password"].ToString()
                    });
                }

            }
            return userList;
        }
        //Update user

        public bool UpdateUser(User user)
        {
            int i = 0;
            using (SqlCommand command = new SqlCommand("SP_UpdateUser", sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userId", user.UserId);
                command.Parameters.AddWithValue("@userFirstName", user.UserFirstName);
                command.Parameters.AddWithValue("@userLastName", user.UserLastName);
                command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth.ToString());
                command.Parameters.AddWithValue("@gender", user.Gender);
                command.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@emailAddress", user.EmailAddress);
                command.Parameters.AddWithValue("@address", user.Address);
                command.Parameters.AddWithValue("@state", user.State);
                command.Parameters.AddWithValue("@city", user.City);
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@password", user.Password);

                sqlConnection.Open();
                i = command.ExecuteNonQuery();
                sqlConnection.Close();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Delete User

        public string DeleteUser(int UserId)
        {
            string result = "";
            using (SqlCommand command = new SqlCommand("SP_DeleteUser", sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userId", UserId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return result;
        }

    }
}