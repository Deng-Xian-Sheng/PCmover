using System;

namespace Laplink.Service.Infrastructure
{
	// Token: 0x02000007 RID: 7
	public interface IUiCallbackControl
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000046 RID: 70
		bool CanSendUiCallback { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000047 RID: 71
		bool UseDefaultUiResponse { get; }
	}
}
