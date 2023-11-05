using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Store326659356Context _store326659356Context;
        public UserRepository(Store326659356Context store326659356Context)
        {
            _store326659356Context = store326659356Context;
        }
        public async Task<IEnumerable<UsersTbl>> GetUsersAsync()
        {
            return await _store326659356Context.UsersTbls.ToListAsync();
        }

        private const string filePath = "C:\\Users\\User\\Desktop\\MyFirstWebApiSite\\Users";
        public  User addUserToDB(User user)
        {
            //ActionResult result = chekYourPass(user.Password);
            int numberOfUsers =  System.IO.File.ReadLines(filePath).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }

        public async Task<User> getUserByEmailAndPassword(string email, string password)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile =await reader.ReadLineAsync()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserName == email && user.Password == password)
                        return user;
                }
            }
            return null;
        }

        public async Task<bool> updateUserDetails(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile =await reader.ReadLineAsync()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text =await System.IO.File.ReadAllTextAsync(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
                return true;
            }
            return false;
        }

    }
}