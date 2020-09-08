using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaDeliveryLib
{
    public class RefObjectRequestResult
    {
        public string Status { get; set; }
        public List<RefObject> Data { get; set; }
    }
}
