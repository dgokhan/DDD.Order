using MediatR;

namespace Order.Domain.Events
{
    public class OrderStartedDomainEvent : INotification
    {
        public string Username { get; set; }

        public AggregateModels.OrderModels.Order Order { get; set; }

        public OrderStartedDomainEvent(string username, AggregateModels.OrderModels.Order order)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Order = order ?? throw new ArgumentNullException(nameof(order));
        }
    }
}
