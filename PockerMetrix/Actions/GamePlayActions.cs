using PockerLib.Extensions;
using PockerLib.Helpers;
using PockerLib.Models;
using PockerMetrix.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PockerMetrix.Actions
{/// <summary>
 /// All game starters are implemented here
 /// </summary>
	public static class GamePlayActions
	{
		public static void PlayTestSamples()
		{
			SamplePockerGame testSampleGame = new SamplePockerGame();
			SamplePokerPlayer Joe = testSampleGame.AddPlayer(new SamplePokerPlayer("Joe", testSampleGame));
			SamplePokerPlayer Gen = testSampleGame.AddPlayer(new SamplePokerPlayer("Jen", testSampleGame));
			SamplePokerPlayer Bob = testSampleGame.AddPlayer(new SamplePokerPlayer("Bob", testSampleGame));

			PopulateSamplePlayers.PopulatePlayers1(Joe, Gen, Bob);

			var winners = testSampleGame.Winners;
			winners.PrintResult("Sample test 1", "Press any key to play sample 2");
			Console.WriteLine("");

			PopulateSamplePlayers.PopulatePlayers2(Joe, Gen, Bob);
			winners = testSampleGame.Winners;
			winners.PrintResult("Sample test 2", "");
		}

		public static void PlayAutoGame()
		{
			AutoPockerGame autoGame = new AutoPockerGame();
			//collect list of players

			string players = ConsoleHelper.GetStringInput("Provide comma separated list of players", (input) =>
			{
				if (string.IsNullOrWhiteSpace(input))
				{
					return new InputValidationState()
					{
						Status = false,
						Message = "Please provide comma separated list of player names"
					};
				}
				if (input.Trim().IndexOf(",") < 0)
				{
					return new InputValidationState()
					{
						Status = false,
						Message = "You must provide more than one name separated by comma"
					};
				}
				return new InputValidationState()
				{
					Status = true
				};
			});

			autoGame.StartGame(players);
			PlayAutoGameSession(autoGame);
		}
		public static void PlayAutoGameSession(AutoPockerGame autoGame)
		{
			autoGame.ServeCardsToPlayers();
			var winners = autoGame.Winners;
			winners.PrintResult(autoGame.ToString(), "");

			Console.WriteLine($"Press 'R' to re-play another, 'P' to change players or 'X' to exit auto play");
			var option = ConsoleHelper.GetStringInput(new List<string>() { "R", "P", "X" });

			switch (option)
			{
				case "R":
					PlayAutoGameSession(autoGame);
					break;
				case "P":
					Console.Clear();
					PlayAutoGame();
					break;
				default:
					Console.Clear();
					//just exit this method
					break;

			}
		}

		public static void PlayManualGame()
		{
			ManualPockerGame manualGame = new ManualPockerGame();
			//collect list of players


			string players = ConsoleHelper.GetStringInput("Provide comma separated list of players", (input) =>
			{
				if (string.IsNullOrWhiteSpace(input))
				{
					return new InputValidationState()
					{
						Status = false,
						Message = "Please provide comma separated list of player names"
					};
				}
				if (input.Trim().IndexOf(",") < 0)
				{
					return new InputValidationState()
					{
						Status = false,
						Message = "You must provide more than one name separated by comma"
					};
				}
				return new InputValidationState()
				{
					Status = true
				};
			});

			manualGame.StartGame(players);
			PlayManualGameSession(manualGame);
		}

		public static void PlayManualGameSession(ManualPockerGame manualGame)
		{
			manualGame.ServeCards();
			var winners = manualGame.Winners;
			winners.PrintResult(manualGame.ToString(), "");

			Console.WriteLine($"Press 'R' to re-play another, 'P' to change players or 'X' to exit auto play");
			var option = ConsoleHelper.GetStringInput(new List<string>() { "R", "P", "X" });

			switch (option)
			{
				case "R":
					PlayManualGameSession(manualGame);
					break;
				case "P":
					Console.Clear();
					PlayManualGame();
					break;
				default:
					Console.Clear();
					//just exit this method
					break;

			}
		}


	}
}
