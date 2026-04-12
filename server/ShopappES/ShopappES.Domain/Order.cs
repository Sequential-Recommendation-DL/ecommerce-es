using System.ComponentModel.DataAnnotations;

namespace ShopappES.Domain
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required(ErrorMessage ="Mã người dùng không được để trống")]
        public Guid UserId { get; set; }
        public ICollection<OrderDetail> orderDetails = new HashSet<OrderDetail>();
    }
}
