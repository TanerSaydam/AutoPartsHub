namespace Entities.Enums;

public enum OrderStatusEnum
{
    Pending,       // Bekliyor
    Approved,      // Onaylandı
    Shipped,       // Kargoda
    Delivered,     // Teslim Edildi
    Cancelled,     // İptal Edildi
    Returned,      // İade Edildi
    Processing,    // İşleniyor
    OutOfStock,    // Stokta Yok
    OnHold         // Beklemede
}