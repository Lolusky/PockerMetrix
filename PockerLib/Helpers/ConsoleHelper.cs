using PockerLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PockerLib.Helpers
{
	public static class ConsoleHelper
	{
		public static int GetNumericInput(List<int> rangeExpected)
		{
			int keySelected = 0;
			while (!rangeExpected.Any(o => o == keySelected))
			{
				var key = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(key))
				{
					var intResult = int.TryParse(key, out keySelected);
					if (!intResult || !rangeExpected.Any(o => o == keySelected))
					{
						Console.WriteLine($"You must select from the following option(s): {string.Join(", ", rangeExpected)}");
					}
				}
			}
			return keySelected;
		}
		public static string GetStringInput(List<string> rangeExpected)
		{
			string keySelected = "";
			while (!rangeExpected.Any(o => o.ToUpper() == keySelected.ToUpper()))
			{
				var key = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(key) || !rangeExpected.Any(o => o.ToUpper() == key.Trim().ToUpper()))
				{
					Console.WriteLine($"You must select from the following option(s): {string.Join(", ", rangeExpected)}");
					continue;
				}
				keySelected = key.Trim().ToUpper();
			}
			return keySelected;
		}

		public static string GetStringInput(string QuestionText, Func<string, InputValidationState> validatorMethod)
		{

			Console.WriteLine(QuestionText);
			string inputText = "";
			while (string.IsNullOrWhiteSpace(inputText) || !validatorMethod(inputText).Status)
			{
				var readString = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(readString))
				{
					Console.WriteLine("Please provide a text input");
					continue;
				}
				var result = validatorMethod(readString);
				if (!result.Status)
				{
					Console.WriteLine(result.Message);
					continue;
				}
				inputText = readString.ToUpper();
			}
			return inputText;
		}
	}
}
