using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ViaDeliveryLib;
using Xunit;

namespace Tests
{
    public class Tests : BaseClientTest
    {
        public Tests(): base(useFakeClient: false) { }
        [Fact]
        public void GetCountriesTests()
        {
            var countries = _client.GetCountries();
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
        public void GetRegionsTests()
        {
            var masterId = 2947;
            var regions = _client.GetRegions(masterId);
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
        public void GetCitiesTests()
        {
            var masterId = 2997;
            var cities = _client.GetCities(masterId);
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
        public void GetStreetsTests()
        {
            var masterId = 7341;
            var streets = _client.GetStreets(masterId);
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
        public void GetPickupPointsTests()
        {
            var masterId = 7342;
            var pickupPoints = _client.GetPickupPoints(masterId);
            var status = pickupPoints.Status;
            Assert.Equal("ok", status, ignoreCase: true);
        }

        [Fact]
        public void GetDeliveryPointsTests()
        {
            var pointForMapParams = new ApiParameters
            {
                MinLat = 55.30077916694387m,
                MaxLat = 56.200586833056136m,
                MinLng = 36.974153699712836m,
                MaxLng = 38.26083830028717m
            };

            var deliveryPoints = _client.GetDeliveryPoints(pointForMapParams);
            var first = deliveryPoints.FirstOrDefault();
            Assert.True(deliveryPoints != null);
            Assert.True(deliveryPoints.Count > 0);
            Assert.True(first != null && !string.IsNullOrWhiteSpace(first.Id)
                &&  first.Lat > 0 && first.Lng > 0);

        }

        [Fact]
        public void GetGeoDictionaryVariantsTests()
        {
            var geo = _client.GetGeoDictionaryVariants(ViaDeliveryLib.Enums.GeoType.City,
                "кин", "", "Московская область");
            Assert.True(geo != null && geo.Count > 0);
        }


        
    }
}
