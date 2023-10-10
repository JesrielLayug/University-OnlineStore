using System.ComponentModel.DataAnnotations;

namespace OnlineEcommerce.Server.Models.DTOs
{
    public class DTO_AddProduct
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public string OrganizationName { get; set; }
    }
}
