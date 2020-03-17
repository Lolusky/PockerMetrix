using PockerLib.BaseModels;
using PockerLib.Enums;
using PockerLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PockerLib.Models
{/// <summary>
 /// automatic game: generates app 52 cards, reshorfles them before each replay, randomly serves each player
 /// </summary>
	public class AutoPockerGame : PokerGameBase<AutoPockerPlayer>, IAutoGame, IGameStarter<AutoPockerPlayer>
	{
		private List<PlayingCard> deckOfCards;
		public AutoPockerGame()
		{
			//populate list with all 52 card types
			deckOfCards = Enum.GetValues(typeof(CardSuitEnum))
				.OfType<CardSuitEnum>()
				.SelectMany(c => Enum.GetValues(typeof(CardRankEnum))
					.OfType<CardRankEnum>()
					.Select(d => new PlayingCard() { CardSuit = c, CardRank = d }))
				.ToList();

			PlayCounter = 0;
		}

		/// <summary>
		/// randomizes card for next play
		/// </summary>
		public void ReshorfleCards()
		{
			deckOfCards = deckOfCards
				.OrderBy(o => Guid.NewGuid())
				.ToList();
		}

		public int PlayCounter { get; set; }

		/// <summary>
		/// starts a game
		/// </summary>
		/// <param name="listOfPlayers"></param>
		public void StartGame(string listOfPlayers)
		{
			AddPlayers(listOfPlayers.Split(',').Select(p => new AutoPockerPlayer(p.Trim(), this)));
		}

		/// <summary>
		/// distribute cards to each player
		/// </summary>
		public void ServeCardsToPlayers()
		{
			//randomize card order
			ReshorfleCards();

			PlayCounter++;

			//clear card from each player. By doing this, the Player property of each card is reset to null to free the card
			this.Players.ForEach(o => o.ReturnCards());

			//By adding card to player, the player property of each added card is set to the host player
			//it prevents allocated card from being reselected by the where clause 'c.Player == null'
			this.Players
				.ForEach(o => o.ServePlayingCards(deckOfCards
					.Where(c => c.Player == null)
					.Take(5)));
		}

		public IEnumerable<AutoPockerPlayer> AddPlayers(IEnumerable<AutoPockerPlayer> players)
		{
			this.Players.Clear();
			return Players.AddRange(players);
		}

		public override string ToString()
		{
			return "Auto Game " + PlayCounter;
		}

	}
}
