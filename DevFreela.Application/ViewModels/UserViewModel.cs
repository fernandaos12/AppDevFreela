using DevFreela.Core.Entities;
using System;


namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
