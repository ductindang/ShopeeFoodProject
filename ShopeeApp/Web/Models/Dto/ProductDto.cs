
namespace Web.Models.Dto
{
    public class ProductDto
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int StoreId { get; set; }
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
