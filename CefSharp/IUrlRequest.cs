using System;

namespace CefSharp
{
	// Token: 0x0200007E RID: 126
	public interface IUrlRequest : IDisposable
	{
		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000342 RID: 834
		bool ResponseWasCached { get; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000343 RID: 835
		IResponse Response { get; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000344 RID: 836
		UrlRequestStatus RequestStatus { get; }
	}
}
