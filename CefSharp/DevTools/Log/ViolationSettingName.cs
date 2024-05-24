using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Log
{
	// Token: 0x0200031B RID: 795
	public enum ViolationSettingName
	{
		// Token: 0x04000CF0 RID: 3312
		[EnumMember(Value = "longTask")]
		LongTask,
		// Token: 0x04000CF1 RID: 3313
		[EnumMember(Value = "longLayout")]
		LongLayout,
		// Token: 0x04000CF2 RID: 3314
		[EnumMember(Value = "blockedEvent")]
		BlockedEvent,
		// Token: 0x04000CF3 RID: 3315
		[EnumMember(Value = "blockedParser")]
		BlockedParser,
		// Token: 0x04000CF4 RID: 3316
		[EnumMember(Value = "discouragedAPIUse")]
		DiscouragedAPIUse,
		// Token: 0x04000CF5 RID: 3317
		[EnumMember(Value = "handler")]
		Handler,
		// Token: 0x04000CF6 RID: 3318
		[EnumMember(Value = "recurringHandler")]
		RecurringHandler
	}
}
