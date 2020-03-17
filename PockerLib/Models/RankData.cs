using PockerLib.BaseModels;
using PockerLib.Enums;
using PockerLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PockerLib.Models
{/// <summary>
 /// information on the Hand Ranking category of a player
 /// </summary>
 /// <typeparam name="TPlayer"></typeparam>
	public class RankData<TPlayer>
		 where TPlayer : PlayerBase
	{
		public HandCategoryEnum HandCategory { get; set; }
		//public IHand<TPlayer> HandRanking { get; set; }
		public TPlayer Player { get; set; }
		public List<CardRankEnum> UnitHandRankOrder { get; set; }
	}
}
