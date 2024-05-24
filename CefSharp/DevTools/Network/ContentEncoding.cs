using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002D3 RID: 723
	public enum ContentEncoding
	{
		// Token: 0x04000BEF RID: 3055
		[EnumMember(Value = "deflate")]
		Deflate,
		// Token: 0x04000BF0 RID: 3056
		[EnumMember(Value = "gzip")]
		Gzip,
		// Token: 0x04000BF1 RID: 3057
		[EnumMember(Value = "br")]
		Br
	}
}
