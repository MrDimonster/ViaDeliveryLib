using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
