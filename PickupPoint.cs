namespace ViaDeliveryLib
{
    /// <summary>
    /// Точка доставки
    /// </summary>
    public class PickupPoint
    {
        /// <summary>
        /// Код точки доставки
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Название, пример: "X634 - Пятерочка"
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ??? пока не точно, но видимо это дни работы
        /// </summary>
        public string OpenDate { get; set; } //todo уточнить
        /// <summary>
        /// ??? есть только пример "Europe\/Moscow"
        /// </summary>
        public string Timezone { get; set; } //todo уточнить
        /// <summary>
        /// Широта, пример: "55.42893018"
        /// </summary>
        public string Lat { get; set; }
        /// <summary>
        /// Долгота, пример: "37.27417012"
        /// </summary>
        public string Lng { get; set; }
        /// <summary>
        /// Макс. вес доставки в миллиграммах?
        /// </summary>
        public long? MaxWeight { get; set; } //todo уточнить
        /// <summary>
        /// Макс. ширина доставки в миллиметрах?
        /// </summary>
        public long? MaxCellWidth { get; set; } //todo уточнить в миллиметрах?
        /// <summary>
        /// Макс. высота доставки в миллиметрах?
        /// </summary>
        public long? MaxCellHeight { get; set; } //todo уточнить в миллиметрах?
        /// <summary>
        /// Макс. длина доставки в миллиметрах?
        /// </summary>
        public long? MaxCellLength { get; set; } //todo уточнить в миллиметрах?
        /// <summary>
        /// Возможна оплата картой
        /// </summary>
        public bool? CardAllowed { get; set; }
        /// <summary>
        /// Возможен возврта
        /// </summary>
        public bool? ReturnAllowed { get; set; }
        /// <summary>
        /// Код?
        /// </summary>
        public long? Zipcode { get; set; } //todo уточнить что это
        /// <summary>
        /// Числовой код страны
        /// </summary>
        public long? Country { get; set; }
        /// <summary>
        /// Числовой код региона
        /// </summary>
        public long? Region { get; set; }
        /// <summary>
        /// Числовой код города
        /// </summary>
        public long? City { get; set; }
        /// <summary>
        /// Числовой код улицы
        /// </summary>
        public long? Street { get; set; }
        /// <summary>
        /// Числовой код чего-то
        /// </summary>
        public long? PickupCategory { get; set; } //todo уточнить что это
        /// <summary>
        /// Номер дома, строение
        /// </summary>
        public string Building { get; set; }
        /// <summary>
        /// Полный адрес, пример: "г.Москва, с.Красная Пахра, Калужское ш, 4 "
        /// </summary>
        public string FullAddress { get; set; }
    }
}
