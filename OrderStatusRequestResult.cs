using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaDeliveryLib
{
    public class OrderStatusData
    {
        public string Status { get; set; }
        public string Barcode { get; set; }
    }

    public class OrderStatusRequestResult
    {
        public string Status { get; set; }
        public OrderStatusData Data { get; set; }
    }
}
