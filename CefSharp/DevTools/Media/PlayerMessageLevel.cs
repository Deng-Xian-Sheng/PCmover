using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Media
{
	// Token: 0x02000193 RID: 403
	public enum PlayerMessageLevel
	{
		// Token: 0x04000641 RID: 1601
		[EnumMember(Value = "error")]
		Error,
		// Token: 0x04000642 RID: 1602
		[EnumMember(Value = "warning")]
		Warning,
		// Token: 0x04000643 RID: 1603
		[EnumMember(Value = "info")]
		Info,
		// Token: 0x04000644 RID: 1604
		[EnumMember(Value = "debug")]
		Debug
	}
}
