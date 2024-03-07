using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Data
{
    public interface IOrder
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task AddAsync(Order order);
        Task DeleteAsync(Order order);
        Task UpdateAsync(Order order);
        Task<IEnumerable<Order>> GetActiveOrdersAsync();
        Task<IEnumerable<Order>> GetInactiveOrdersAsync();
        Task<List<Order>> GetAllOrdersByCustomerAsync(int? id);
        Task<List<Order>> GetAllOrdersCategoryAsync();

    }
}
