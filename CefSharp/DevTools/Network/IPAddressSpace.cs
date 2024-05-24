using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002D5 RID: 725
	public enum IPAddressSpace
	{
		// Token: 0x04000BF9 RID: 3065
		[EnumMember(Value = "Local")]
		Local,
		// Token: 0x04000BFA RID: 3066
		[EnumMember(Value = "Private")]
		Private,
		// Token: 0x04000BFB RID: 3067
		[EnumMember(Value = "Public")]
		Public,
		// Token: 0x04000BFC RID: 3068
		[EnumMember(Value = "Unknown")]
		Unknown
	}
}
