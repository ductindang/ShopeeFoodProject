using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage {  get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public double TotalMoney { get; set; }
    }
}
