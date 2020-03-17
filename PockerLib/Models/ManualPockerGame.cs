using PockerLib.BaseModels;
using PockerLib.Helpers;
using PockerLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PockerLib.Models
{/// <summary>
 /// Manual play mode game in which you have to input each playing card per player
 /// </summary>
	public class ManualPockerGame : PokerGameBase<ManualPockerPlayer>, IGameStarter<ManualPockerPlayer>
	{
		public int PlayCounter { get; set; }

		public void StartGame(string listOfPlayers)
		{
			AddPlayers(listOfPlayers.Split(',').Select(p => new ManualPockerPlayer(p.Trim(), this)));
		}

		public IEnumerable<ManualPockerPlayer> AddPlayers(IEnumerable<ManualPockerPlayer> players)
		{
			this.Players.Clear();
			return Players.AddRange(players);
		}

		/// <summary>
		/// begin the process of playing
		/// </summary>
		public void ServeCards()
		{

			PlayCounter++;

			Console.WriteLine(Environment.NewLine);
			Console.WriteLine($"Available Legends for Suits are: '{string.Join(", ", CardHelpers.DicSuits.Select(o => o.Key))}'");
			Console.WriteLine($"Available Legends for Ranks are: '{string.Join(", ", CardHelpers.DicRanks.Select(o => o.Key))}'");
			Console.WriteLine(Environment.NewLine);
			if (PlayCounter == 1)
			{
				Console.WriteLine("To input cards, use comma separated list of Suit-Rank");
				Console.WriteLine("E.g. to input 'Queen of Spades and King of Diamond, type 'spades-queen, diamond-king'");
				Console.WriteLine(Environment.NewLine);
				Console.WriteLine("Its not case sensitive, no space within a card entry");
			}
			Console.WriteLine($"Proceed to play Game {PlayCounter}...");

			Players.ForEach(o => o.RequestCardsToPlay());
		}

		public override string ToString()
		{
			return "Manual Entry Game " + PlayCounter;
		}

	}
}
