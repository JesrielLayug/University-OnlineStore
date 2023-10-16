using System.ComponentModel.DataAnnotations;

namespace OnlineEcommerce.Server.Models.DTOs
{
    public class DTO_Variant
    {
        [Required]
        public string Attribute { get; set; }  

        [Required]
        public string Value { get; set; }
        [Required]
        public int Price { get; set; }

    }
}
