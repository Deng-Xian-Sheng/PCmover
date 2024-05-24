using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.SystemInfo
{
	// Token: 0x020001F4 RID: 500
	public enum ImageType
	{
		// Token: 0x04000757 RID: 1879
		[EnumMember(Value = "jpeg")]
		Jpeg,
		// Token: 0x04000758 RID: 1880
		[EnumMember(Value = "webp")]
		Webp,
		// Token: 0x04000759 RID: 1881
		[EnumMember(Value = "unknown")]
		Unknown
	}
}
