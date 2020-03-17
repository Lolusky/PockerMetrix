using PockerLib.BaseModels;
using PockerLib.Enums;
using PockerLib.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PockerLib.Models
{
	public class ManualPockerPlayer : PlayerBase
	{
		public ManualPockerPlayer(string _playerName, ManualPockerGame game) : base(game)
		{
			playerName = _playerName;
		}

		public ManualPockerGame ManualHostGame => (ManualPockerGame)base.HostGame;

		/// <summary>
		/// collects manually entered cards
		/// </summary>
		public void RequestCardsToPlay()
		{
			this.ReturnCards();
			List<PlayingCard> cardsEntered = new List<PlayingCard>();
			while (cardsEntered.Count < 5)
			{
				PopulateCards(cardsEntered, 5 - cardsEntered.Count);
				if (cardsEntered.Count < 5)
				{
					Console.WriteLine($"You need to supply {5 - cardsEntered.Count} more cards");
				}
			}

			this.PlayingCardsOnHand.AddRange(cardsEntered);
		}

		/// <summary>
		/// collect 5 playing cards from console for this player
		/// </summary>
		/// <param name="cardsEntered"></param>
		/// <param name="remCards"></param>
		private void PopulateCards(List<PlayingCard> cardsEntered, int remCards)
		{
			var caption = $"Input {remCards} playing card(s) for {this.ToString()}";
			var inputStringHarvested = CollectInput(caption);
			if (string.IsNullOrWhiteSpace(inputStringHarvested))
			{
				Console.WriteLine("No data captures, try again");
				inputStringHarvested = CollectInput(caption);
			}

			var playingCardsCaptured = inputStringHarvested.Trim().Split(',')
				.Select(o =>
				{
					var pair = o.Trim().ToLower().Split('-');
					if (CardHelpers.DicRanks.ContainsKey(pair[0].Trim()) && CardHelpers.DicSuits.ContainsKey(pair[1].Trim()))
					{
						return new PlayingCard() { CardRank = CardHelpers.DicRanks[pair[0].Trim()], CardSuit = CardHelpers.DicSuits[pair[1].Trim()] };
					}
					//incase the order is switched
					if (CardHelpers.DicRanks.ContainsKey(pair[1].Trim()) && CardHelpers.DicSuits.ContainsKey(pair[0].Trim()))
					{
						return new PlayingCard() { CardRank = CardHelpers.DicRanks[pair[1].Trim()], CardSuit = CardHelpers.DicSuits[pair[0].Trim()] };
					}
					return null;
				})
				.Where(o => o != null)
				.ToList();

			//eliminate used cards
			var occupiedCards = ManualHostGame
				.Players
				.SelectMany(o => o.PlayingCardsOnHand)
				.ToList();

			occupiedCards.AddRange(cardsEntered);

			playingCardsCaptured = playingCardsCaptured
				.Where(o => !occupiedCards.Any(q => q.CardRank == o.CardRank && q.CardSuit == o.CardSuit))
				.ToList();

			var usefullCards = playingCardsCaptured.Count <= 5 - cardsEntered.Count
				? playingCardsCaptured
				: playingCardsCaptured.Take(5 - cardsEntered.Count);

			cardsEntered.AddRange(usefullCards);
		}

		/// <summary>
		/// validates card input from console
		/// </summary>
		private Func<string, InputValidationState> fnValidateInput = (input) =>
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return new InputValidationState()
				{
					Status = false,
					Message = "Please provide comma separated list of playing cards as described above"
				};
			}
			if (input.Trim().IndexOf(",") < 0)
			{
				return new InputValidationState()
				{
					Status = false,
					Message = "You must provide more than playing card name separated by comma"
				};
			}
			var noValid = input.Trim().Split(',')
			   .Where(o => o.IndexOf('-') >= 0 && o.Split('-').Length > 1)
			   .Where(o =>
			   {
				   var pair = o.Trim().ToLower().Split('-');
				   if (CardHelpers.DicRanks.ContainsKey(pair[0].Trim()) && CardHelpers.DicSuits.ContainsKey(pair[1].Trim())
					   || CardHelpers.DicRanks.ContainsKey(pair[1].Trim()) && CardHelpers.DicSuits.ContainsKey(pair[0].Trim()))
				   {
					   return true;
				   }
				   return false;
			   })
			   .Count();

			if (noValid == 0)
			{
				return new InputValidationState()
				{
					Status = false,
					Message = "Invalid entries, please follow the instruction above"
				};
			}

			return new InputValidationState()
			{
				Status = true
			};
		};

		private string CollectInput(string caption)
		{
			string playingCards = ConsoleHelper.GetStringInput(caption, fnValidateInput);

			return playingCards;
		}


		private string playerName;
		public override string ToString()
		{
			return playerName;
		}
	}
}
