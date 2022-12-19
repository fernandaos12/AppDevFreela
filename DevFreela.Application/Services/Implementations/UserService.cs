using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System.Linq;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewUserInputModel inputModel)
        {
            var userproject = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);
            _dbContext.Users.Add(userproject);
            _dbContext.SaveChanges();
            return userproject.id;
       
        }

         public UserViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(p => p.id == id);
            var userviewmodel = new UserViewModel(
                user.FullName,
                user.Email,
                user.BirthDate
               );

            return userviewmodel;
        }
        public void Login(LoginInputModel inputModel)
        {
           var logininput = new Login(inputModel.Username, inputModel.Email, inputModel.Password);
            _dbContext.UserLogin.Add(logininput);

        }
    }
}
