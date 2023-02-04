using Order.Application.Repository;

namespace Order.Infrastructure.Repository
{
    internal class BuyerRepository : IOrderRepository
    {
        public Task<int> SaveChangesAsync()
        {
           return Task.FromResult(0);
        }
    }
}
