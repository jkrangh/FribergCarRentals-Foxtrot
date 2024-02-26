using FribergCarRentals_Foxtrot.Models;
namespace FribergCarRentals_Foxtrot.Data
{
    public interface ICar
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(int id);
        Task AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(Car car);
    }
}
