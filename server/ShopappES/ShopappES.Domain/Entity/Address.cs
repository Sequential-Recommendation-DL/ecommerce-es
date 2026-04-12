using System.ComponentModel.DataAnnotations;
using ShopappES.Domain.Common;

namespace ShopappES.Domain.Entity
{
    public class Address : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public string ReceiverName { get; set; } = string.Empty;
        public string? ReceiverPhone { get; set; }
        public string AddressLine { get; set; } = string.Empty;
        public string? Ward { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDefaultBilling { get; set; }
        public bool IsDefaultShipping { get; set; }
        public AddressType AddressType { get; set; } = AddressType.Other;
    }

    public enum AddressType
    {
        Home,
        Office,
        Other
    }
}
