﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels
{
    public class LoginInputModel
    {
        public LoginInputModel(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
