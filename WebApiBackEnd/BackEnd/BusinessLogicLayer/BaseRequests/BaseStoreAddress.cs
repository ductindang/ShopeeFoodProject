using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BaseRequests
{
    public class BaseStoreAddress
    {
        public int StoreId { get; set; }
        public string Street { get; set; }
        public string WardId { get; set; }
    }
}
