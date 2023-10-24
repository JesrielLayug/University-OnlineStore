using System.ComponentModel.DataAnnotations;

namespace OnlineEcommerce.Server.Component_Models
{
    public class ComponentProductDetail
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
