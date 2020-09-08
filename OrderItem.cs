using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaDeliveryLib
{
    /// <summary>
    /// Товар в посылке
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Количество товара
        /// </summary>
        public int Value { get; set; } //todo imho must bee Quantity or Number
        /// <summary>
        /// Значение НДС
        /// </summary>
        public int Vat { get; set; }
        /// <summary>
        /// Товара в системе контрагента
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Баркод товара (опционально)
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// Номер грузовой таможенной декларации (опционально)
        /// </summary>
        public string CodeGTD { get; set; }
        /// <summary>
        /// Номер товарной номенклатуры внешнеэкономической деятельности (опционально)
        /// </summary>
        public string CodeTNVED { get; set; }
        /// <summary>
        /// Страна происхождения товара (опционально)
        /// </summary>
        public string Country { get; set; }
    }
}
