using ViaDeliveryLib.Enums;

namespace ViaDeliveryLib
{
    public class OrderStatusData
    {
        public OrderStatus Status { get; set; }
        public string Barcode { get; set; }
    }

    public class OrderStatusRequestResult
    {
        public string Status { get; set; }
        public OrderStatusData Data { get; set; }
    }
}
