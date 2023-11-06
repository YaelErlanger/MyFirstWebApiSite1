using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<UsersTbl> addUserToDB(UsersTbl user);
        Task<UsersTbl> getUserByEmailAndPassword(string email, string password);
        Task<bool> updateUserDetails(int id, UsersTbl userToUpdate);
    }
}