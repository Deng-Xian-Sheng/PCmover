using System;

namespace CefSharp.Callback
{
	// Token: 0x02000452 RID: 1106
	public interface IResourceReadCallback : IDisposable
	{
		// Token: 0x0600200C RID: 8204
		void Continue(int bytesRead);

		// Token: 0x17000BBD RID: 3005
		// (get) Token: 0x0600200D RID: 8205
		bool IsDisposed { get; }
	}
}
