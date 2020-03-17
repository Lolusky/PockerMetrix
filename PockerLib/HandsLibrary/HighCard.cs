
using PockerLib.BaseModels;
using PockerLib.Enums;
using PockerLib.Interfaces;
using PockerLib.Models;
using System.Linq;


namespace PockerLib.HandsLibrary
{/// <summary>
 /// Library for evaluating High Card
 /// </summary>
 /// <typeparam name="TPlayer"></typeparam>
	public class HighCard<TPlayer> : IHand<TPlayer>
			 where TPlayer : PlayerBase
	{
		public HandCategoryEnum HandCategory => HandCategoryEnum.HighCard;

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
			if (player.PlayingCardsOnHand.Count() > 0)
			{
				return true;
			};
			return false;
		}
	}
}
