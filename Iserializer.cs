namespace ViaDeliveryLib
{
    /// <summary>
    /// Интерфейс компонентов для сериализации и десериализации
    /// </summary>
    public interface ISerializer
    {
        T DeserializeObject<T>(string data);
        string SerializeObject(object value);
    }
}
