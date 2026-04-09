namespace ShopappES.Domain
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category {get; set;} = null!;
    }
}
