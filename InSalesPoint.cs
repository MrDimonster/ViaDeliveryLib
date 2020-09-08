using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaDeliveryLib
{
    public class InSalesPoint
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public List<string> Phones { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Description { get; set; }
        public List<string> PaymentMethod { get; set; } // why in singular? rec: payment_methods for json
        public DeliveryInterval DeliveryInterval { get; set; }
        public string ShippingCompanyHandle { get; set; }
    }

    public class DeliveryInterval
    {
        public int MaxDays { get; set; }
        public int MinDays { get; set; }
        public string Description { get; set; }
    }


}
