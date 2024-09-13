using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BaseRequests
{
    public class BaseOrderDetail
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public double TotalMoney { get; set; }
    }
}
