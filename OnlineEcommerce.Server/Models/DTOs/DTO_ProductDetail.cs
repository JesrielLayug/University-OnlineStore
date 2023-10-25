using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineEcommerce.Server.Models.DTOs
{
    public class DTO_ProductDetail
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Base price")]
        public int BasePrice { get; set; }
    }
}
