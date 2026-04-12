using System.ComponentModel.DataAnnotations;
using ShopappES.Domain.Common;

namespace ShopappES.Domain
{
    public class Category : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Tên thể loại không được để trống")]
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryDescription { get; set; } = string.Empty;
        public ICollection<Product> products = new HashSet<Product>();
    }
}
