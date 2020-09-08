using Newtonsoft.Json; //todo Этого получилось бы избежать...

namespace ViaDeliveryLib
{
    /// <summary>
    /// Объект, описывающий стоимость посылки
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Валюта расчёта стоимости
        /// </summary>
        public string Currency { get; set; } = "RUB";
        /// <summary>
        /// стоимость товара
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// Стоимость доставки
        /// </summary>
        [JsonProperty("deliveryCost")] //todo soo good... single style... imho delivery_cost
        public decimal deliveryCost { get; set; }
        /// <summary>
        /// Тип оплаты, пример: "PREPAYMENT"
        /// </summary>
        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }
        /// <summary>
        /// Значение НДС, пример: 20
        /// </summary>
        public int Vat { get; set; }
    }
}
