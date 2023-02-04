namespace Order.Domain.AggregateModels.BuyerModels
{
    public class Buyer
    {
        public string Username { get; private set; } 

        public Buyer(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
