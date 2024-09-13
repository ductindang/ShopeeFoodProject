using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("Product_Menu")]
    public class MenuProduct
    {
        public int MenuId {  get; set; }
        public int ProductId { get; set; }
        public string Description {  get; set; }
    }
}
