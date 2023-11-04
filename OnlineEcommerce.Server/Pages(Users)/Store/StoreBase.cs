using Microsoft.AspNetCore.Components;
using OnlineEcommerce.Server.Models.DTOs;
using OnlineEcommerce.Server.Services.Contracts;

namespace OnlineEcommerce.Server.Pages_Users_.Store
{
    public class StoreBase : ComponentBase
    {
        [Inject]
        IOrganizationService OrganizationService { get; set; }

        public IEnumerable<DTO_Organization> OrganizationList = new List<DTO_Organization>();


        protected override async Task OnInitializedAsync()
        {
            OrganizationList = await OrganizationService.GetAll();
        }
    }
}
