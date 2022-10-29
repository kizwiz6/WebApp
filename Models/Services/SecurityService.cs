﻿namespace WebApp.Models.Services
{
    /// <summary>
    /// Authenticate teh user.
    /// </summary>
    public class SecurityService
    {
        List<UserModel> knownUsers = new List<UserModel>();

        public SecurityService()
        {
            knownUsers.Add(new UserModel { Id = 0, UserName = "Kieran", Password = "Emery" });
            knownUsers.Add(new UserModel { Id = 1, UserName = "BillGates", Password = "bigbucks" });
            knownUsers.Add(new UserModel { Id = 2, UserName = "MarieCurie", Password = "radioactive" });
            knownUsers.Add(new UserModel { Id = 3, UserName = "WatsonCrick", Password = "dna" });
            knownUsers.Add(new UserModel { Id = 4, UserName = "AlexanderFlemming", Password = "penicillin" });
        }

        /// <summary>
        /// Method to find out if this is a valid user login.
        /// Accepts a user object.
        /// </summary>
        /// <returns>Boolean return type</returns>
        public bool IsValid(UserModel user)
        {
            // Return true if user is found in the list.
            // For each item x in the list is there a match
            return knownUsers.Any(x => x.UserName == user.UserName && x.Password == user.Password);
        }
    }
}