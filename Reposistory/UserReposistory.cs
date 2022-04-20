using Api1.IReposistory;
using Api1.Models;
using System.Linq;

namespace Api1.Reposistory
{
    public class UserReposistory:IUserReposistory
    {
        private readonly Context _dbContext;

        public UserReposistory(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public User Login(string email, string password)
        {
           User user=  _dbContext.User.Where(x => x.Email.Equals(email) && x.Password.Equals(password)).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public User RegisterByAdmin(User user)
        {
            user.Roles = "Admin";
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
            return user;

        }

        public User RegisterByUser(User user)
        {
            user.Roles = "User";
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
            return user;
        }
    }
}
