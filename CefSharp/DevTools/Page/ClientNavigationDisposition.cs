using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200024E RID: 590
	public enum ClientNavigationDisposition
	{
		// Token: 0x04000911 RID: 2321
		[EnumMember(Value = "currentTab")]
		CurrentTab,
		// Token: 0x04000912 RID: 2322
		[EnumMember(Value = "newTab")]
		NewTab,
		// Token: 0x04000913 RID: 2323
		[EnumMember(Value = "newWindow")]
		NewWindow,
		// Token: 0x04000914 RID: 2324
		[EnumMember(Value = "download")]
		Download
	}
}
