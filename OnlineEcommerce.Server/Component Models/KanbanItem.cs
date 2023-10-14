namespace OnlineEcommerce.Server.Element_Models
{
	public class KanbanItem
	{
		public string Value { get; init; }
		public string Attribute { get; set; }

		public KanbanItem(string value, string attribute)
		{
			Value = value;
			Attribute = attribute;
		}
	}
}
