using System.ComponentModel.DataAnnotations;

namespace OnlineEcommerce.Server.Element_Models
{
	public class KanbanNewForm
	{
		[Required]
		[Display(Name = "Attribute")]
		public string AttributeName { get; set; }
	}
}
