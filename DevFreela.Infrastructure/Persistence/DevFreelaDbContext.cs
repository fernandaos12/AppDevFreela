using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
            new Project("Meu primeiro projeto ", "Minha descricao do projeto", 1, 1, 10000),
            new Project("Meu segundo projeto ", "Minha descricao do projeto", 2, 2, 20000)
            };
            Users = new List<User>
            { new User("Fernanda Oliveira", "fernandaos12@gmail.com", new DateTime(1983,6,30)),
             new User("Rafael Oliveira", "rafael@gmail.com", new DateTime(2017,2,25))
            };
            Skills = new List<Skill>
            { new Skill(".net Core"),
              new Skill("C#")
            };
        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
