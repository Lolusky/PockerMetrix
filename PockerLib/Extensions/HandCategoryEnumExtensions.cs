using PockerLib.Enums;

namespace PockerLib.Extensions
{
	public static class HandCategoryEnumExtensions
	{/// <summary>
	 /// for a more friendly description
	 /// </summary>
	 /// <param name="hand"></param>
	 /// <returns></returns>
		public static string Description(this HandCategoryEnum hand)
		{
			switch (hand)
			{
				case HandCategoryEnum.HighCard:
					return "High Hand";
				case HandCategoryEnum.OnePair:
					return "One Pair";
				case HandCategoryEnum.ThreeeOfAKind:
					return "Three of A Kind";
				default:
					return hand.ToString();
			}
		}
	}
}
