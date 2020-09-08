namespace ViaDeliveryLib
{
    /// <summary>
    /// Получатель
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// ФИО получателя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// адрес электронной почты получателя
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// контактный телефон получателя
        /// </summary>
        public string Phone { get; set; }
    }
}
