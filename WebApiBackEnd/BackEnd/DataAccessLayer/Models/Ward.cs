using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("Ward")]
    public class Ward
    {
        [Key]
        public string Id {  get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string DistrictId { get; set; }
    }
}
