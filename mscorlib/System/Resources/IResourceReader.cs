using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace System.Resources
{
	// Token: 0x0200038D RID: 909
	[ComVisible(true)]
	public interface IResourceReader : IEnumerable, IDisposable
	{
		// Token: 0x06002CE9 RID: 11497
		void Close();

		// Token: 0x06002CEA RID: 11498
		IDictionaryEnumerator GetEnumerator();
	}
}
