using PockerLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PockerMetrix.Helpers
{
	public static class PopulateSamplePlayers
	{
		/// <summary>
		/// populate with the geven samples from then assignment
		/// </summary>
		/// <param name="joe"></param>
		/// <param name="jen"></param>
		/// <param name="bob"></param>
		public static void PopulatePlayers1(SamplePokerPlayer joe, SamplePokerPlayer jen, SamplePokerPlayer bob)
		{
			joe.ReturnCards();
			jen.ReturnCards();
			bob.ReturnCards();

			joe.PlayingCardsOnHand = new PockerLib.BaseModels.QList<PlayingCard>()
					{
						new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Three , CardSuit= PockerLib.Enums.CardSuitEnum.Heart},
						new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Six , CardSuit= PockerLib.Enums.CardSuitEnum.Heart},
						new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Eight , CardSuit= PockerLib.Enums.CardSuitEnum.Heart},
						new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Jack , CardSuit= PockerLib.Enums.CardSuitEnum.Heart},
						new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.King , CardSuit= PockerLib.Enums.CardSuitEnum.Heart},
					};

			jen.PlayingCardsOnHand = new PockerLib.BaseModels.QList<PlayingCard>()
				 {
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Three , CardSuit= PockerLib.Enums.CardSuitEnum.Clubs},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Three , CardSuit= PockerLib.Enums.CardSuitEnum.Diamond},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Three , CardSuit= PockerLib.Enums.CardSuitEnum.Spades},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Eight , CardSuit= PockerLib.Enums.CardSuitEnum.Clubs},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Ten , CardSuit= PockerLib.Enums.CardSuitEnum.Diamond},
				 };

			bob.PlayingCardsOnHand = new PockerLib.BaseModels.QList<PlayingCard>()
				 {
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Two , CardSuit= PockerLib.Enums.CardSuitEnum.Heart},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Five , CardSuit= PockerLib.Enums.CardSuitEnum.Clubs},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Seven , CardSuit= PockerLib.Enums.CardSuitEnum.Spades},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Ten , CardSuit= PockerLib.Enums.CardSuitEnum.Clubs},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Ace , CardSuit= PockerLib.Enums.CardSuitEnum.Heart},
				 };
		}

		public static void PopulatePlayers2(SamplePokerPlayer joe, SamplePokerPlayer jen, SamplePokerPlayer bob)
		{
			joe.ReturnCards();
			jen.ReturnCards();
			bob.ReturnCards();


			joe.PlayingCardsOnHand = new PockerLib.BaseModels.QList<PlayingCard>()
					{
						new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Three , CardSuit= PockerLib.Enums.CardSuitEnum.Heart},
						new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Four , CardSuit= PockerLib.Enums.CardSuitEnum.Diamond },
						new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Nine  , CardSuit= PockerLib.Enums.CardSuitEnum.Clubs},
						new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Nine  , CardSuit= PockerLib.Enums.CardSuitEnum.Diamond},
						new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Queen , CardSuit= PockerLib.Enums.CardSuitEnum.Heart},
					};

			jen.PlayingCardsOnHand = new PockerLib.BaseModels.QList<PlayingCard>()
				 {
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Five , CardSuit= PockerLib.Enums.CardSuitEnum.Clubs},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Seven , CardSuit= PockerLib.Enums.CardSuitEnum.Diamond},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Nine , CardSuit= PockerLib.Enums.CardSuitEnum.Heart },
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Nine , CardSuit= PockerLib.Enums.CardSuitEnum.Spades },
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Queen  , CardSuit= PockerLib.Enums.CardSuitEnum.Spades },
				 };

			bob.PlayingCardsOnHand = new PockerLib.BaseModels.QList<PlayingCard>()
				 {
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Two , CardSuit= PockerLib.Enums.CardSuitEnum.Heart},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Two , CardSuit= PockerLib.Enums.CardSuitEnum.Clubs},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Five , CardSuit= PockerLib.Enums.CardSuitEnum.Spades},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Ten , CardSuit= PockerLib.Enums.CardSuitEnum.Clubs},
					 new PlayingCard() { CardRank= PockerLib.Enums.CardRankEnum.Ace , CardSuit= PockerLib.Enums.CardSuitEnum.Heart},
				 };
		}

	}
}
