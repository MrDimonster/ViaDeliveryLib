using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaDeliveryLib;
using ViaDeliveryLib.Enums;

namespace Tests
{
    public class FakeClient : IClient
    {
        public string CreateDeliveryGetId(Delivery delivery, RequestSettings rs = null)
        {
            return "DeliveryTestId";
        }

        public async Task<string> CreateDeliveryGetIdAsync(Delivery delivery, RequestSettings rs = null)
        {
            await Task.Delay(5).ConfigureAwait(false);
            return "DeliveryTestAsyncId";
        }

        public RefObjectRequestResult GetCities(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null)
        {
            var result = new RefObjectRequestResult
            {
                Data = new List<RefObject> { new RefObject { Id = "1", Name = "Name" } },
                Status = "OK"
            };
            return result;
        }

        public async Task<RefObjectRequestResult> GetCitiesAsync(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null)
        {
            await Task.Delay(5).ConfigureAwait(false);
            return GetCities(masterId, limit = null, offset = null, language, rs);
        }

        public RefObjectRequestResult GetCountries(string language = "RU", RequestSettings rs = null)
        {
            var result = new RefObjectRequestResult
            {
                Data = new List<RefObject> { new RefObject { Id = "1", Name = "Name" } },
                Status = "OK"
            };
            return result;
        }

        public async Task<RefObjectRequestResult> GetCountriesAsync(string language = "RU", RequestSettings rs = null)
        {
            await Task.Delay(5).ConfigureAwait(false);
            return GetCountries(language, rs);
        }

        public DeliveryPoint GetDeliveryPointById(string pointId, RequestSettings rs = null)
        {
            var result = new DeliveryPoint
            {
                Id = "id",
                Lat = 1,
                Lng = 1
            };
            return result;
        }

        public async Task<DeliveryPoint> GetDeliveryPointByIdAsync(string pointId, RequestSettings rs = null)
        {
            await Task.Delay(5).ConfigureAwait(false);
            return GetDeliveryPointById(pointId, rs);
        }

        public List<DeliveryPoint> GetDeliveryPoints(ApiParameters pars, RequestSettings rs = null)
        {
            var result = new List<DeliveryPoint>();
            for(int i = 0; i < 3; i++)
            {
                result.Add(new DeliveryPoint
                {
                    Id = "id" + i,
                    Lat = 1,
                    Lng = 1
                });
            }
            return result;
        }

        public async Task<List<DeliveryPoint>> GetDeliveryPointsAsync(ApiParameters pars, RequestSettings rs = null)
        {
            await Task.Delay(5).ConfigureAwait(false);
            return GetDeliveryPoints(pars, rs);
        }

        public List<string> GetGeoDictionaryVariants(GeoType type, string filterKeyword, string filterCity, string fiterRegion, RequestSettings rs = null, string filterCountry = "RU")
        {
            return new List<string> { "1", "2", "3", "4" };
        }

        public async Task<List<string>> GetGeoDictionaryVariantsAsync(GeoType type, string filterKeyword, string filterCity, string fiterRegion, RequestSettings rs = null, string filterCountry = "RU")
        {
            await Task.Delay(5).ConfigureAwait(false);
            return GetGeoDictionaryVariants(type, filterKeyword, filterCity, fiterRegion, rs, filterCountry);
        }

        public string GetInsalesOrder(InsalesOrderRequestBody order, string method, RequestSettings rs = null)
        {
            return "order";
        }

        public List<InSalesPoint> GetInsalesPointList(InSalesPointListRequestBody body, RequestSettings rs = null)
        {
            var result = new List<InSalesPoint>();
            for(int i = 0; i < 3; i++)
            {
                result.Add(new InSalesPoint { Id = i, Address = "address" });
            }
            return result;
        }

        public bool GetOrdersDataPrint(List<string> orderIds, string saveAsFullPath, RequestSettings rs = null)
        {
            return true;
        }

        public OrderStatusRequestResult GetOrderStatus(string orderId, RequestSettings rs = null)
        {
            var result = new OrderStatusRequestResult
            {
                Data = new OrderStatusData { Barcode = "barcode", Status = OrderStatus.CREATED },
                Status = "OK"
            };
            return result;
        }

        public async Task<OrderStatusRequestResult> GetOrderStatusAsync(string orderId, RequestSettings rs = null)
        {
            await Task.Delay(5).ConfigureAwait(false);
            return GetOrderStatus(orderId, rs);
        }

        public PickupPointsRequestResult GetPickupPoints(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null)
        {
            var result = new PickupPointsRequestResult
            {
                Status = "OK",
                Data = new List<PickupPoint> { new PickupPoint { Id = "id", Lat = "1", Lng = "1" } }
            };
            return result;
        }

        public async Task<PickupPointsRequestResult> GetPickupPointsAsync(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null)
        {
            await Task.Delay(5).ConfigureAwait(false);
            return GetPickupPoints(masterId, limit, offset, language, rs);
        }

        public RefObjectRequestResult GetRegions(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null)
        {
            var result = new RefObjectRequestResult
            {
                Data = new List<RefObject> { new RefObject { Id = "id", Name = "name" } },
                Status = "OK"
            };
            return result;
        }

        public async Task<RefObjectRequestResult> GetRegionsAsync(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null)
        {
            await Task.Delay(5).ConfigureAwait(false);
            return GetRegions(masterId, limit, offset, language, rs);
        }

        public bool GetSticker(string orderUid, string saveAsFullPath, RequestSettings rs = null)
        {
            return true;
        }

        public RefObjectRequestResult GetStreets(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null)
        {
            var result = new RefObjectRequestResult
            {
                Data = new List<RefObject> { new RefObject { Id = "id", Name = "name" } },
                Status = "OK"
            };
            return result;
        }

        public async Task<RefObjectRequestResult> GetStreetsAsync(long masterId, long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null)
        {
            await Task.Delay(5).ConfigureAwait(false);
            return GetStreets(masterId, limit, offset, language, rs);
        }
    }
}
