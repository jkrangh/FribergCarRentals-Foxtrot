using FribergCarRentals_Foxtrot.Models;
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
            return await foxtrotContext.Car.FirstOrDefaultAsync(s=>s.CarId==id);
        }

        public async Task UpdateAsync(Car car)
        {
            foxtrotContext.Update(car);
            await foxtrotContext.SaveChangesAsync();
        }
    }
}
