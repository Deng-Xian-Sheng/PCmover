using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Prism.Regions
{
	// Token: 0x02000011 RID: 17
	public interface IRegionCollection : IEnumerable<IRegion>, IEnumerable, INotifyCollectionChanged
	{
		// Token: 0x1700000F RID: 15
		IRegion this[string regionName]
		{
			get;
		}

		// Token: 0x0600004E RID: 78
		void Add(IRegion region);

		// Token: 0x0600004F RID: 79
		bool Remove(string regionName);

		// Token: 0x06000050 RID: 80
		bool ContainsRegionWithName(string regionName);

		// Token: 0x06000051 RID: 81
		void Add(string regionName, IRegion region);
	}
}
