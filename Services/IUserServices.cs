using Entities;

namespace Services
{
    public interface IUserServices
    {
        User addUserToDB(User user);
        Task<User> getUserByEmailAndPassword(string email, string password);
        Task<int> updateUserDetails(int id, User userToUpdate);
       int validatePassword(string password);
    }
}