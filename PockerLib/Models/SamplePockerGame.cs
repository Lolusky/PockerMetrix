using PockerLib.BaseModels;
using PockerLib.Enums;
using PockerLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PockerLib.Models
{/// <summary>
 /// The given sample game
 /// </summary>
	public class SamplePockerGame : PokerGameBase<SamplePokerPlayer>
	{
		public SamplePokerPlayer AddPlayer(SamplePokerPlayer player)
		{
			return Players.Add(player);
		}


	}
}
