using System;

namespace CefSharp
{
	// Token: 0x0200004F RID: 79
	public interface IBrowserProcessHandler : IDisposable
	{
		// Token: 0x0600012F RID: 303
		void OnContextInitialized();

		// Token: 0x06000130 RID: 304
		void OnScheduleMessagePumpWork(long delay);
	}
}
