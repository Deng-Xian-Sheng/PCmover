using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003F9 RID: 1017
	public enum DownloadProgressState
	{
		// Token: 0x04000FCF RID: 4047
		[EnumMember(Value = "inProgress")]
		InProgress,
		// Token: 0x04000FD0 RID: 4048
		[EnumMember(Value = "completed")]
		Completed,
		// Token: 0x04000FD1 RID: 4049
		[EnumMember(Value = "canceled")]
		Canceled
	}
}
