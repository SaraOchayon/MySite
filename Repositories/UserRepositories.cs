using Entities;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Repositories;

public class UserRepositories : IUserRepositories
{
    public string filePath = "M:\\web api\\users.txt";
    public async Task <User> AddUser(User user)
    {
        int numberOfUsers = System.IO.File.ReadLines(filePath).Count();

        user.Id = numberOfUsers;
        string userJson = JsonSerializer.Serialize(user);
        await System.IO.File.AppendAllTextAsync(filePath, userJson + Environment.NewLine);
        return user;
    }

    public async Task<User?> GetUserByEmailAndPassword(string userName, string password)
    {
        using (StreamReader reader = System.IO.File.OpenText(filePath))
        {
            string? currentUserInFile;
            while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            {
                User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                if (user?.UserName == userName && user?.Password == password)
                    return user;
            }
        }
        return null;
    }
    public async Task<User?> GetUserById(int id)
    {
        using (StreamReader reader = System.IO.File.OpenText(filePath))
        {
            string? currentUserInFile;
            while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            {
                User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                if (user?.Id == id )
                    return user;
            }
        }
        return null;
    }

    public async Task<bool> UpdateUser(int id, User userToUpdate)
    {
        string textToReplace = string.Empty;
        using (StreamReader reader = System.IO.File.OpenText(filePath))
        {
            string currentUserInFile;
            while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            {
                User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                if (user.Id == id)
                    textToReplace = currentUserInFile;
            }
        }

        if (textToReplace != string.Empty)
        {
            string text = System.IO.File.ReadAllText(filePath);
            text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
            System.IO.File.WriteAllText(filePath, text);
            return true;
        }
        return false;
    }
}
