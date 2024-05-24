using System;

namespace CefSharp
{
	// Token: 0x0200009B RID: 155
	public interface INavigationEntryVisitor : IDisposable
	{
		// Token: 0x0600048C RID: 1164
		bool Visit(NavigationEntry entry, bool current, int index, int total);
	}
}
