using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<UsersTbl> addUserToDB(UsersTbl user);
        Task<UsersTbl> getUserByEmailAndPassword(string email, string password);
        Task updateUserDetails(int id, UsersTbl userToUpdate);    }
}