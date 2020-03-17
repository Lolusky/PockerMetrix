using PockerLib.Models;
using System;
using System.Linq;
using PockerLib.Helpers;

namespace PockerLib.BaseModels
{
	public abstract class PlayerBase
	{
		public PlayerBase(object _hostGame)
		{
			HostGame = _hostGame;

			//use QList to enable automatic parent navigational property setting/un-setting during add/removal 
			PlayingCardsOnHand = new QList<PlayingCard>();
			PlayingCardsOnHand.OnAdd += new QList<PlayingCard>.ItemAddedEventHandler(OnCardAdded);
			PlayingCardsOnHand.BeforeClear += new EventHandler(OnClearing);
		}

		public  RankData<TPlayer> HandShowdown<TPlayer>() where TPlayer : PlayerBase
		{
			var topValidHandForThisPlayer = HandLibraryHelper<TPlayer>
				.HandTemplates()//get available IHand management libraries in the project
				.FirstOrDefault(o => o.IsValid((TPlayer)this));

			//get first set of winner's data for further evaluation
			return topValidHandForThisPlayer?.GetRankData((TPlayer)this);
		}

		/// <summary>
		/// need to set the parent player of the card being added
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="item"></param>
		private void OnCardAdded(object sender, PlayingCard item)
		{
			item.Player = this;
		}

		/// <summary>
		/// need to set the parent player of each card to null before removint them
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClearing(object sender, EventArgs e)
		{
			PlayingCardsOnHand.ForEach(o => o.Player = null);
		}
		/// <summary>
		/// holds the current card that this player is holding
		/// </summary>
		public QList<PlayingCard> PlayingCardsOnHand { get; set; }

		/// <summary>
		/// clear out the cards
		/// note that QList enables setting the Player property of each playing card to null
		/// </summary>
		public void ReturnCards()
		{ 
			PlayingCardsOnHand.Clear();
		}

		/// <summary>
		/// an untyped reference to the game object in which this player is playing
		/// </summary>
		public object HostGame { get; set; }
	}
}
