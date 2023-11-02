using Microsoft.AspNetCore.Components;
using MudBlazor;
using OnlineEcommerce.Server.Models.DTOs;
using OnlineEcommerce.Server.Services.Contracts;

namespace OnlineEcommerce.Server.Pages.Product.Components
{
    public class DeleteProductDialogBase : ComponentBase
    {
        [Inject]
        IProductService ProductService { get; set; }

        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        public bool _processing = false;

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter] public DTO_Product product {get; set; }

        public async void Submit()
        {
            _processing = true;
            await Task.Delay(1000);
            Snackbar.Clear();
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;

            var response = await ProductService.Delete(product);
            if(response.IsSuccess)
            {
                _processing = false;
                Snackbar.Add(response.StatusMessage, Severity.Success);
                NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
                MudDialog.Close(DialogResult.Ok(true));
            }
            else
            {
                _processing = false;
                Snackbar.Add("Error deleting the product from the server", Severity.Warning);
                NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
                MudDialog.Close(DialogResult.Ok(true));
            }
        }
        public void Cancel() => MudDialog.Cancel();
    }
}
