using PockerLib.BaseModels;
using PockerLib.Enums;
using PockerLib.Interfaces;
using PockerLib.Models;
using System.Collections.Generic;
using System.Linq;


namespace PockerLib.HandsLibrary
{	/// <summary>
	/// Library for evaluating Flush 
	/// </summary>
	/// <typeparam name="TPlayer"></typeparam>
	public class Flush<TPlayer> : IHand<TPlayer>
		 where TPlayer : PlayerBase
	{
		public HandCategoryEnum HandCategory { get => HandCategoryEnum.Flush; }

		public IEnumerable<RankData<TPlayer>> GetWinnerFromTie(IEnumerable<RankData<TPlayer>> potentialWinners)
		{
			var tempWinners = potentialWinners;
			var prevMaxOfAll = tempWinners.Max(o => o.UnitHandRankOrder.Max(p => (int)p)) + 1;

			do
			{
				var maxOfAll = tempWinners.Max(o => o.UnitHandRankOrder.Where(p => (int)p < prevMaxOfAll).Max(p => (int)p));
				tempWinners = tempWinners.Where(o => o.UnitHandRankOrder.Any(p => (int)p == maxOfAll));
				prevMaxOfAll = maxOfAll;
			}
			while (tempWinners.Count() > 1 && tempWinners.Min(q => q.UnitHandRankOrder.Min(p => (int)p)) < prevMaxOfAll);

			return tempWinners;
		}

		/// <summary>
		/// harvest the data that makes the player valid
		/// </summary>
		/// <param name="player"></param>
		/// <returns></returns>
		public RankData<TPlayer> GetRankData(TPlayer player)
		{
			if (!IsValid(player))
			{
				return null;
			}

			return new RankData<TPlayer>()
			{
				HandCategory = this.HandCategory,
				Player = player,
				UnitHandRankOrder = player.PlayingCardsOnHand
					.Select(o => o.CardRank)
					.OrderByDescending(o => (int)o)
					.ToList()
			};
		}

		public bool IsValid(TPlayer player)
		{
			if (player.PlayingCardsOnHand.Select(o => o.CardSuit).Distinct().Count() == 1)
			{
				return true;
			}
			return false;
		}
	}
}
