using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BaseRequests
{
    public class BaseStore
    {
        public string Name { get; set; }
        public double MaxPrice { get; set; }
        public string Image { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string Description { get; set; }
        public int CategoryId {  get; set; }
        public int SubCategoryId {  get; set; }
    }
}
