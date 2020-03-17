using PockerLib.Extensions;
using PockerLib.Models;
using PockerMetrix.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PockerMetrix
{
	class Program
	{
		static void Main(string[] args)
		{
			Actions.ActionLog.Actions.RenderActionList();
		}
	}
}
