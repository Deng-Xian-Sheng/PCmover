using System;

namespace CefSharp.RenderProcess
{
	// Token: 0x020000B0 RID: 176
	public interface IRenderProcessHandler
	{
		// Token: 0x06000564 RID: 1380
		void OnContextCreated(IBrowser browser, IFrame frame, IV8Context context);

		// Token: 0x06000565 RID: 1381
		void OnContextReleased(IBrowser browser, IFrame frame, IV8Context context);

		// Token: 0x06000566 RID: 1382
		void OnWebKitInitialized();
	}
}
