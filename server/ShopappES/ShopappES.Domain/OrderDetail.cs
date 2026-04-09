namespace ShopappES.Domain
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product {get;set;} = null!;
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}
