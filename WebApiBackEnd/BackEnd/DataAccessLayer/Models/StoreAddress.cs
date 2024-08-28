using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("StoreAddress")]
    public class StoreAddress
    {
        [Key]
        public int Id { get; set; }
        public int StoreId {  get; set; }
        public string Street { get; set; }
        public string WardId {  get; set; }
    }
}
