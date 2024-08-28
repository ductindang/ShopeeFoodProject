using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.DTOs
{
    public class StoreDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Image { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string Description { get; set; }
        public int CategoryId {  get; set; }
        public int SubCategoryId {  get; set; }
    }
}
