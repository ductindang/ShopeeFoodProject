using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("UserAddress")]
    public class UserAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string Street { get; set; }
        public string WardId { get; set; }
        public string NameReminiscent { get; set; }
        public string PhoneNumber { get; set; }

    }
}
