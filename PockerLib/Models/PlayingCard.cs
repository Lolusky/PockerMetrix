using PockerLib.BaseModels;
using PockerLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PockerLib.Models
{/// <summary>
 /// the card being played
 /// </summary>
	public class PlayingCard
	{
		public CardRankEnum CardRank { get; set; }
		public CardSuitEnum CardSuit { get; set; }
		public virtual PlayerBase Player { get; set; }
	}
}
