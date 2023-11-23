using Entities;
using Repositories;
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
        

        
        public async Task<UsersTbl> addUserToDB(UsersTbl user)
        {
            await _store326659356Context.UsersTbls.AddAsync(user);
            await _store326659356Context.SaveChangesAsync();
            
            return user;
        }

        public async Task<UsersTbl> getUserByEmailAndPassword(string email, string password)
        {

            return await _store326659356Context.UsersTbls.Where(p => p.Email == email && p.Password == password)
                .FirstOrDefaultAsync();
         
        }

        public async Task updateUserDetails(int id, UsersTbl userToUpdate)
        {
            _store326659356Context.UsersTbls.Update(userToUpdate);
            await _store326659356Context.SaveChangesAsync();
           
        }

    }
}