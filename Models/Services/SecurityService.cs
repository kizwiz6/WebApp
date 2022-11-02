namespace WebApp.Models.Services
{
    /// <summary>
    /// Authenticate the user.
    /// </summary>
    public class SecurityService
    {
        UsersDAO usersDAO = new UsersDAO();

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityService"/> class.
        /// </summary>
        public SecurityService()
        {
        }

        /// <summary>
        /// Method to find out if this is a valid user login.
        /// Accepts a user object.
        /// </summary>
        /// <returns>Boolean return type</returns>
        public bool IsValid(UserModel user)
        {
            return usersDAO.FindUserByNameAndPassword(user);

            // Return true if user is found in the list.
            // For each item x in the list is there a match
        }
    }
}
