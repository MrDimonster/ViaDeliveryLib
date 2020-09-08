using System.Collections.Generic;

namespace ViaDeliveryLib
{
    /// <summary>
    /// Объект параметров для получения точек для карты
    /// </summary>
    public class ApiParameters
    {
        /// <summary>
        /// id дилера (магазина), может быть пустым. Этот параметр определяет расчет цен через настраиваемые правила конкретного магазина
        /// </summary>
        public string Id { get; set; } = "test";
        /// <summary>
        /// вес в граммах
        /// </summary>
        public int WeightGramms { get; set; }
        /// <summary>
        /// стоимость заказа
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// город
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// область
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// код страны
        /// </summary>
        public string CountryCode { get; set; } = "RU";
        /// <summary>
        /// тип точек (POSTAMAT, TOBACCO)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// имя партнера (Tobacco, Pulse Express - Халва, Engy, Deep)
        /// </summary>
        public string Partner { get; set; }
        /// <summary>
        /// для области координат. работают только если заданы все 4
        /// </summary>
        public decimal? MinLng { get; set; }
        /// <summary>
        /// для области координат. работают только если заданы все 4
        /// </summary>
        public decimal? MaxLng { get; set; }
        /// <summary>
        /// для области координат. работают только если заданы все 4
        /// </summary>
        public decimal? MinLat { get; set; }
        /// <summary>
        /// для области координат. работают только если заданы все 4
        /// </summary>
        public decimal? MaxLat { get; set; }
        /// <summary>
        /// Y/N включает режим показа других городов этого же региона. Если установлен 'Y', то при запросе какого-то города в Краснодарском крае в котором нет ПВЗ, будут отображены все ПВЗ Краснодарского края, если N то честно вернет пустой список.
        /// </summary>
        public bool? RegionCities { get; set; }
        /// <summary>
        /// При наличие GET параметра 'insales', метод попытается взять данные из POST payload формата InSales при запроска списка ПВЗhttps://map-api.viadelivery.pro/point-list
        /// </summary>
        public string InSales { get; set; }

        /// <summary>
        /// Возвращает строку запроса типа ?min_lat=55.30077916694387&min_lng=36.974153699712836&max_lat=56.200586833056136&max_lng=38.26083830028717
        /// </summary>
        /// <returns></returns>
        public string ToUrlQuery()
        {
            var list = new List<string>(15);
            if (!string.IsNullOrWhiteSpace(Id)) list.Add($"id={Id}");
            if (WeightGramms > 0) list.Add($"weight={WeightGramms.ToString()}");
            if (OrderPrice > 0) list.Add($"order_price={OrderPrice.ToString()}");
            if (!string.IsNullOrWhiteSpace(City)) list.Add($"city={City}");
            if (!string.IsNullOrWhiteSpace(Region)) list.Add($"region={Region}");
            if (!string.IsNullOrWhiteSpace(CountryCode)) list.Add($"country={CountryCode}");
            if (!string.IsNullOrWhiteSpace(Type)) list.Add($"type={Type}");
            if (!string.IsNullOrWhiteSpace(Partner)) list.Add($"partner={Partner}");
            if (MinLng.HasValue && MaxLng.HasValue && MinLat.HasValue && MaxLat.HasValue)
            {
                list.Add($"min_lng={MinLng.ToString().Replace(",", ".")}");
                list.Add($"max_lng={MaxLng.ToString().Replace(",", ".")}");
                list.Add($"min_lat={MinLat.ToString().Replace(",", ".")}");
                list.Add($"max_lat={MaxLat.ToString().Replace(",", ".")}");
            }
            if (RegionCities.HasValue)
            {
                list.Add($"region_cities={(RegionCities.Value ? "Y" : "N")}");
            }
            if (!string.IsNullOrWhiteSpace(InSales)) list.Add($"insales={InSales}");
            return "?" + string.Join("&", list);
        }
    }
}
