using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000289 RID: 649
	public enum SetSPCTransactionModeMode
	{
		// Token: 0x04000A21 RID: 2593
		[EnumMember(Value = "none")]
		None,
		// Token: 0x04000A22 RID: 2594
		[EnumMember(Value = "autoaccept")]
		Autoaccept,
		// Token: 0x04000A23 RID: 2595
		[EnumMember(Value = "autoreject")]
		Autoreject
	}
}
