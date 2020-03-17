using PockerLib.BaseModels;
using PockerLib.Enums;
using PockerLib.Models;

namespace PockerLib.Interfaces
{	/// <summary>
	/// interface for creating Hand-Ranking library
	/// </summary>
	/// <typeparam name="TPlayer"></typeparam>
	public interface IHand<TPlayer>
		where TPlayer : PlayerBase
	{
		HandCategoryEnum HandCategory { get;  }
		bool IsValid(TPlayer player);
		RankData<TPlayer> GetRankData(TPlayer player);
	}
}
