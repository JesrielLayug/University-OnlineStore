
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazor.Utilities;
using OnlineEcommerce.Server.Component_Models;
using OnlineEcommerce.Server.Element_Models;
using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;
using OnlineEcommerce.Server.Services.Contracts;
using System.Threading.Tasks;

namespace OnlineEcommerce.Server.Pages.Product
{
    public class AddProductBase : ComponentBase
    {
        public DTO_Product product = new DTO_Product();
        public List<ComponentProductVariant> SizeVariants = new List<ComponentProductVariant>();
        public ComponentProductVariant size = new ComponentProductVariant();

        public void AddSize()
        {
            SizeVariants.Add(size);
        }
        public void RemoveSize(MudChip chip) => SizeVariants.Remove(size);
	}
}

