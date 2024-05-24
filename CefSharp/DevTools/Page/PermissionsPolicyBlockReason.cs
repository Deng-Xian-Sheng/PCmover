using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000234 RID: 564
	public enum PermissionsPolicyBlockReason
	{
		// Token: 0x04000884 RID: 2180
		[EnumMember(Value = "Header")]
		Header,
		// Token: 0x04000885 RID: 2181
		[EnumMember(Value = "IframeAttribute")]
		IframeAttribute,
		// Token: 0x04000886 RID: 2182
		[EnumMember(Value = "InFencedFrameTree")]
		InFencedFrameTree
	}
}
