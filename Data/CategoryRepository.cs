using FribergCarRentals_Foxtrot.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentals_Foxtrot.Data
{
    public class CategoryRepository : ICategory
    {
        private readonly FoxtrotContext context;

        public CategoryRepository(FoxtrotContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Category category)
        {
            context.Add(category);
            await context.SaveChangesAsync();         
        }

        public async Task DeleteAsync(Category category)
        {
            context.Remove(category);
            await context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await context.Category.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await context.Category.FirstOrDefaultAsync(x => x.CategoryId == id);
        }

        public async Task UpdateAsync(Category category)
        {
            context.Update(category);
            await context.SaveChangesAsync();
        }
    }
}
