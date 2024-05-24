using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000286 RID: 646
	public enum PrintToPDFTransferMode
	{
		// Token: 0x04000A18 RID: 2584
		[EnumMember(Value = "ReturnAsBase64")]
		ReturnAsBase64,
		// Token: 0x04000A19 RID: 2585
		[EnumMember(Value = "ReturnAsStream")]
		ReturnAsStream
	}
}
