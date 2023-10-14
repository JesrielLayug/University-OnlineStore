
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using OnlineEcommerce.Server.Element_Models;
using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;
using OnlineEcommerce.Server.Services.Contracts;
using System.Threading.Tasks;

namespace OnlineEcommerce.Server.Pages.Product
{
    public class AddProductBase : ComponentBase
    {
        public DTO_AddProduct product = new DTO_AddProduct();
        public DTO_AddVariant variant = new DTO_AddVariant();

        [Inject]
        public IVariantAttributeService attributeService { get; set; }
        public IEnumerable<VariantAttribute> variantAttribute { get; set; }

		protected override async Task OnInitializedAsync()
		{
            variantAttribute = await attributeService.GetAll();
		}

		public MudDropContainer<KanbanItem> _dropContainer;
        public bool _addSectionOpen;

        public void ValueUpdated(MudItemDropInfo<KanbanItem> info)
        {
            info.Item.Attribute = info.DropzoneIdentifier;
        }

        public List<KanbanSections> _sections = new List<KanbanSections>
        {

        };
        public List<KanbanItem> _variant = new List<KanbanItem>();

        public KanbanNewForm newSectionModel = new KanbanNewForm();

        public void OnValidSectionSubmit(EditContext context)
        {
            _sections.Add(new KanbanSections(newSectionModel.AttributeName, false, String.Empty));
            newSectionModel.AttributeName = string.Empty;
            _addSectionOpen = false;
        }

        public void OpenAddNewSection()
        {
            _addSectionOpen = true;
        }

        public void AddVariant(KanbanSections section)
        {
            _variant.Add(new KanbanItem(section.NewTaskName, section.Name));
            section.NewTaskName = string.Empty;
            section.NewTaskOpen = false;
            _dropContainer.Refresh();
        }

		public void DeleteSection(KanbanSections section)
		{
			if (_sections.Count == 1)
			{
				_variant.Clear();
				_sections.Clear();
			}
			else
			{
				int newIndex = _sections.IndexOf(section) - 1;
				if (newIndex < 0)
				{
					newIndex = 0;
				}
				_sections.Remove(section);

				var tasks = _variant.Where(x => x.Attribute == section.Name);
				foreach (var item in tasks)
				{
					item.Attribute = _sections[newIndex].Name;
				}
			}
		}
	}
}

