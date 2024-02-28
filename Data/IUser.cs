using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Data
{
    public interface IUser
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int? id);
        Task AddAsync(User user);
        Task DeleteAsync(User user);
        Task UpdateAsync(User user);
        Task<User> GetByCredentialsAsync(string username, string password);
    }
}
