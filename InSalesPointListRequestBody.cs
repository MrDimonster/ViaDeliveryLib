using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaDeliveryLib
{
    public class InSalesPointListRequestBody
    {
        public Body Order { get; set; } = new Body();
    }
 
    public class Body
    {
        public int AccountId { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public string CurrencyIsoCode { get; set; } = "RUB";
        public decimal ItemsPrice { get; set; }
        public string TotalWeight { get; set; } //KG?? string by Docs!
        public ShippingAddress ShippingAddress { get; set; }
    }

    public class OrderLine
    {
        public long ProductId { get; set; } // int by Docs!
        public long VariantId { get; set; } // int by Docs!
        public int Quantity { get; set; }
        public string Weight { get; set; } // "0.012" string by Docs!
        public string Dimensions { get; set; }
    }

    public class ShippingAddress
    {
        public string FullLocalityName { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public string KladrCode { get; set; }
        public string Zip { get; set; }
        public string RegionZip { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string StateType { get; set; }
        public object Area { get; set; } //what this? null by Docs
        public object AreaType { get; set; } //what this? null by Docs
        public string City { get; set; }
        public string CityType { get; set; }
        public object Settlement { get; set; } //what this? null by Docs
        public object SettlementType { get; set; } //what this? null by Docs
        public Bounds Bounds { get; set; }
    }

    public class Bounds
    {
        public BottomLeft BottomLeft { get; set; }
        public TopRight TopRight { get; set; }
    }

    public class BottomLeft
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class TopRight
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
