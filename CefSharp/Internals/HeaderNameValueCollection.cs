using System;
using System.Collections.Specialized;

namespace CefSharp.Internals
{
	// Token: 0x020000CC RID: 204
	public class HeaderNameValueCollection : NameValueCollection
	{
		// Token: 0x06000600 RID: 1536 RVA: 0x00009BBB File Offset: 0x00007DBB
		public void SetReadOnly()
		{
			base.IsReadOnly = true;
		}
	}
}
