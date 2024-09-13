using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public int AddressId { get; set; }
        public string RecipientName { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string Note {  get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public double TotalMoney { get; set; }
    }
}
