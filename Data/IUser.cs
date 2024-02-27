using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Data
{
    public interface IUser
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int? id);
        Task AddAsync(User user);
        Task DeleteAsync(User user);
        Task <User> UpdateAsync(User user);

    }
}
