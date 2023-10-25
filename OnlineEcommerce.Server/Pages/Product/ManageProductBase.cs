using Microsoft.AspNetCore.Components;
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Pages.Product
{
    public class ManageProductBase : ComponentBase
    {
        public DTO_Product selectedProduct = null;
        public HashSet<DTO_Product> selectedProducts = new HashSet<DTO_Product>();
        public IEnumerable<DTO_Product> Products = new List<DTO_Product>();
    }
}
