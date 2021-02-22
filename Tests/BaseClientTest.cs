using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaDeliveryLib;

namespace Tests
{
    public class BaseClientTest
    {
        protected Client _client;
        private string _settingsFolder = @"C:\CS\viadelivery_settings\";
        public BaseClientTest()
        {
            var shopId = App("ShopId");
            if (string.IsNullOrWhiteSpace(shopId))
            {
                throw new Exception("ctor BaseClientTest error: shopId is empty");
            }
            var securityToken = App("SecurityToken");
            if (string.IsNullOrWhiteSpace(securityToken))
            {
                throw new Exception("ctor BaseClientTest error: securityToken is empty");
            }
            var apiUrl = App("ApiUrl");
            if (string.IsNullOrWhiteSpace(apiUrl))
            {
                throw new Exception("ctor BaseClientTest error: apiUrl is empty");
            }
            _client = new Client(shopId, securityToken, apiUrl);
        }

        protected string App(string key)
        {
            return ReadFile(Path.Combine(_settingsFolder, key + ".txt"));
        }

        protected string ReadFile(string file)
        {
            try 
            { 
                return File.ReadAllText(file);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
