using System.Collections.Generic;

namespace ViaDeliveryLib
{
    public class PickupPointsRequestResult
    {
        public string Status { get; set; }
        public List<PickupPoint> Data { get; set; }
    }
}
