
using PockerLib.BaseModels;
using PockerLib.Enums;
using PockerLib.Interfaces;
using PockerLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PockerLib.HandsLibrary
{/// <summary>
 /// Library for evaluating One pair
 /// </summary>
 /// <typeparam name="TPlayer"></typeparam>
	public class OnePair<TPlayer> : IHand<TPlayer>
			 where TPlayer : PlayerBase
	{
		public HandCategoryEnum HandCategory => HandCategoryEnum.OnePair;

		private Func<TPlayer, CardRankEnum?> GetOnePairRank = (p) =>
		{
			var lsOnePairRanks = p.PlayingCardsOnHand
				   .Select(o => o.CardRank)
				   .Distinct()
				   .Where(o => p.PlayingCardsOnHand.Count(q => q.CardRank == o) == 2)
				   .ToList();

			if (lsOnePairRanks.Count > 0)
			{
				return lsOnePairRanks
				//sorted in desc order just in case it turns out to be 2 cases of 'one pair' 
				//(which is actually 'two of a kind' which was not implemented)
				.OrderByDescending(o => (int)o)
				.First();
			}
			return null;
		};


		public Models.RankData<TPlayer> GetRankData(TPlayer player)
		{
			if (!IsValid(player))
			{
				return null;
			}

			CardRankEnum? onePairRank = GetOnePairRank(player);
			var lstRankList = new List<CardRankEnum>() { onePairRank.Value };
			lstRankList.AddRange(player.PlayingCardsOnHand
				.Where(o => onePairRank.Value != o.CardRank)
				.Select(o => o.CardRank)
				.OrderByDescending(o => (int)o));

			return new RankData<TPlayer>()
			{
				HandCategory = this.HandCategory,
				Player = player,
				UnitHandRankOrder = lstRankList
			};
		}

		public bool IsValid(TPlayer player)
		{
			CardRankEnum? onePairRank = GetOnePairRank(player);

			if (onePairRank != null && onePairRank.HasValue)
			{
				return true;
			}
			return false;
		}

	}
}
