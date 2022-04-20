using Api1.Models;

namespace Api1.IReposistory
{
    public interface IUserReposistory
    {
     public User  RegisterByUser(User user); 
     public User RegisterByAdmin(User user);
     public User Login(string email, string password);
    }
}
