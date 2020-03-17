using PockerLib.Helpers;
using PockerLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PockerLib.Extensions
{
	public static class ActionModelExtensions
	{
		public static void RenderActionList(this IEnumerable<ActionModel> consoleActions)
		{
			PrintMainMenu(consoleActions);
		}

		private static void PrintMainMenu(IEnumerable<ActionModel> consoleActions)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Main Menu");
			Console.WriteLine("");
			consoleActions.ToList().ForEach(o =>
			{
				Console.WriteLine($"Press {o.ActionId} for {o.Title}: {o.Description}");
			});

			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Select appropriate numeric key and press enter");
			Console.WriteLine("==============================================");
			Console.WriteLine("");
			RequestAction(consoleActions);
		}

		private static void RequestAction(IEnumerable<ActionModel> consoleActions)
		{
			var keyList = consoleActions
				.Select(o => o.ActionId)
				.OrderBy(o => o)
				.ToList();

			int keySelected = ConsoleHelper.GetNumericInput(keyList);
			Console.ForegroundColor =  ConsoleColor.Yellow;
			Console.Clear();
			var actionObject = consoleActions.FirstOrDefault(o => o.ActionId == keySelected);
			actionObject.ConsoleAction();

			Console.WriteLine($"Press 'M and enter' to return to main menu or 'X and enter' to exit");
			var option = ConsoleHelper.GetStringInput(new List<string>() { "M","X" });

			if (option == "M")
			{
				PrintMainMenu(consoleActions);
			}
		}
	}
}
