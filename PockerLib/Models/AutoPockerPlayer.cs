using PockerLib.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PockerLib.Models
{
	public class AutoPockerPlayer : PlayerBase
	{
		private string playerName;
		public override string ToString()
		{
			return playerName;
		}
		public AutoPockerPlayer(string _playerName, AutoPockerGame game): base(game)
		{
			playerName = _playerName;
		}
		public void ServePlayingCards(IEnumerable<PlayingCard> playingCards)
		{
			base.PlayingCardsOnHand.AddRange(playingCards);
		}

	}
}
