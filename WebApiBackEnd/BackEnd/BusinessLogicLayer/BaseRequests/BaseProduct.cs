using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BaseRequests
{
    public class BaseProduct
    {
        public int CategoryId { get; set; }
        //public Category Category { get; set; }
        public int SubCategoryId { get; set; }
        //public SubCategory SubCategory { get; set; }
        public int StoreId { get; set; }
        //public Store Store { get; set; }
        public int? DiscountId { get; set; }
        //public Discount? Discount { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public virtual Discount? Discount { get; set; }
    }
}
