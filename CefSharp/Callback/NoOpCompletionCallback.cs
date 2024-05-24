using System;

namespace CefSharp.Callback
{
	// Token: 0x02000455 RID: 1109
	public sealed class NoOpCompletionCallback : ICompletionCallback, IDisposable
	{
		// Token: 0x06002011 RID: 8209 RVA: 0x0002417C File Offset: 0x0002237C
		void ICompletionCallback.OnComplete()
		{
		}

		// Token: 0x17000BBF RID: 3007
		// (get) Token: 0x06002012 RID: 8210 RVA: 0x0002417E File Offset: 0x0002237E
		bool ICompletionCallback.IsDisposed
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06002013 RID: 8211 RVA: 0x00024181 File Offset: 0x00022381
		void IDisposable.Dispose()
		{
		}
	}
}
