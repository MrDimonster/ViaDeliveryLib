using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaDeliveryLib
{
    /// <summary>
    /// Объект, описывающий параметры посылки
    /// </summary>
    public class Package
    {
        /// <summary>
        /// Высота посылки (в миллиметрах)
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Длина посылки (в миллиметрах)
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// Вес посылки (в миллиграммах!!!)
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// Ширина посылки (в миллиметрах)
        /// </summary>
        public int Width { get; set; }
    }
}
