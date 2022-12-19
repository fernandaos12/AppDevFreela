using System.Collections.Generic;
using System.Linq;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdCliente, inputModel.IdFreelancer, inputModel.TotalCoast);
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            return project.id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdUser, inputModel.IdProject);
            _dbContext.ProjectComments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.id == id);
            project.Cancel();
            _dbContext.SaveChanges();

        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.id == id);
            project.Finish();
            _dbContext.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;
            var projectsviewmodel = projects
                .Select(p => new ProjectViewModel(p.Title, p.CreatedAt))
                .ToList();
            return projectsviewmodel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p=> p.Cliente)
                .Include(p=> p.Freelancer)
                .SingleOrDefault(p => p.id == id);
 
            if (project == null) return null;

            var projectdetailsviewmodel = new ProjectDetailsViewModel(
                project.id,
                project.Title,
                project.Description,
                project.TotalCoast,
                project.CreatedAt,
                project.FinishedAt,
                project.Cliente.FullName,
                project.Freelancer.FullName
                );

            return projectdetailsviewmodel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.id == id);
            project.Start();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.id == inputModel.Id);
            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCoast);
            _dbContext.SaveChanges();
        }
    }
}
