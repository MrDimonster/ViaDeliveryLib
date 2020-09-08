using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaDeliveryLib
{
    public class PickupPointsRequestResult
    {
        public string Status { get; set; }
        public List<PickupPoint> Data { get; set; }
    }
}
