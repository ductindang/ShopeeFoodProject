using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public SubCategory SubCategory { get; set; }

        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public Store Store { get; set; }

        public int? DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public Discount Discount { get; set; }

        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
