using FribergCarRentals_Foxtrot.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentals_Foxtrot.Data
{
    public class CarRepository : ICar
    {
        private readonly FoxtrotContext foxtrotContext;

        public CarRepository(FoxtrotContext foxtrotContext)
        {
            this.foxtrotContext = foxtrotContext;
        }
        public async Task AddAsync(Car car)
        {
            await foxtrotContext.Car.AddAsync(car);
            await foxtrotContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Car car)
        {
            foxtrotContext.Car.Remove(car);
            await foxtrotContext.SaveChangesAsync();
        }

        public async Task<IList<Car>> GetAllAsync()
        {
          return await foxtrotContext.Car.Include(s=>s.Category).ToListAsync();
            
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await foxtrotContext.Car.Include(s => s.Category).FirstOrDefaultAsync(s=>s.CarId==id);
        }

        public async Task UpdateAsync(Car car)
        {
            foxtrotContext.Update(car);
            await foxtrotContext.SaveChangesAsync();
        }
        public async Task<List<Car>> GetAvailableCarsAsync(DateOnly StartDate, DateOnly EndDate)
        {
            var availableCars = await foxtrotContext.Car
                .Where(s => s.IsAvailable)
                .ToListAsync();

            var orderTime = await foxtrotContext.Order
                .Include(o => o.Car) 
                .Where(o => o.StartDate <= EndDate && o.EndDate >= StartDate)
                .ToListAsync();

            if (orderTime == null)
            {
                
                return availableCars;
            }

            var availableCarIds = orderTime
                .Where(o => o.Car != null) 
                .Select(o => o.Car.CarId)
                .ToList();

            if (availableCars == null)
            {
                
                return new List<Car>();
            }

            return availableCars
                .Where(s => !availableCarIds.Contains(s.CarId))
                .ToList();
        }
        public async Task<List<Category>> GetCarCategoryAsync()
        {
            return await foxtrotContext.Category.ToListAsync();
        }
    }
}
