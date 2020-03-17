using PockerLib.Enums;
using PockerLib.Extensions;
using PockerLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace PockerLib.BaseModels
{
	public abstract class PokerGameBase<TPlayer>
		where TPlayer : PlayerBase
	{
		public PokerGameBase()
		{
			Players = new QList<TPlayer>();
		}

		public IEnumerable<RankData<TPlayer>> Winners
		{
			get
			{
				List<RankData<TPlayer>> allHandShowdowns = Players
					.Select(o => o.HandShowdown<TPlayer>())
					.Where(o => o != null)
					.ToList();

				List<RankData<TPlayer>> winners;

				//this happens if HighHand is not available. then treat as highand
				if (allHandShowdowns.Count == 0)
				{
					winners = Players.Select(o => new RankData<TPlayer>()
					{
						HandCategory = HandCategoryEnum.HighCard,
						Player = o,
						UnitHandRankOrder = o.PlayingCardsOnHand
							.Select(q => q.CardRank)
							.OrderByDescending(q => (int)q)
							.ToList()
					})
					.ToList();
				}

				//get the winning hand (min is used since the HandCategoryEnum is in 
				//descending order with the strongest hand being that of the highest value)
				var winningHandCategory = (HandCategoryEnum)allHandShowdowns.Max(o => (int)o.HandCategory);

				//get all with the winning hand just in case its moe than 1
				winners = allHandShowdowns
					.Where(o => o.HandCategory == winningHandCategory)
					.ToList();

				return winners.GetWinnersFromTie();
			}
		}

		public QList<TPlayer> Players { get; set; }

	}
}
