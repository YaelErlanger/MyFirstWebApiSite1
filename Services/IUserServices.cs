using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public interface IUserServices
    {
        Task<UsersTbl> addUserToDB(UsersTbl user);
        Task<UsersTbl> getUserByEmailAndPassword(string email, string password);
        Task<int> updateUserDetails(int id, [FromBody] UsersTbl userToUpdate);
       int validatePassword(string password);
    }
}
