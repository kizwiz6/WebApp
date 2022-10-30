namespace WebApp.Models
{
    /// <summary>
    /// Class model for handling the different users.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the UserName details.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Password details.
        /// </summary>
        public string Password { get; set; }
    }
}
