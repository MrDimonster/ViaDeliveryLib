using System;
using System.Collections.Generic;

namespace ViaDeliveryLib
{
    public class InsalesOrderRequestBody
    {
        public List<InsalesOrderLine> OrderLines { get; set; }
        public object Discount { get; set; }
        public InsalesShippingAddress ShippingAddress { get; set; }
        public InsalesClient Client { get; set; }
        public List<object> Discounts { get; set; }
        public int TotalPrice { get; set; }
        public int ItemsPrice { get; set; }
        public int Id { get; set; }
        public string Key { get; set; }
        public int Number { get; set; }
        public string Comment { get; set; }
        public bool Archived { get; set; }
        public string DeliveryTitle { get; set; }
        public string DeliveryDescription { get; set; }
        public int DeliveryPrice { get; set; }
        public int FullDeliveryPrice { get; set; }
        public string PaymentDescription { get; set; }
        public string PaymentTitle { get; set; }
        public object FirstReferer { get; set; }
        public string FirstCurrentLocation { get; set; }
        public object FirstQuery { get; set; }
        public object FirstSourceDomain { get; set; }
        public string FirstSource { get; set; }
        public object Referer { get; set; }
        public string CurrentLocation { get; set; }
        public object Query { get; set; }
        public object SourceDomain { get; set; }
        public string Source { get; set; }
        public string FulfillmentStatus { get; set; }
        public CustomStatus CustomStatus { get; set; }
        public object DeliveredAt { get; set; }
        public object AcceptedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string FinancialStatus { get; set; }
        public object DeliveryDate { get; set; }
        public object DeliveryFromHour { get; set; }
        public object DeliveryToHour { get; set; }
        public object PaidAt { get; set; }
        public int DeliveryVariantId { get; set; }
        public int PaymentGatewayId { get; set; }
        public string Margin { get; set; }
        public object ClientTransactionId { get; set; }
        public string CurrencyCode { get; set; }
        public Cookies Cookies { get; set; }
        public int AccountId { get; set; }
        public object ManagerComment { get; set; }
        public string Locale { get; set; }
        public DeliveryInfo DeliveryInfo { get; set; }
        public object ResponsibleUserId { get; set; }
        public string TotalProfit { get; set; }
    }
    public class InsalesOrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SalePrice { get; set; }
        public int FullSalePrice { get; set; }
        public int TotalPrice { get; set; }
        public int FullTotalPrice { get; set; }
        public int DiscountsAmount { get; set; }
        public int Quantity { get; set; }
        public int ReservedQuantity { get; set; }
        public object Weight { get; set; }
        public object Dimensions { get; set; }
        public int VariantId { get; set; }
        public int ProductId { get; set; }
        public object Sku { get; set; }
        public object Barcode { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public object Comment { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public object BundleId { get; set; }
        public int Vat { get; set; }
        public int FiscalProductType { get; set; }
    }

    public class InsalesLocation
    {
        public string KladrCode { get; set; }
        public object Zip { get; set; }
        public string RegionZip { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string StateType { get; set; }
        public object Area { get; set; }
        public object AreaType { get; set; }
        public string City { get; set; }
        public string CityType { get; set; }
        public object Settlement { get; set; }
        public object SettlementType { get; set; }
        public string Address { get; set; }
        public object Street { get; set; }
        public object StreetType { get; set; }
        public object House { get; set; }
        public object Flat { get; set; }
        public bool IsKladr { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public object Autodetected { get; set; }
    }

    public class InsalesShippingAddress
    {
        public int Id { get; set; }
        public List<object> FieldsValues { get; set; }
        public string Name { get; set; }
        public object Surname { get; set; }
        public object Middlename { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public string FullLocalityName { get; set; }
        public string FullDeliveryAddress { get; set; }
        public string AddressForGis { get; set; }
        public bool LocationValid { get; set; }
        public object Address { get; set; }
        public object Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public object Zip { get; set; }
        public object Street { get; set; }
        public object House { get; set; }
        public object Flat { get; set; }
        public InsalesLocation Location { get; set; }
    }

    public class IpAddr
    {
        public int Family { get; set; }
        public int Addr { get; set; }
        public long MaskAddr { get; set; }
    }

    public class InsalesClient
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Registered { get; set; }
        public bool Subscribe { get; set; }
        public object ClientGroupId { get; set; }
        public object Surname { get; set; }
        public object Middlename { get; set; }
        public int BonusPoints { get; set; }
        public IpAddr IpAddr { get; set; }
        public string Type { get; set; }
        public object CorrespondentAccount { get; set; }
        public object SettlementAccount { get; set; }
        public object ConsentToPersonalData { get; set; }
        public object ProgressiveDiscount { get; set; }
        public object GroupDiscount { get; set; }
        public List<object> FieldsValues { get; set; }
    }

    public class CustomStatus
    {
        public string Permalink { get; set; }
        public string Title { get; set; }
    }

    public class Cookies
    {
        public string RoistatVisit { get; set; }
        public string RoistatVisitCookieExpire { get; set; }
    }

    public class InsalesDeliveryInterval
    {
        public int MinDays { get; set; }
        public int MaxDays { get; set; }
        public string Description { get; set; }
    }

    public class Outlet
    {
        public string Id { get; set; }
        public int ExternalId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public List<object> PaymentMethod { get; set; }
        public int SourceId { get; set; }
    }

    public class DeliveryInfo
    {
        public int DeliveryVariantId { get; set; }
        public object TariffId { get; set; }
        public object Title { get; set; }
        public object Description { get; set; }
        public int Price { get; set; }
        public object ShippingCompany { get; set; }
        public string ShippingCompanyHandle { get; set; }
        public InsalesDeliveryInterval DeliveryInterval { get; set; }
        public List<object> Errors { get; set; }
        public List<object> Warnings { get; set; }
        public Outlet Outlet { get; set; }
    }
}
