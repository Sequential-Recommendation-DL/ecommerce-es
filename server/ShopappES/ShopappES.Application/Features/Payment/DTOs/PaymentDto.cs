using ShopappES.Domain.Entity;
using ShopappES.Domain.Enums;
using ShopappES.Application.Features.Order.DTOs;

namespace ShopappES.Application.Features.Payment.DTOs;

public class PaymentDto
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public OrderDto? Order { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    public string? TransactionId { get; set; }
    public string? PaymentNote { get; set; }
    public DateTime? PaidAt { get; set; }
    public DateTime? ExpiryTime { get; set; }
    public string? PaymentUrl { get; set; }
    public string? ReturnUrl { get; set; }
}

public enum PaymentMethod
{
    Cash,
    CreditCard,
    DebitCard,
    BankTransfer,
    PayPal,
    Momo,
    ZaloPay,
    VNPay
}

public enum PaymentStatus
{
    Pending,
    Processing,
    Completed,
    Failed,
    Refunded,
    Cancelled
}
