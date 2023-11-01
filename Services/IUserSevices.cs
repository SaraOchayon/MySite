using Entities;

namespace Services
{
    public interface IUserSevices
    {
        Task<User> AddUser(User user);
        int checkpassword(string pwd);
        Task<User> GetUserByUserNameAndPassword(string email, string password);
        Task<User> GetUserById(int id);
        Task<bool> UpdateUserAsync(int id, User userToUpdate);
    }
}