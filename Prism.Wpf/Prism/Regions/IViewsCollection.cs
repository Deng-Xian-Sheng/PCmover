using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Prism.Regions
{
	// Token: 0x0200001C RID: 28
	public interface IViewsCollection : IEnumerable<object>, IEnumerable, INotifyCollectionChanged
	{
		// Token: 0x0600008F RID: 143
		bool Contains(object value);
	}
}
