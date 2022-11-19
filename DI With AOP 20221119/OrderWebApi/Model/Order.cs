namespace OrderWebApi.Model
{
    public class Order
    {
        public Order(string id, string orderNumber)
        {
            Id = id;
            OrderNumber = orderNumber;
        }
        public string Id { get; set; }
        public string OrderNumber { get; set; }
    }
}