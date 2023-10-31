using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        User addUserToDB(User user);
        Task<User> getUserByEmailAndPassword(string email, string password);
        Task<bool> updateUserDetails(int id, User userToUpdate);
    }
}