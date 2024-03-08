using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Data
{
    public interface ICategory
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
        Task<IEnumerable<Car>> GetByCategoryAsync(int categoryId);
    }
}
