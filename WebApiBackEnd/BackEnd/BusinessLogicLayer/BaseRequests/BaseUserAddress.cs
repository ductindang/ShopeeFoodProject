using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BaseRequests
{
    public class BaseUserAddress
    {
        public int UserId { get; set; }
        public string Street { get; set; }
        public string WardId { get; set; }
        public string NameReminiscent { get; set; }
        public string PhoneNumber { get; set; }
    }
}
