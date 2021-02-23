using System.Collections.Generic;
using System.Threading.Tasks;
using ViaDeliveryLib.Enums;

namespace ViaDeliveryLib
{
    public interface IClient
    {
        string CreateDeliveryGetId(Delivery delivery, RequestSettings rs = null);
        Task<string> CreateDeliveryGetIdAsync(Delivery delivery, RequestSettings rs = null);
        RefObjectRequestResult GetCities(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null);
        Task<RefObjectRequestResult> GetCitiesAsync(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null);
        RefObjectRequestResult GetCountries(string language = "RU", RequestSettings rs = null);
        Task<RefObjectRequestResult> GetCountriesAsync(string language = "RU", RequestSettings rs = null);
        DeliveryPoint GetDeliveryPointById(string pointId, RequestSettings rs = null);
        Task<DeliveryPoint> GetDeliveryPointByIdAsync(string pointId, RequestSettings rs = null);
        List<DeliveryPoint> GetDeliveryPoints(ApiParameters pars, RequestSettings rs = null);
        Task<List<DeliveryPoint>> GetDeliveryPointsAsync(ApiParameters pars, RequestSettings rs = null);
        List<string> GetGeoDictionaryVariants(GeoType type, string filterKeyword, string filterCity, string fiterRegion, RequestSettings rs = null, string filterCountry = "RU");
        Task<List<string>> GetGeoDictionaryVariantsAsync(GeoType type, string filterKeyword, string filterCity, string fiterRegion, RequestSettings rs = null, string filterCountry = "RU");
        string GetInsalesOrder(InsalesOrderRequestBody order, string method, RequestSettings rs = null);
        List<InSalesPoint> GetInsalesPointList(InSalesPointListRequestBody body, RequestSettings rs = null);
        bool GetOrdersDataPrint(List<string> orderIds, string saveAsFullPath, RequestSettings rs = null);
        OrderStatusRequestResult GetOrderStatus(string orderId, RequestSettings rs = null);
        Task<OrderStatusRequestResult> GetOrderStatusAsync(string orderId, RequestSettings rs = null);
        PickupPointsRequestResult GetPickupPoints(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null);
        Task<PickupPointsRequestResult> GetPickupPointsAsync(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null);
        RefObjectRequestResult GetRegions(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null);
        Task<RefObjectRequestResult> GetRegionsAsync(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null);
        bool GetSticker(string orderUid, string saveAsFullPath, RequestSettings rs = null);
        RefObjectRequestResult GetStreets(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null);
        Task<RefObjectRequestResult> GetStreetsAsync(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null);
    }
}