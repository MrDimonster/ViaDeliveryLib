using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using ViaDeliveryLib.Enums;

namespace ViaDeliveryLib
{
    /// <summary>
    /// Главный класс, выполняющий все операции
    /// </summary>
    public class Client
    {
        private string _shopId;
        private string _securityToken;
        private string _apiUrl { get; set; }
        private ISerializer _serializer;
        private IHttpLoader _httpLoader;
        private static readonly RequestSettings _defaultRequestSettings = new RequestSettings();
        public Client(string shopId, string securityToken, string apiUrl, 
            ISerializer serializer = null, IHttpLoader httpLoader = null)
        {
            _shopId = shopId;
            _securityToken = securityToken;
            _apiUrl = apiUrl;
            _serializer = serializer ?? new JsonSerializer();
            _httpLoader = httpLoader ?? new HttpLoader();
        }

        /// <summary>
        /// Информация о конкретной точке по ее Id
        /// </summary>
        /// <param name="pointId"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public DeliveryPoint GetDeliveryPointById(string pointId, RequestSettings rs = null) //t-ok
        {
            string url = $"https://map-api.viadelivery.pro/point-list?id={_shopId}&point_id={pointId}";
            return TryGetObject<DeliveryPoint>(url, HttpMethod.Get, rs ?? _defaultRequestSettings);
        }

        /// <summary>
        /// Информация о конкретной точке по ее Id асинхронно
        /// </summary>
        /// <param name="pointId">Id точки</param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public async Task<DeliveryPoint> GetDeliveryPointByIdAsync(string pointId, RequestSettings rs = null) //t-ok
        {
            string url = $"https://map-api.viadelivery.pro/point-list?id={_shopId}&point_id={pointId}";
            return await TryGetObjectAsync<DeliveryPoint>(url, HttpMethod.Get, rs ?? _defaultRequestSettings);
        }

        /// <summary>
        /// Получить точки для карты
        /// </summary>
        /// <param name="pars"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public List<DeliveryPoint> GetDeliveryPoints(ApiParameters pars, RequestSettings rs = null) //t-ok
        {
            string url = $"https://map-api.viadelivery.pro/point-list" + pars.ToUrlQuery();
            return TryGetObject<List<DeliveryPoint>>(url, HttpMethod.Get, rs ?? _defaultRequestSettings);
        }

        /// <summary>
        /// Получить точки для карты асинхронно
        /// </summary>
        /// <param name="pars"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public async Task<List<DeliveryPoint>> GetDeliveryPointsAsync(ApiParameters pars, RequestSettings rs = null) //t-ok
        {
            string url = $"https://map-api.viadelivery.pro/point-list" + pars.ToUrlQuery();
            return await TryGetObjectAsync<List<DeliveryPoint>>(url, HttpMethod.Get, rs ?? _defaultRequestSettings);
        }

        /// <summary>
        /// Запрос доступных значений для списков стран, городов, регионов
        /// <para>Для нормальной связанности данных, нужно правильно задавать фильтры вышестоящих объектов. 
        /// т.е. для запроса/поиска улиц, желательно указать город и его регион</para>
        /// </summary>
        /// <param name="type">country/region/city/street - выбирает какие объекты вернет запрос</param>
        /// <param name="filterKeyword">фильтрация значения запрашиваемого справочника по подстроке</param>
        /// <param name="filterCity">включить фильтрацию по городу. если не задан - все города</param>
        /// <param name="fiterRegion">включить фильтрацию по региону. если не задан - все регионы</param>
        /// <param name="rs"></param>
        /// <param name="filterCountry">позволяет включить фильтрацию по коду страны. если не задан = RU</param>
        /// <returns></returns>
        public List<string> GetGeoDictionaryVariants(GeoType type, string filterKeyword, 
            string filterCity, string fiterRegion, RequestSettings rs = null, string filterCountry = "RU") //t-ok
        {
            string url = $"https://map-api.viadelivery.pro/geo-dictionary?type={type.ToString().ToLower()}";
            if (!string.IsNullOrWhiteSpace(filterCountry)) url += ($"&filter_country={filterCountry}");
            if (!string.IsNullOrWhiteSpace(fiterRegion)) url += ($"&filter_region={fiterRegion}");
            if (!string.IsNullOrWhiteSpace(filterCity)) url += ($"&filter_city={filterCity}");
            if (!string.IsNullOrWhiteSpace(filterKeyword)) url += ($"&filter_keyword={filterKeyword}");

            return TryGetObject<List<string>>(url, HttpMethod.Get, rs ?? _defaultRequestSettings);
        }

        /// <summary>
        /// Запрос доступных значений для списков стран, городов, регионов асинхронно
        /// <para>Для нормальной связанности данных, нужно правильно задавать фильтры вышестоящих объектов. 
        /// т.е. для запроса/поиска улиц, желательно указать город и его регион</para>
        /// </summary>
        /// <param name="type">country/region/city/street - выбирает какие объекты вернет запрос</param>
        /// <param name="filterKeyword">фильтрация значения запрашиваемого справочника по подстроке</param>
        /// <param name="filterCity">включить фильтрацию по городу. если не задан - все города</param>
        /// <param name="fiterRegion">включить фильтрацию по региону. если не задан - все регионы</param>
        /// <param name="rs"></param>
        /// <param name="filterCountry">позволяет включить фильтрацию по коду страны. если не задан = RU</param>
        /// <returns></returns>
        public async Task<List<string>> GetGeoDictionaryVariantsAsync(GeoType type, string filterKeyword,
            string filterCity, string fiterRegion, RequestSettings rs = null, string filterCountry = "RU") //t-ok
        {
            string url = $"https://map-api.viadelivery.pro/geo-dictionary?type={type.ToString().ToLower()}";
            if (!string.IsNullOrWhiteSpace(filterCountry)) url += ($"&filter_country={filterCountry}");
            if (!string.IsNullOrWhiteSpace(fiterRegion)) url += ($"&filter_region={fiterRegion}");
            if (!string.IsNullOrWhiteSpace(filterCity)) url += ($"&filter_city={filterCity}");
            if (!string.IsNullOrWhiteSpace(filterKeyword)) url += ($"&filter_keyword={filterKeyword}");

            return await TryGetObjectAsync<List<string>>(url, HttpMethod.Get, rs ?? _defaultRequestSettings);
        }
 
        /// <summary>
        /// Получение списка стран
        /// </summary>
        /// <param name="language"></param>
        /// <returns>RefObjectRequestResult</returns>
        public RefObjectRequestResult GetCountries(string language = "RU", RequestSettings rs = null) 
            => GetObjects("country", null, null, null, rs, language); //t-ok

        /// <summary>
        /// Получение списка стран асинхронно
        /// </summary>
        /// <param name="language"></param>
        /// <returns>RefObjectRequestResult</returns>
        public async Task<RefObjectRequestResult> GetCountriesAsync(string language = "RU", RequestSettings rs = null)
            => await GetObjectsAsync("country", null, null, null, rs, language); //t-ok

        /// <summary>
        /// Получение списка регионов
        /// </summary>
        /// <param name="masterId">ID мастер объекта (если не задан, будут возвращены все объекты данного типа), 
        /// возможно задавать id не не только непосредственного мастер объекта, а любого мастер объекта. 
        /// Например: все точки доставки по улице, все точки доставки города</param>
        /// <param name="limit">количество получаемых строк</param>
        /// <param name="offset">отступ в строчках</param>
        /// <param name="language">язык выдачи</param>
        /// <returns></returns>
        public RefObjectRequestResult GetRegions(long masterId, 
            long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null) 
            => GetObjects("region", masterId, limit, offset, rs, language); //t-ok

        /// <summary>
        /// Получение списка регионов асинхронно
        /// </summary>
        /// <param name="masterId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="language"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public async Task<RefObjectRequestResult> GetRegionsAsync(long masterId,
            long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null)
            => await GetObjectsAsync("region", masterId, limit, offset, rs, language); //t-ok

        /// <summary>
        /// Получение списка городов асинхронно
        /// </summary>
        /// <param name="masterId">ID мастер объекта (если не задан, будут возвращены все объекты данного типа), 
        /// возможно задавать id не не только непосредственного мастер объекта, а любого мастер объекта. 
        /// Например: все точки доставки по улице, все точки доставки города</param>
        /// <param name="limit">количество получаемых строк</param>
        /// <param name="offset">отступ в строчках</param>
        /// <param name="language">язык выдачи</param>
        /// <returns></returns>
        public async Task<RefObjectRequestResult> GetCitiesAsync(long masterId, 
            long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null) 
            => await GetObjectsAsync("city", masterId, limit, offset, rs, language); //t-ok

        /// <summary>
        /// Получение списка городов 
        /// </summary>
        /// <param name="masterId">ID мастер объекта (если не задан, будут возвращены все объекты данного типа), 
        /// возможно задавать id не не только непосредственного мастер объекта, а любого мастер объекта. 
        /// Например: все точки доставки по улице, все точки доставки города</param>
        /// <param name="limit">количество получаемых строк</param>
        /// <param name="offset">отступ в строчках</param>
        /// <param name="language">язык выдачи</param>
        /// <returns></returns>
        public RefObjectRequestResult GetCities(long masterId,
            long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null)
            => GetObjects("city", masterId, limit, offset, rs, language); //t-ok

        /// <summary>
        /// Получение списка улиц
        /// </summary>
        /// <param name="masterId">ID мастер объекта (если не задан, будут возвращены все объекты данного типа), 
        /// возможно задавать id не не только непосредственного мастер объекта, а любого мастер объекта. 
        /// Например: все точки доставки по улице, все точки доставки города</param>
        /// <param name="limit">количество получаемых строк</param>
        /// <param name="offset">отступ в строчках</param>
        /// <param name="language">язык выдачи</param>
        /// <returns></returns>
        public RefObjectRequestResult GetStreets(long masterId, 
            long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null) 
            => GetObjects("street", masterId, limit, offset, rs, language); //t-ok

        /// <summary>
        /// Получение списка улиц асинхронно
        /// </summary>
        /// <param name="masterId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="language"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public async Task<RefObjectRequestResult> GetStreetsAsync(long masterId,
            long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null)
            => await GetObjectsAsync("street", masterId, limit, offset, rs, language); //t-ok

        /// <summary>
        /// Получение списка точек доставки
        /// </summary>
        /// <param name="masterId">ID мастер объекта (если не задан, будут возвращены все объекты данного типа), 
        /// возможно задавать id не не только непосредственного мастер объекта, а любого мастер объекта. 
        /// Например: все точки доставки по улице, все точки доставки города</param>
        /// <param name="limit">количество получаемых строк</param>
        /// <param name="offset">отступ в строчках</param>
        /// <param name="language">язык выдачи</param>
        /// <returns></returns>
        public PickupPointsRequestResult GetPickupPoints(long masterId, 
            long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null) 
            => GetPickupObjects("pickup_points", masterId, limit, offset, rs, language); //t-ok

        /// <summary>
        /// Получение списка точек доставки асинхронно
        /// </summary>
        /// <param name="masterId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="language"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public async Task<PickupPointsRequestResult> GetPickupPointsAsync(long masterId,
            long? limit = null, long? offset = null, string language = "RU", RequestSettings rs = null)
            => await GetPickupObjectsAsync("pickup_points", masterId, limit, offset, rs, language); //t-ok

        /// <summary>
        /// Создание доставки
        /// </summary>
        /// <param name="delivery">объект доставки</param>
        /// <returns>в случае успеха возвращает ID заказа в системе службы доставки</returns>
        public string CreateDeliveryGetId(Delivery delivery, RequestSettings rs = null) //t-ok
        {
            var r = (rs ?? RequestSettings.CreateNew()).SetJson();
            r.Body = _serializer.SerializeObject(delivery);
            var url = _apiUrl + "/api/post_order?sid=@" + _securityToken;
            var o = TryGetObject<CreateOrderRequestResult>(url, HttpMethod.Post, r);
            return string.Equals(o.Status, "OK", StringComparison.OrdinalIgnoreCase) ? o.Data.OrderId : null;
        }

        /// <summary>
        /// Создание доставки асинхронно
        /// </summary>
        /// <param name="delivery">объект доставки</param>
        /// <returns>в случае успеха возвращает ID заказа в системе службы доставки</returns>
        public async Task<string> CreateDeliveryGetIdAsync(Delivery delivery, RequestSettings rs = null) //t-ok
        {
            var r = (rs ?? RequestSettings.CreateNew()).SetJson();
            r.Body = _serializer.SerializeObject(delivery);

            var url = _apiUrl + "/api/post_order?sid=@" + _securityToken;
            var responseString = await _httpLoader.GetStringAsync(url, HttpMethod.Post, r);
            var o = AnswerToObject<CreateOrderRequestResult>(responseString, _serializer);
            if (o != null && string.Equals(o.Status, "OK", StringComparison.OrdinalIgnoreCase))
            {
                return o.Data.OrderId;
            }
            return null;
        }

        /// <summary>
        /// Получение статуса доставки
        /// </summary>
        /// <param name="orderId">ID заказа в системе службы доставки</param>
        /// <returns>результат ответа сервера с информацией о статусе</returns>
        public OrderStatusRequestResult GetOrderStatus(string orderId, RequestSettings rs = null) //t-ok
        {
            var r = (rs ?? RequestSettings.CreateNew()).SetJson();
            r.Body = _serializer.SerializeObject(new { OrderId = orderId });
            var url = _apiUrl + "/api/get_order_status?sid=@" + _securityToken;
            return TryGetObject<OrderStatusRequestResult>(url, HttpMethod.Post, r);
        }

        /// <summary>
        /// Получение статуса доставки асинхронно
        /// </summary>
        /// <param name="orderId">ID заказа в системе службы доставки</param>
        /// <returns>результат ответа сервера с информацией о статусе</returns>
        public async Task<OrderStatusRequestResult> GetOrderStatusAsync(string orderId, RequestSettings rs = null) //t-ok
        {
            var r = (rs ?? RequestSettings.CreateNew()).SetJson();
            r.Body = _serializer.SerializeObject(new { OrderId = orderId });
            var url = _apiUrl + "/api/get_order_status?sid=@" + _securityToken;
            return await TryGetObjectAsync<OrderStatusRequestResult>(url, HttpMethod.Post, r);
        }
 
        //todo Не прверялось
        public bool GetOrdersDataPrint(List<string> orderIds, string saveAsFullPath, RequestSettings rs = null)
        {
            //здесь прописан путь из документации. для develop-режима не понятно где взять
            var url = "https://api.viasarci.com/api/get_orders_data_print?sid=@" + _securityToken;
            rs.Body = _serializer.SerializeObject(new { OrderIds = orderIds, Token = "@" + _securityToken });
            _httpLoader.DownloadFile(url, HttpMethod.Post, saveAsFullPath, rs ?? _defaultRequestSettings);
            return true;
        }

        //todo Это пока не возвращает ничего, кроме 504 Gateway Time-out
        public bool GetSticker(string orderUid, string saveAsFullPath, RequestSettings rs = null)
        {
            //здесь прописан путь из документации. для develop-режима не понятно где взять
            var url = $"https://pay.viasarci.com/sticker/{orderUid}?type=3";
            _httpLoader.DownloadFile(url, HttpMethod.Get, saveAsFullPath, rs ?? _defaultRequestSettings);
            return true;
        }

        /// <summary>
        /// Получение точек выдачи для карты в формате InSales
        /// </summary>
        /// <param name="body">InSalesPointListRequestBody</param>
        /// <returns>список объектов InSalesPoint</returns>
        public List<InSalesPoint> GetInsalesPointList(InSalesPointListRequestBody body, RequestSettings rs = null)
        {
            var r = (rs ?? RequestSettings.CreateNew());
            r.Body = _serializer.SerializeObject(body);
            //здесь прописан путь из документации. для develop-режима не понятно где взять
            var url = $"https://api.viasarci.com/insales/point-list?id={_shopId}";
            return TryGetObject<List<InSalesPoint>>(url, HttpMethod.Post, r);
        }

        //это не проверялось
        //пункт 6.5 документации
        public string GetInsalesOrder(InsalesOrderRequestBody order, string method, RequestSettings rs = null)
        {
            var r = (rs ?? RequestSettings.CreateNew());
            r.Body = _serializer.SerializeObject(order);
            var url = $"https://api.viasarci.com/insales-orders/{method}?id={_shopId}&sid=@{_securityToken}";
            var responseString = _httpLoader.GetString(url, HttpMethod.Post, r);
            return responseString;
        }

        private RefObjectRequestResult GetObjects(string type,
            long? masterId, long? limit, long? offset, RequestSettings rs = null, string language = "RU")
        {
            var r = (rs ?? RequestSettings.CreateNew()).SetJson();
            r.Body = _serializer.SerializeObject(new { Language = language, Type = type, Limit = limit, Offset = offset, MasterId = masterId });
            var url = _apiUrl + "/api/get_objects?sid=@" + _securityToken;
            return TryGetObject<RefObjectRequestResult>(url, HttpMethod.Post, r);
        }

        private async Task<RefObjectRequestResult> GetObjectsAsync(string type,
            long? masterId, long? limit, long? offset, RequestSettings rs = null, string language = "RU")
        {
            var r = (rs ?? RequestSettings.CreateNew()).SetJson();
            r.Body = _serializer.SerializeObject(new { Language = language, Type = type, Limit = limit, Offset = offset, MasterId = masterId });
            var url = _apiUrl + "/api/get_objects?sid=@" + _securityToken;
            return await TryGetObjectAsync<RefObjectRequestResult>(url, HttpMethod.Post, r);
        }
 
        private PickupPointsRequestResult GetPickupObjects(string type, 
            long? masterId, long? limit, long? offset, RequestSettings rs = null, string language = "RU")
        {
            var r = (rs ?? RequestSettings.CreateNew()).SetJson();
            r.Body = _serializer.SerializeObject(new { Language = language, Type = type, Limit = limit, Offset = offset, MasterId = masterId });
            var url = _apiUrl + "/api/get_objects?sid=@" + _securityToken;
            return TryGetObject<PickupPointsRequestResult>(url, HttpMethod.Post, r);
        }

        private async Task<PickupPointsRequestResult> GetPickupObjectsAsync(string type,
            long? masterId, long? limit, long? offset, RequestSettings rs = null, string language = "RU")
        {
            var r = (rs ?? RequestSettings.CreateNew()).SetJson();
            r.Body = _serializer.SerializeObject(new { Language = language, Type = type, Limit = limit, Offset = offset, MasterId = masterId });
            var url = _apiUrl + "/api/get_objects?sid=@" + _securityToken;
            return await TryGetObjectAsync<PickupPointsRequestResult>(url, HttpMethod.Post, r);
        }

        private T TryGetObject<T>(string url, HttpMethod httpMethod, RequestSettings rs)
            where T : class
        {
            var responseString = _httpLoader.GetString(url, httpMethod, rs ?? _defaultRequestSettings);
            if (string.IsNullOrWhiteSpace(responseString)) { throw new Exception("Возникла ошибка при отправке или при получении данных от сервера."); }
            var deserializedObject = AnswerToObject<T>(responseString, _serializer);
            if (deserializedObject == null) { throw new Exception($"Возникла ошибка при десериализации данных к типу {typeof(T)}. Данные: ({responseString})"); }
            return deserializedObject;
        }

        private async Task<T> TryGetObjectAsync<T>(string url, HttpMethod httpMethod, RequestSettings rs)
            where T : class
        {
            var responseString = await _httpLoader.GetStringAsync(url, httpMethod, rs ?? _defaultRequestSettings);
            if (string.IsNullOrWhiteSpace(responseString)) { throw new Exception("Возникла ошибка при отправке или при получении данных от сервера."); }
            var deserializedObject = AnswerToObject<T>(responseString, _serializer);
            if (deserializedObject == null) { throw new Exception($"Возникла ошибка при десериализации данных к типу {typeof(T)}. Данные: ({responseString})"); }
            return deserializedObject;
        }

        /// <summary>
        /// Create object from string
        /// </summary>
        /// <typeparam name="T">return Object Type</typeparam>
        /// <param name="text">string representation of serialized object</param>
        /// <param name="serializer">ISerializer</param>
        /// <returns>object or null if deserialization fails</returns>
        private T AnswerToObject<T>(string text, ISerializer serializer) 
            where T : class
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Нет данных для десериализации.");
            }
            try
            {
                if (typeof(T) == typeof(XmlDocument))
                {
                    var doc = new XmlDocument();
                    doc.LoadXml(text);
                    return doc as T;
                }
                else
                {
                    return serializer.DeserializeObject<T>(text);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
