
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;
using OnlineEcommerce.Server.Services.Contracts;

namespace OnlineEcommerce.Server.Pages.Product
{
    public class AddProductBase : ComponentBase
    {
        public DTO_AddProduct product = new DTO_AddProduct();

		public class KanbanTaskItem
		{
			public string Name { get; init; }
			public string Status { get; set; }

			public KanbanTaskItem(string name, string status)
			{
				Name = name;
				Status = status;
			}
		}

	}
}
