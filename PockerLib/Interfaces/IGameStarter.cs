using PockerLib.BaseModels;
using System.Collections.Generic;

namespace PockerLib.Interfaces
{
	/// <summary>
	/// interface for any non-sample based games
	/// </summary>
	/// <typeparam name="TPlayer"></typeparam>
	public interface  IGameStarter<TPlayer>
		where TPlayer : PlayerBase
	{
		int PlayCounter { get; set; }
		void StartGame(string listOfPlayers);
		IEnumerable<TPlayer> AddPlayers(IEnumerable<TPlayer> players);
	}
}
