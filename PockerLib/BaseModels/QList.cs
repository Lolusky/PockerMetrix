using System;
using System.Collections.Generic;
using System.Linq;

namespace PockerLib.BaseModels
{	/// <summary>
	/// just to create a list that raises events
	/// </summary>
	public class QList<T> : List<T>
	{
		public delegate void ItemAddedEventHandler(object sender, T e);
		public event ItemAddedEventHandler OnAdd;
		public event EventHandler BeforeClear;
		public new T Add(T item) // "new" to avoid compiler-warnings, because we're hiding a method from base-class
		{
			if (OnAdd != null)
			{
				OnAdd(this, item);
			}
			base.Add(item);

			return item;
		}
		public new void Clear()
		{
			if (BeforeClear != null)
			{
				BeforeClear(this, null);
			}
			base.Clear();
		}

		public new IEnumerable<T> AddRange(IEnumerable<T> lsItems)
		{
			return lsItems
				.Select(o => Add(o))
				.ToList();
		}
	}
}
