using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Emulation
{
	// Token: 0x02000354 RID: 852
	public enum VirtualTimePolicy
	{
		// Token: 0x04000DA3 RID: 3491
		[EnumMember(Value = "advance")]
		Advance,
		// Token: 0x04000DA4 RID: 3492
		[EnumMember(Value = "pause")]
		Pause,
		// Token: 0x04000DA5 RID: 3493
		[EnumMember(Value = "pauseIfNetworkFetchesPending")]
		PauseIfNetworkFetchesPending
	}
}
