namespace OnlineEcommerce.Server.Models
{
    public class Variant
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }
        public int Price { get; set; }
    }
}
