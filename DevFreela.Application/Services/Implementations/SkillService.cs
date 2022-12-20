using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Application.Services.Implementations
{
    internal class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionstring;

        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionstring = configuration.GetConnectionString("DevFreelaCs");

        }
        public List<SkillViewModel> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionstring))
            {
                sqlConnection.Open();
                var script = "SELECT Id, Description FROM Skills";
                return sqlConnection.Query<SkillViewModel>(script).ToList();
            }
            //var skill = _dbContext.Skills;
            //var skillviewmodel = skill.Select(s => new SkillViewModel(s.id, s.Description)).ToList();
            //return skillviewmodel;
        }
    }
}
