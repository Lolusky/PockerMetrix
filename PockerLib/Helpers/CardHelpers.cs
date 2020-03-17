using PockerLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PockerLib.Helpers
{
	public static class CardHelpers
	{
		public static Dictionary<string, CardRankEnum> _dicRanks { get; set; }
		public static Dictionary<string, CardSuitEnum> _dicSuits { get; set; }

		/// <summary>
		/// returns cached dictionary of Rank
		/// </summary>
		public static Dictionary<string, CardRankEnum> DicRanks
		{
			get
			{
				if (_dicRanks == null)
				{
					_dicRanks = Enum.GetValues(typeof(CardRankEnum))
												.OfType<CardRankEnum>()
												.ToDictionary(o => o.ToString().ToLower(), o => (CardRankEnum)o);
				}
				return _dicRanks;
			}
		}

		public static Dictionary<string, CardSuitEnum> DicSuits
		{
			get
			{
				if (_dicSuits == null)
				{
					_dicSuits = Enum.GetValues(typeof(CardSuitEnum))
						.OfType<CardSuitEnum>()
						.ToDictionary(o => o.ToString().ToLower(), o => (CardSuitEnum)o);
				}
				return _dicSuits;
			}
		}
	}
}
