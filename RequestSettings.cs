using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaDeliveryLib
{
    /// <summary>
    /// Настройки для конкретного http запрса
    /// </summary>
    public class RequestSettings
    {
        /// <summary>
        /// Таймаут в мс, если -1, то нет его
        /// </summary>
        public int TimeoutMs { get; set; } = -1;
        public string UserAgent { get; set; } = string.Empty;
        public string Body { get; set; }
        public string Accept { get; set; }
        public Dictionary<string, string> Headers = new Dictionary<string, string>();
        public Dictionary<string, string> FormData { get; set; } = new Dictionary<string, string>();
        
        public RequestSettings SetJson()
        {
            Accept = "application/json";
            Headers.Add("Content-Type", "application/json");
            return this;
        }

        public static RequestSettings CreateNew()
        {
            return new RequestSettings();
        }
    }
}
