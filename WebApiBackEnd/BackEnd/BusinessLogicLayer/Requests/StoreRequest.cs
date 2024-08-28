using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.BaseRequests;

namespace BusinessLogicLayer.Requests
{
    public class StoreRequest : BaseStore
    {
        public int Id { get; set; }
    }
}
