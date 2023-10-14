namespace OnlineEcommerce.Server.Element_Models
{
	public class KanbanSections
	{
		public string Name { get; init; }
		public bool NewTaskOpen { get; set; }
		public string NewTaskName { get; set; }

		public KanbanSections(string name, bool newTaskOpen, string newTaskName)
		{
			Name = name;
			NewTaskOpen = newTaskOpen;
			NewTaskName = newTaskName;
		}
	}
}
