using Entities;

namespace Repositories
{
    public interface IUserRepositories
    {
        Task<User> AddUser(User user);
        Task<User?> GetUserByEmailAndPassword(string email, string password);
        Task<bool> UpdateUser(int id, User userToUpdate);
        Task<User?> GetUserById(int id);
    }
}