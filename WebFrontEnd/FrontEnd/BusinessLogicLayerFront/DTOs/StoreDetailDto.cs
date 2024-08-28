using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.DTOs
{
    public class StoreDetailDto
    {
        public int StoreId {  get; set; }
        public string StoreName { get; set; }
        public double StoreMaxPrice {  get; set; }
        public string StoreImage { get; set; }
        public TimeSpan StoreOpenTime { get; set; }
        public TimeSpan StoreCloseTime { get; set; }
        public string StoreDescription { get; set; }
        public string StreetName { get; set; }
        public string WardName { get; set; }
        public string DistrictName { get; set; }
        public string ProvinceName { get; set; }
    }
}
