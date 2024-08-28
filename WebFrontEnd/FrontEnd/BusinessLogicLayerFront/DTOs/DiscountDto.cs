namespace BusinessLogicLayerFront.DTOs
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; } = 1;
        public string Image { get; set; }
    }
}
