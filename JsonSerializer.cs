using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ViaDeliveryLib
{
    /// <summary>
    /// Сериализатор для работы с Json со специфическими
    /// настройками, связанными с видом данных, используемых
    /// в апи поставщика услуг
    /// </summary>
    public class JsonSerializer : ISerializer
    {
        private JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            },
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
        };
        public T DeserializeObject<T>(string data) => JsonConvert.DeserializeObject<T>(data, SerializerSettings);
        public string SerializeObject(object value) => value == null ? "" : JsonConvert.SerializeObject(value, SerializerSettings);
    }
}
