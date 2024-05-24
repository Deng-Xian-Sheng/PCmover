using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Tracing
{
	// Token: 0x020001CF RID: 463
	public enum StreamFormat
	{
		// Token: 0x04000700 RID: 1792
		[EnumMember(Value = "json")]
		Json,
		// Token: 0x04000701 RID: 1793
		[EnumMember(Value = "proto")]
		Proto
	}
}
