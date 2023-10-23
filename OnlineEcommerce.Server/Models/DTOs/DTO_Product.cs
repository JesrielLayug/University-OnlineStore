using OnlineEcommerce.Server.Component_Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineEcommerce.Server.Models.DTOs
{
    public class DTO_Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BasePrice { get; set; }
        public List<ComponentProductImages> Images { get; set; }
        public List<ComponentProductVariant> Variants { get; set; }
        public string OrganizationName { get; set; } = "COOP";

    }
}
