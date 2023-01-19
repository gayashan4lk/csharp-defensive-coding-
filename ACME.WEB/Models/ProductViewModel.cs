namespace ACME.WEB.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Price { get; set; }
        public string Cost { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string? Reason { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
