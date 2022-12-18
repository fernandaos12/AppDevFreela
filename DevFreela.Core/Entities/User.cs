using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;

            CreatedAt = DateTime.Now;
            Active = true;
            Skills = new List<UserSkill>();
            OwnerProject = new List<Project>();
            FreelanceProject = new List<Project>();
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public Boolean Active { get; set; }
        public Skill Skill { get; set; }

        public List<UserSkill> Skills { get; set; }
        public List<Project> OwnerProject { get; set; }
        public List<Project> FreelanceProject { get; set; }
        public List<ProjectComment> Comments { get; set; }
        
    }
}
