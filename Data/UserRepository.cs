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
            foxtrotContext.Add(user);
            foxtrotContext.SaveChanges();
        }

        public async Task DeleteAsync(User user)
        {
            foxtrotContext.User.Remove(user);
            foxtrotContext.SaveChanges();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await foxtrotContext.User.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int? id)
        {
            return await foxtrotContext.User.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            foxtrotContext.User.Update(user);
            foxtrotContext.SaveChanges();
            return user;
        }
    }
}
