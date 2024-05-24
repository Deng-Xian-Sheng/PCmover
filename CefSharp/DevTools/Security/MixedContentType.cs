using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Security
{
	// Token: 0x02000215 RID: 533
	public enum MixedContentType
	{
		// Token: 0x040007CA RID: 1994
		[EnumMember(Value = "blockable")]
		Blockable,
		// Token: 0x040007CB RID: 1995
		[EnumMember(Value = "optionally-blockable")]
		OptionallyBlockable,
		// Token: 0x040007CC RID: 1996
		[EnumMember(Value = "none")]
		None
	}
}
