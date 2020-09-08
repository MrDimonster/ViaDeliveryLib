using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ViaDeliveryLib
{
    /// <summary>
    /// Интерфейс для работы с http-запросами
    /// </summary>
    public interface IHttpLoader
    {
        /// <summary>
        /// Возвращает результат ответа сервера в виде строки
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpMethod"></param>
        /// <param name="requestSettings"></param>
        /// <param name="spt"></param>
        /// <returns></returns>
        string GetString(string url, HttpMethod httpMethod, RequestSettings requestSettings, SecurityProtocolType spt = SecurityProtocolType.Tls12);

        /// <summary>
        /// Возвращает результат ответа сервера в виде строки асинхронно
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpMethod"></param>
        /// <param name="requestSettings"></param>
        /// <param name="spt"></param>
        /// <returns></returns>
        Task<string> GetStringAsync(string url, HttpMethod httpMethod, RequestSettings requestSettings, SecurityProtocolType spt = SecurityProtocolType.Tls12);

        /// <summary>
        /// Получение файла от сервера и его сохранение на диск
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpMethod"></param>
        /// <param name="saveToFullPath"></param>
        /// <param name="requestSettings"></param>
        /// <param name="spt"></param>
        /// <returns></returns>
        bool DownloadFile(string url, HttpMethod httpMethod, string saveToFullPath, RequestSettings requestSettings, SecurityProtocolType spt = SecurityProtocolType.Tls12);
    }
}
