using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002CC RID: 716
	public enum InterceptionStage
	{
		// Token: 0x04000BCD RID: 3021
		[EnumMember(Value = "Request")]
		Request,
		// Token: 0x04000BCE RID: 3022
		[EnumMember(Value = "HeadersReceived")]
		HeadersReceived
	}
}
