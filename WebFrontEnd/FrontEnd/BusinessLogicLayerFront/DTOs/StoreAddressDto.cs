using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.DTOs
{
    public class StoreAddressDto
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Street { get; set; }
        public string WardId { get; set; }
    }
}
