using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002DD RID: 733
	public enum ReportStatus
	{
		// Token: 0x04000C16 RID: 3094
		[EnumMember(Value = "Queued")]
		Queued,
		// Token: 0x04000C17 RID: 3095
		[EnumMember(Value = "Pending")]
		Pending,
		// Token: 0x04000C18 RID: 3096
		[EnumMember(Value = "MarkedForRemoval")]
		MarkedForRemoval,
		// Token: 0x04000C19 RID: 3097
		[EnumMember(Value = "Success")]
		Success
	}
}
