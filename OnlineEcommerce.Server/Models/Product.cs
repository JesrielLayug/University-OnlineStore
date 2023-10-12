namespace OnlineEcommerce.Server.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int OrganizationId { get; set; }
    }
}
