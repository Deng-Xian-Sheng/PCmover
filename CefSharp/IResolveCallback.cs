using System;
using System.Collections.Generic;

namespace CefSharp
{
	// Token: 0x02000010 RID: 16
	public interface IResolveCallback : IDisposable
	{
		// Token: 0x06000032 RID: 50
		void OnResolveCompleted(CefErrorCode result, IList<string> resolvedIpAddresses);

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000033 RID: 51
		bool IsDisposed { get; }
	}
}
