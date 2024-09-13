using BusinessLogicLayer.BaseRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Requests
{
    public class OrderDetailRequest : BaseOrderDetail
    {
        public int Id { get; set; }
    }
}
