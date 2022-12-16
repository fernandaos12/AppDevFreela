using System;

namespace DevFreela.Core.Entities
{
    public class Login : BaseEntity
    {
        public Login(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
    }
}
