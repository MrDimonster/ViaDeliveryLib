namespace ViaDeliveryLib
{
    /// <summary>
    /// Точка пункта выдачи для карты
    /// </summary>
    public class DeliveryPoint
    {
        /// <summary>
        /// Идентификатор точки
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Имя пртнера
        /// </summary>
        public string Partner { get; set; }
        /// <summary>
        /// Тип точки
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Широта для карты
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// Долгота для карты
        /// </summary>
        public double Lng { get; set; }
        /// <summary>
        /// Описание к пункту выдачи
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Дней доставки 
        /// </summary>
        public int DeliveryTime { get; set; }
        /// <summary>
        /// Время работы с
        /// </summary>
        public string WorkingTimeFrom { get; set; }
        /// <summary>
        /// Время работы по
        /// </summary>
        public string WorkingTimeTo { get; set; }
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// Номер дома, строения
        /// </summary>
        public string Building { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Регион
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Код страны
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Стоимость доставки
        /// </summary>
        public decimal Price { get; set; }
    }
}
