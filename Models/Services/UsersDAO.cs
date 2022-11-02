// Use Documentation above then adjust for user object that we are working with below.
// https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.parameters?view=dotnet-plat-ext-7.0

namespace WebApp.Models.Services
{
    using System.Data.SqlClient;

    /// <summary>
    /// Data Access Object (DAO) pattern for users database.
    /// </summary>
    public class UsersDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// Does the database searching.
        /// </summary>
        /// <param name="user">UserModel object.</param>
        /// <returns>Boolean value of success (true if found in DB).</returns>
        public bool FindUserByNameAndPassword(UserModel user)
        {
            bool success = false; // assume there is no connection

            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @Username AND password = @password";

            // Connect to the database with SqlConnection (an object defined in your library)
            // Using statement allows us to generate a block of code that will use this connection and automatically terminate the connection after the block is finished so this keeps the database connection closed in case we need to use it with other applications.
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // SqlCommand is a predefined object, a constructor with 2 parameters.
                // It asks for the Sql statement you want to send and the connection that's been connected to.
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // Need to define the two different parameters in our prepared statement.
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                // Try/Catch block to prevent errors from crashing our application.
                try
                {
                    connection.Open(); // Initiate a conection to the database.
                    SqlDataReader reader = command.ExecuteReader(); // new SqlDataReader object.

                    // If the reader has rows then we know we got something back from the database.
                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            // Return true if found in db.
            // Produces our result. Produces a return statement so it's going to be returned as a success.
            // Success is set to false by default and if there are any rows found success is switched to true.
            // So when we return success, we are returning a true or false value.
            return success;
        }
    }
}
