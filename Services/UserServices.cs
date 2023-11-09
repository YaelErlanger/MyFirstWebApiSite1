using Entities;
using Repositories;
using System.Text.Json;



namespace Services
{
    public class UserServices : IUserServices
    {
        IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UsersTbl> addUserToDB(UsersTbl user)
        {
            int result = validatePassword(user.Password);
            if (result < 2)
                return null;
            return await _userRepository.addUserToDB(user);
        }

        public async  Task<UsersTbl> getUserByEmailAndPassword(string email, string password)
        {
            return await _userRepository.getUserByEmailAndPassword(email, password);
        }

        public async  Task<int> updateUserDetails(int id,UsersTbl userToUpdate)
        {
            int result = validatePassword(userToUpdate.Password);
            if (result < 2)
                return 1;
            await _userRepository.updateUserDetails(id,userToUpdate);
            return 0;
        }

        public int validatePassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}