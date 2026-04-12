using System.ComponentModel.DataAnnotations;

namespace ShopappES.Domain
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        [Required(ErrorMessage ="Mã đơn hàng không được để trống")]
        public int OrderId { get; set; }

        [Required(ErrorMessage ="Mã sản phẩm không được để trống")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Required(ErrorMessage ="Số lượng không được để trống")]
        public int Quantity { get; set; }
        [Required(ErrorMessage ="Giá không được để trống")]
        public double Amount { get; set; }
    }
}
