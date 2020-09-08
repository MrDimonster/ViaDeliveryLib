using System;
using System.Linq;

namespace ViaDeliveryLib
{
    public static class Example
    {
        public static void Run()
        {
            var develop = true;

            var shopId = develop ? "YOUR_DEVELOP_SHOP_ID" : "YOUR_SHOP_ID";
            var securityToken = develop ? "YOUR_DEVELOP_SECURITY_TOKEN" : "YOUR_SECURITY_TOKEN";
            var apiUrl = develop ? "https://dev-api.viasarci.com" : "https://api.viasarci.com";

            var client = new Client(shopId, securityToken, apiUrl);

            var pointForMapParams = new ApiParameters
            {
                MinLat = 55.30077916694387m,
                MaxLat = 56.200586833056136m,
                MinLng = 36.974153699712836m,
                MaxLng = 38.26083830028717m
            };

            var countriesAsync = client.GetCountriesAsync()
                .ContinueWith(x => Console.WriteLine($"1.Countries count async: {x.Result.Data.Count}"));

            var regionsAsync = client.GetRegionsAsync(2947)
                .ContinueWith(x => Console.WriteLine($"2. Regions count async: {x.Result.Data.Count}"));

            var citiesAsync = client.GetCitiesAsync(2997)
                .ContinueWith(x => Console.WriteLine($"3. Cities count async: {x.Result.Data.Count}"));

            var streetsAsync = client.GetStreetsAsync(7341)
                .ContinueWith(x => Console.WriteLine($"4. Streets count async: {x.Result.Data.Count}"));

            var pickupPointsAsync = client.GetPickupPointsAsync(7342)
                .ContinueWith(x => Console.WriteLine($"5. Pickup Points count async: {x.Result.Data.Count}"));

            var testDeliveryAsync = TestObjects.Delivery;
            testDeliveryAsync.Id = Guid.NewGuid().ToString();
            var createDeliveryAsync = client.CreateDeliveryGetIdAsync(testDeliveryAsync)
                .ContinueWith(x => Console.WriteLine($"6. Create delivery async id: {x.Result}")); //some guid

            var orderStatusAsync = client.GetOrderStatusAsync("ORDER_ID")
                    .ContinueWith(x => Console.WriteLine($"7. Order status async: {x.Result.Data.Status}"));//REJECTED

            var pickupPointsForMapAsync = client.GetDeliveryPointsAsync(pointForMapParams)
                    .ContinueWith(x => Console.WriteLine($"8. Pickup Points count async: {x.Result.Count}"));

            var pickupPointByIdAsync = client.GetDeliveryPointByIdAsync("POINT_ID")
                    .ContinueWith(x => Console.WriteLine($"9. Delivery point async: {x.Result.Partner}"));

            var geoAsync = client.GetGeoDictionaryVariantsAsync(GeoType.City, "кин", "", "Московская область")
                    .ContinueWith(x => Console.WriteLine($"10. Geo async count :{x.Result.Count}"));

            var countries = client.GetCountries().Data;
            Console.WriteLine($"1. Countries count: {countries.Count}"); //253

            var regions = client.GetRegions(2947).Data;
            Console.WriteLine($"2. Regions count: {regions.Count}"); //101

            var cities = client.GetCities(2997).Data;
            Console.WriteLine($"3. Cities count: {cities.Count}"); //42

            var streets = client.GetStreets(7341).Data;
            Console.WriteLine($"4. Streets count: {streets.Count}"); //1

            var pickupPoints = client.GetPickupPoints(7342).Data;
            Console.WriteLine($"5. Pickup Points count: {pickupPoints.Count}"); //3

            var testDelivery = TestObjects.Delivery;
            testDelivery.Id = Guid.NewGuid().ToString();
            var createDelivery = client.CreateDeliveryGetId(testDelivery);
            Console.WriteLine($"6. Create delivery id: {createDelivery}"); //some guid

            var orderStatus = client.GetOrderStatus("ORDER_ID").Data;
            Console.WriteLine($"7. Order status: {orderStatus.Status}"); //REJECTED

            var pickupPointsForMap = client.GetDeliveryPoints(pointForMapParams);
            Console.WriteLine($"8. Pickup Points count: {pickupPointsForMap.Count}"); //1704

            var pickupPointById = client.GetDeliveryPointById("POINT_ID");
            Console.WriteLine($"9. Delivery point: {pickupPointById.Partner}"); //Tobacco

            var geo = client.GetGeoDictionaryVariants(GeoType.City, "кин", "", "Московская область");
            Console.WriteLine($"10. Geo count : {geo.Count}"); //13
        }
    }
}
