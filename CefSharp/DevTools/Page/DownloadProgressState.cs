using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000266 RID: 614
	public enum DownloadProgressState
	{
		// Token: 0x040009CE RID: 2510
		[EnumMember(Value = "inProgress")]
		InProgress,
		// Token: 0x040009CF RID: 2511
		[EnumMember(Value = "completed")]
		Completed,
		// Token: 0x040009D0 RID: 2512
		[EnumMember(Value = "canceled")]
		Canceled
	}
}
