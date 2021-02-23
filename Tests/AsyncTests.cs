using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ViaDeliveryLib;
using Xunit;

namespace Tests
{
    public class AsyncTests : BaseClientTest
    {
        public AsyncTests() : base(useFakeClient: false){ }
        [Fact]
        public async Task GetCountriesAsyncTests()
        {
            var countries = await _client.GetCountriesAsync();
            var status = countries.Status;
            var data = countries.Data;
            var firstData = data?.FirstOrDefault();
            Assert.Equal("ok", status, ignoreCase: true);
            Assert.True(data != null && data.Count > 0);
            Assert.True(firstData != null);
            Assert.True(!string.IsNullOrWhiteSpace(firstData.Id));
            Assert.True(!string.IsNullOrWhiteSpace(firstData.Name));
        }

        [Fact]
        public async Task GetRegionsAsyncTests()
        {
            var masterId = 2947;
            var regions = await _client.GetRegionsAsync(masterId);
            var status = regions.Status;
            var data = regions.Data;
            var firstData = data?.FirstOrDefault();
            Assert.Equal("ok", status, ignoreCase: true);
            Assert.True(data != null && data.Count > 0);
            Assert.True(firstData != null);
            Assert.True(!string.IsNullOrWhiteSpace(firstData.Id));
            Assert.True(!string.IsNullOrWhiteSpace(firstData.Name));
        }

        [Fact]
        public async Task GetCitiesAsyncTests()
        {
            var masterId = 2997;
            var cities = await _client.GetCitiesAsync(masterId);
            var status = cities.Status;
            var data = cities.Data;
            var firstData = data?.FirstOrDefault();
            Assert.Equal("ok", status, ignoreCase: true);
            Assert.True(data != null && data.Count > 0);
            Assert.True(firstData != null);
            Assert.True(!string.IsNullOrWhiteSpace(firstData.Id));
            Assert.True(!string.IsNullOrWhiteSpace(firstData.Name));
        }

        [Fact]
        public async Task GetStreetsAsyncTests()
        {
            var masterId = 7341;
            var streets = await _client.GetStreetsAsync(masterId);
            var status = streets.Status;
            var data = streets.Data;
            var firstData = data?.FirstOrDefault();
            Assert.Equal("ok", status, ignoreCase: true);
            Assert.True(data != null && data.Count > 0);
            Assert.True(firstData != null);
            Assert.True(!string.IsNullOrWhiteSpace(firstData.Id));
            Assert.True(!string.IsNullOrWhiteSpace(firstData.Name));
        }

        [Fact]
        public async Task GetPickupPointsAsyncTests()
        {
            var masterId = 7342;
            var pickupPoints = await _client.GetPickupPointsAsync(masterId);
            var status = pickupPoints.Status;
            Assert.Equal("ok", status, ignoreCase: true);
        }

        [Fact]
        public async Task GetDeliveryPointsAsyncTests()
        {
            var pointForMapParams = new ApiParameters
            {
                MinLat = 55.30077916694387m,
                MaxLat = 56.200586833056136m,
                MinLng = 36.974153699712836m,
                MaxLng = 38.26083830028717m
            };

            var deliveryPoints = await _client.GetDeliveryPointsAsync(pointForMapParams);
            var first = deliveryPoints.FirstOrDefault();
            Assert.True(deliveryPoints != null);
            Assert.True(deliveryPoints.Count > 0);
            Assert.True(first != null && !string.IsNullOrWhiteSpace(first.Id)
                &&  first.Lat > 0 && first.Lng > 0);

        }

        [Fact]
        public async Task GetGeoDictionaryVariantsAsyncTests()
        {
            var geoAsync = await _client.GetGeoDictionaryVariantsAsync(ViaDeliveryLib.Enums.GeoType.City,
                "кин", "", "Московская область");
            Assert.True(geoAsync != null && geoAsync.Count > 0);
        }

        [Fact]
        public async Task GetCountriesWhenAllAsyncTests()
        {
            var countries1Task = _client.GetCountriesAsync();
            var countries2Task = _client.GetCountriesAsync();
            var countries3Task = _client.GetCountriesAsync();
            await Task.WhenAll(countries1Task, countries2Task, countries3Task);
            var result = 0;
            try
            {
                result += countries1Task.Result.Data.Count;
            }
            catch{ }
            try
            {
                result += countries1Task.Result.Data.Count;
            }
            catch { }
            try
            {
                result += countries1Task.Result.Data.Count;
            }
            catch { }
 
            Assert.True(result > 0);
             
        }

    }
}
