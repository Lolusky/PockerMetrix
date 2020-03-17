using System;

namespace PockerLib.Models
{	/// <summary>
	/// a model for handling any task for console command
	/// </summary>
	public class ActionModel
	{
		public int ActionId { get; set; }
		public Action ConsoleAction { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
