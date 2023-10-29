using Entities.Enums;

namespace Entities.Models;

public sealed class Order
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public OrderStatusEnum Status { get; set; }
    public bool IsPay { get; set; }
}