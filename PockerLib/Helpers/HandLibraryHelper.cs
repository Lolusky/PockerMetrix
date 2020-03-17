using PockerLib.BaseModels;
using PockerLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace PockerLib.Helpers
{
	public static class HandLibraryHelper<TPlayer> where TPlayer : PlayerBase
	{
		private static List<IHand<TPlayer>> _handTemplates;

		/// <summary>
		/// get cached instances of all IHand libraries present in 'PockerLib.HandsLibrary' namespace
		/// To implement all the remaining 5 hands rankings, a class implementing IHand must be added
		/// to library then include the hand ranking in CardSuitEmum in the correct order
		/// </summary>
		/// <returns></returns>
		public static List<IHand<TPlayer>> HandTemplates()

		{
			if (_handTemplates == null)
			{
				//looks for every type that implements IHand<> generic type and keeps the type in list
				var allAssemblies = Assembly.GetExecutingAssembly()
									.GetTypes()
									.Where(x => x.Namespace == "PockerLib.HandsLibrary")
									.Where(x => x.GetInterfaces()
										.Any(y => (y != null && y.IsGenericType && typeof(IHand<>).IsAssignableFrom(y.GetGenericTypeDefinition()))
												|| (x.IsGenericType && typeof(IHand<>).IsAssignableFrom(x.GetGenericTypeDefinition()))))
									.ToList();

				//array of the generic type parameter to use in creating each instance
				var dataType = new Type[] { typeof(TPlayer) };

				//create instance of each Hand Ranking type and cache
				_handTemplates = allAssemblies
								   .Where(x => !x.IsInterface && !x.IsAbstract)
								   .Select(i => (IHand<TPlayer>)Activator.CreateInstance(i.MakeGenericType(dataType)))
								   .OrderByDescending(i => (int)i.HandCategory)
								   .ToList();
			}
			return _handTemplates;
		}
	}
}
