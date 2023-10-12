using System.ComponentModel.DataAnnotations;

namespace OnlineEcommerce.Server.Models.DTOs
{
    public class DTO_AddProductVariant
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int VariantId { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public int PriceModifier { get; set; }
    }
}
