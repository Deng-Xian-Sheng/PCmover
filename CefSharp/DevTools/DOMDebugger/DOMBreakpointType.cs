using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMDebugger
{
	// Token: 0x02000378 RID: 888
	public enum DOMBreakpointType
	{
		// Token: 0x04000E3B RID: 3643
		[EnumMember(Value = "subtree-modified")]
		SubtreeModified,
		// Token: 0x04000E3C RID: 3644
		[EnumMember(Value = "attribute-modified")]
		AttributeModified,
		// Token: 0x04000E3D RID: 3645
		[EnumMember(Value = "node-removed")]
		NodeRemoved
	}
}
