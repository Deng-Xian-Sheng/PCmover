using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CefSharp
{
	// Token: 0x0200006A RID: 106
	public interface IDomNode : IEnumerable<KeyValuePair<string, string>>, IEnumerable
	{
		// Token: 0x170000BF RID: 191
		string this[string attributeName]
		{
			get;
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000240 RID: 576
		string TagName { get; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000241 RID: 577
		ReadOnlyCollection<string> AttributeNames { get; }

		// Token: 0x06000242 RID: 578
		bool HasAttribute(string attributeName);
	}
}
