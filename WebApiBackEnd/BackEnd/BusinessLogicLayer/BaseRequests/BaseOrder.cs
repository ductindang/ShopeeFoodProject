using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BaseRequests
{
    public class BaseOrder
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public int AddressId { get; set; }
        public string RecipientName {  get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string Note { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public double TotalMoney { get; set; }
    }
}
