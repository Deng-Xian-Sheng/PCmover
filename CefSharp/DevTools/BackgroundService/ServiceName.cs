using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.BackgroundService
{
	// Token: 0x02000403 RID: 1027
	public enum ServiceName
	{
		// Token: 0x04000FE8 RID: 4072
		[EnumMember(Value = "backgroundFetch")]
		BackgroundFetch,
		// Token: 0x04000FE9 RID: 4073
		[EnumMember(Value = "backgroundSync")]
		BackgroundSync,
		// Token: 0x04000FEA RID: 4074
		[EnumMember(Value = "pushMessaging")]
		PushMessaging,
		// Token: 0x04000FEB RID: 4075
		[EnumMember(Value = "notifications")]
		Notifications,
		// Token: 0x04000FEC RID: 4076
		[EnumMember(Value = "paymentHandler")]
		PaymentHandler,
		// Token: 0x04000FED RID: 4077
		[EnumMember(Value = "periodicBackgroundSync")]
		PeriodicBackgroundSync
	}
}
