using FribergCarRentals_Foxtrot.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentals_Foxtrot.Data
{
    public class UserRepository : IUser
    {
        private readonly FoxtrotContext foxtrotContext;

        public UserRepository(FoxtrotContext foxtrotContext)
        {
            this.foxtrotContext = foxtrotContext;
        }

        public async Task AddAsync(User user)
        {
            await foxtrotContext.AddAsync(user);
            await foxtrotContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            foxtrotContext.User.Remove(user);
            await foxtrotContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await foxtrotContext.User.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int? id)
        {
            return await foxtrotContext.User.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task UpdateAsync(User user)
        {
            foxtrotContext.User.Update(user);
            await foxtrotContext.SaveChangesAsync();          
        }
        public async Task<User> GetByCredentialsAsync(string username, string password)
        {
            return await foxtrotContext.User.FirstOrDefaultAsync(u => u.Email == username && u.Password == password);
        }

    }
}
