using FribergCarRentals_Foxtrot.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentals_Foxtrot.Data
{
    public class OrderRepository : IOrder
    {
        private readonly FoxtrotContext dbContext;
        public OrderRepository(FoxtrotContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(Order order)
        {
            dbContext.Add(order);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            dbContext.Remove(order);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetActiveOrdersAsync()
        {
            return await dbContext.Order
            .Include(o => o.Car)
            .Include(c => c.User)
            .Where(o => o.IsActive)
            .ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetInactiveOrdersAsync()
        {
            return await dbContext.Order
                .Include(o => o.Car)
                .Include(c => c.User)
                .Where(o => !o.IsActive)
                .ToListAsync(); 
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await dbContext.Order.Include(x => x.User).Include(s => s.Car).ToListAsync();
        }
        public async Task<List<Order>> GetAllOrdersCategoryAsync()
        {
            return await dbContext.Order.Include(x => x.User).Include(s => s.Car).ThenInclude(y=>y.Category).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await dbContext.Order
                .Include(o => o.User)
                .Include(o => o.Car)
                .FirstOrDefaultAsync(o => o.OrderId == id);
            
        }

        public async Task UpdateAsync(Order order)
        {
            dbContext.Update(order);
            await dbContext.SaveChangesAsync();
        }
    }
}
