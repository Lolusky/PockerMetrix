
using PockerLib.BaseModels;
using PockerLib.Enums;
using PockerLib.Interfaces;
using PockerLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PockerLib.HandsLibrary
{
	/// <summary>
	/// Library for evaluating Three of a kind
	/// </summary>
	/// <typeparam name="TPlayer"></typeparam>
	public class ThreeOfAKind<TPlayer> : IHand<TPlayer>
			 where TPlayer : PlayerBase
	{
		public HandCategoryEnum HandCategory => HandCategoryEnum.ThreeeOfAKind;

		Func<TPlayer, CardRankEnum?> GetThreeOfKindRank = (p) =>
		{
			var lsThreeOfAKind = p.PlayingCardsOnHand
				   .Select(o => o.CardRank)
				   .Distinct()
				   .Where(o => p.PlayingCardsOnHand.Count(q => q.CardRank == o) == 3)
				   .ToList();

			if (lsThreeOfAKind.Count > 0)
			{
				return lsThreeOfAKind.First();
			}
			return null;
		};

		public Models.RankData<TPlayer> GetRankData(TPlayer player)
		{
			if (!IsValid(player))
			{
				return null;
			}

			CardRankEnum? threeOfAKindRank = GetThreeOfKindRank(player);

			var lstRankList = new List<CardRankEnum>() { threeOfAKindRank.Value };
			lstRankList.AddRange(player.PlayingCardsOnHand
				.Where(o => threeOfAKindRank.Value != o.CardRank)
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
			CardRankEnum? threeOfAKindRank = GetThreeOfKindRank(player);

			if (threeOfAKindRank != null && threeOfAKindRank.HasValue)
			{
				return true;
			}
			return false;
		}
	}

}