using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class NewUserInputModel
    {

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public Boolean Active { get; set; }

        public List<UserSkill> Skills { get; set; }
        public List<Project> OwnerProject { get; set; }
        public List<Project> FreelanceProject { get; set; }
    }
}
