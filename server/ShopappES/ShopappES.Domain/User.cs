using System.ComponentModel.DataAnnotations;
using ShopappES.Domain.Common;

namespace ShopappES.Domain
{
    public class User : BaseEntity
    {
        [Key]
        public Guid UserId { get; set; } = new Guid();
        [Required(ErrorMessage = "Tên không được để trống")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
