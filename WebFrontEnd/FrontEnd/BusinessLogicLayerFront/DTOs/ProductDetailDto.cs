using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.DTOs
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription {  get; set; }
        public string StoreName { get; set; }
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
