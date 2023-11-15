
using Entities;
using Repositories;

namespace Services;

public class UserSevices : IUserSevices
{
    private IUserRepositories UserRepository;
    public UserSevices(IUserRepositories _userRepositories)
    {
        UserRepository = _userRepositories;
    }

    public  async Task<User> AddUser(User user)
    {
        return   await UserRepository.AddUser(user);
    }

    public async  Task<User> GetUserByUserNameAndPassword(string email, string password)
    {
        return await UserRepository.GetUserByEmailAndPassword(email, password);
    }
    public async Task<User> GetUserById(int id)
    {
        return await UserRepository.GetUserById(id);
    }
    public async Task<bool> UpdateUserAsync(int id, User userToUpdate)
    {
        return await UserRepository.UpdateUser(id, userToUpdate);
    }
    public int checkpassword(string pwd)
    {
        var result = Zxcvbn.Core.EvaluatePassword(pwd);
        return result.Score;
    }

}
