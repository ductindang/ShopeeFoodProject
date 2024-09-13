using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class UserAddressDetailDto
    {
        public string NameReminiscent { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetName { get; set; }
        public string WardName { get; set; }
        public string DistrictName { get; set; }
        public string ProvinceName { get; set; }
    }
}
