using System.ComponentModel.DataAnnotations;
using ShopappES.Domain.Common;

namespace ShopappES.Domain
{
    public class Order :BaseEntity
    {
        [Key]
        public int OrderId { get; set; }
        [Required(ErrorMessage ="Mã người dùng không được để trống")]
        public Guid UserId { get; set; }
        public ICollection<OrderDetail> orderDetails = new HashSet<OrderDetail>();
    }
}
