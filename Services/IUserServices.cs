using Entities;

namespace Services
{
    public interface IUserServices
    {
        Task<UsersTbl> addUserToDB(UsersTbl user);
        Task<UsersTbl> getUserByEmailAndPassword(string email, string password);
        Task<int> updateUserDetails(int id, UsersTbl userToUpdate);
       int validatePassword(string password);
    }
}