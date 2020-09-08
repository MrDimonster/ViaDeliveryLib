using Newtonsoft.Json;
using System.Collections.Generic;

namespace ViaDeliveryLib
{
    /// <summary>
    /// Объект доставки
    /// </summary>
    public class Delivery
    {
        /// <summary>
        /// UUID точки отправки, полученный из запроса get_objects (pickup_points)
        /// </summary>
        public string Point { get; set; }
        /// <summary>
        /// внутренний ID отправки в системе контрагента (будет напечатан на коробке)
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// название сервиса, который будет предоставлен (DELIVERY, PAYONDELIVERY)
        /// </summary>
        public string Service { get; set; }
        /// <summary>
        /// объект, описывающий параметры посылки
        /// </summary>
        public Package Package { get; set; }
        /// <summary>
        /// объект, описывающий стоимость посылки
        /// </summary>
        public Payment Payment { get; set; }
        /// <summary>
        /// массив объектов товаров в посылке
        /// </summary>
        public List<OrderItem> Goods { get; set; }
        /// <summary>
        /// объект, описывающий получателя
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// Дата доставки посылки на склад, пример: "2021-01-01"
        /// </summary>
        [JsonProperty("shipDate")]
        public string ShipDate { get; set; }
        /// <summary>
        /// Действия, в случае невозможности доставки, пример: "RETURN"
        /// </summary>
        public string Undeliverable { get; set; }
    }
}
