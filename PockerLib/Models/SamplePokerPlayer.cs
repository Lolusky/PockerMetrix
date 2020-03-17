using PockerLib.BaseModels;
using PockerLib.Helpers;
using PockerLib.Models;

using PockerLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PockerLib.Models
{
	public class SamplePokerPlayer : PlayerBase
	{
		private string playerName;
		public override string ToString()
		{
			return "'Sample Player "+ playerName +"'";
		}
		public SamplePokerPlayer(string _playerName, SamplePockerGame _hostGame ): base(_hostGame)
		{
			playerName = _playerName;
		}

	}
}
