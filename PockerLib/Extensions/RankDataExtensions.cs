using PockerLib.BaseModels;
using PockerLib.Helpers;
using PockerLib.Interfaces;
using PockerLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PockerLib.Extensions
{
	public static class RankDataExtensions
	{/// <summary>
	/// A central extension method for rendering the winning players
	/// </summary>
	/// <typeparam name="TPlayer"></typeparam>
	/// <param name="winners"></param>
	/// <param name="title"></param>
	/// <param name="proceedText"></param>
		public static void PrintResult<TPlayer>(this IEnumerable<RankData<TPlayer>> winners, string title, string proceedText) where TPlayer : PlayerBase
		{
			Console.ForegroundColor = ConsoleColor.Green;
			//print playing set
			var game = (PokerGameBase<TPlayer>)winners.FirstOrDefault().Player.HostGame;
			Console.WriteLine($"For {title}, Given:");
			Console.ForegroundColor = ConsoleColor.Cyan;
			game.Players.ForEach(p =>
			{
				Console.WriteLine($"{p.ToString()}: {string.Join(", ", p.PlayingCardsOnHand.Select(q => $"{q.CardRank.ToString()}-{q.CardSuit.ToString()}"))}");
			});
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("");
			Console.WriteLine($"Winner{(winners.Count() > 1 ? "s" : "")} is: {winners.ToTitle()} with hand '{winners.FirstOrDefault().HandCategory.Description()}'");

			Console.WriteLine("------------------------------------------");
			Console.ResetColor();
			if (!string.IsNullOrWhiteSpace(proceedText))
			{
				Console.WriteLine(proceedText);
				Console.ReadKey();
			}

		}

		/// <summary>
		/// A safe way of getting the name/names of winner/winners
		/// </summary>
		/// <typeparam name="TPlayer"></typeparam>
		/// <param name="winners"></param>
		/// <returns></returns>
		public static string ToTitle<TPlayer>(this IEnumerable<RankData<TPlayer>> winners)
			where TPlayer : PlayerBase
		{
			if (winners.Count() == 1)
			{
				return winners.FirstOrDefault().Player.ToString();
			}
			return string.Join(", ", winners.Select(o => o.Player.ToString()));
		}


		/// <summary>
		/// use this to return actual winners from a list of winning hands in case of a tie
		/// note that because there could be more than one winner, then the returned datatype must be an IEnumerable
		/// </summary>
		/// <param name="winners"></param>
		public static IEnumerable<RankData<TPlayer>> GetWinnersFromTie<TPlayer>(this IEnumerable<RankData<TPlayer>> winners)
			where TPlayer : PlayerBase
		{
			if (winners.Count() == 1)
			{
				return winners;
			}

			//compare winnig hand ranks
			//get maximum first position ranks in UnitHandRankOrder property of each
			var tempWinners = winners.ToList();

			do
			{
				var maxOfAll = tempWinners.Max(o => (int)o.UnitHandRankOrder.FirstOrDefault());
				tempWinners = tempWinners.Where(o => (int)o.UnitHandRankOrder.FirstOrDefault() == maxOfAll).ToList();
				//pop off the compared rank

				tempWinners.ForEach(o => o.UnitHandRankOrder.RemoveAt(0));
			}
			while (tempWinners.Count() > 1 && tempWinners.Any(q => q.UnitHandRankOrder.Any()));

			return tempWinners;
		}

		public static IHand<TPlayer> GetHandLib<TPlayer>(this RankData<TPlayer> rankData) where TPlayer : PlayerBase
		{
			return HandLibraryHelper<TPlayer>
				.HandTemplates()
				.FirstOrDefault(o => o.HandCategory == rankData.HandCategory);
		}
	}
}
