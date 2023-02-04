using Order.Domain.Events;
using Order.Domain.SeedWork;

namespace Order.Domain.AggregateModels.OrderModels
{
    public class Order : BaseEntity, IAggregateRote
    {
        public DateTime OrderDate { get; private set; }
        public string Description { get; private set; }
        public Address Address { get; private set; }
        public string Username { get; private set; }
        public string OrderStatus { get; private set; }
        public ICollection<OrderItem> OrderItems { get; private set; }

        public Order(DateTime orderDate, string description, Address address, string username, string orderStatus, ICollection<OrderItem> orderItems)
        {
            if (orderDate < DateTime.Now)
                throw new Exception("OrderDate must be greater than now!");

            if (string.IsNullOrWhiteSpace(address.City))
                throw new Exception("City cannot be empty!");


            OrderDate = orderDate;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Username = username;
            OrderStatus = orderStatus ?? throw new ArgumentNullException(nameof(orderStatus));
            OrderItems = orderItems ?? throw new ArgumentNullException(nameof(orderItems));

            AddDomainEvents(new OrderStartedDomainEvent(username, this));
        }

        public void AddOrderItem(int quantity, decimal price, int productId)
        {
            OrderItem item = new(quantity, price, productId);

            OrderItems.Add(item);
        }
    }
}
