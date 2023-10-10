using System.ComponentModel.DataAnnotations;

namespace OnlineEcommerce.Server.Models
{
    public class VariantAttribute
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
