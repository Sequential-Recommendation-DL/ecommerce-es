using System.ComponentModel.DataAnnotations;
using ShopappES.Domain.Common;

namespace ShopappES.Domain
{
    public class Product : BaseEntity
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Tên sản phẩm không được để trống")]
        public string ProductName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Mã thể loại không được để trống")]
        public int CategoryId { get; set; }
        public Category Category {get; set;} = null!;
    }
}
