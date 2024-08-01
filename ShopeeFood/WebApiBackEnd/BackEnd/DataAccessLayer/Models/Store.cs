using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("Store")]
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Image { get; set; }
        public TimeOnly OptenTime { get; set; }
        public TimeOnly CloseTime { get; set; }
        public string Description { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
    }
}
