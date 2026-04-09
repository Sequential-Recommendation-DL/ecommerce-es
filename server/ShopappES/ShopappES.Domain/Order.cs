namespace ShopappES.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public Guid UserId { get; set; }
        public ICollection<OrderDetail> orderDetails = new HashSet<OrderDetail>();
    }
}
