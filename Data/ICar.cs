using FribergCarRentals_Foxtrot.Models;
namespace FribergCarRentals_Foxtrot.Data
{
    public interface ICar
    {
        Task<IList<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(int id);
        Task AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(Car car);
        Task<List<Car>> GetAvailableCarsAsync(DateOnly StartDate, DateOnly EndDate);
        Task<List<Category>> GetCarCategoryAsync();
    }
}
