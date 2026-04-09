namespace ShopappES.Domain
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryDescription { get; set; } = string.Empty;
        public ICollection<Product> products = new HashSet<Product>();
    }
}
