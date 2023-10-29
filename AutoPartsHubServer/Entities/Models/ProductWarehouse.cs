namespace Entities.Models;

public sealed class ProductWarehouse
{
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
    public int Quantity { get; set; }
}