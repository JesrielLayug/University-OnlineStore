using System.ComponentModel.DataAnnotations;

namespace OnlineEcommerce.Server.Models.DTOs
{
    public class DTO_AddVariant
    {
        [Required]
        public string AttributeName { get; set; }  

        [Required]
        public string Value { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}
