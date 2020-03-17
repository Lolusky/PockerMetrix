using PockerLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PockerMetrix.Actions
{
	public static class ActionLog
	{
		private static List<ActionModel> _actions;

		/// <summary>
		/// Cached actions of the console main meny dialog
		/// </summary>
		public static List<ActionModel> Actions
		{
			get
			{
				if (_actions == null)
				{
					_actions = new List<ActionModel>()
					{
						new ActionModel(){
						   ActionId=1,
						   ConsoleAction=  GamePlayActions.PlayTestSamples,
						   Title="Sample Test",
						   Description ="Runs prepopulated samples given"
						},
						new ActionModel(){
						   ActionId=2,
						   ConsoleAction=  GamePlayActions.PlayAutoGame,
						   Title="Auto Game",
						   Description ="Real Poker Game simulation"
						},
						new ActionModel(){
						   ActionId=3,
						   ConsoleAction=  GamePlayActions.PlayManualGame,
						   Title="Manual Entry Game",
						   Description ="Direct Playing Card Entry Poker Game"
						},
						new ActionModel(){
						   ActionId=4,
						   ConsoleAction= ()=>{ Environment.Exit(0); },
						   Title="Exit",
						   Description =""
						}
					};
				}

				return _actions;
			}
		}
	}
}
