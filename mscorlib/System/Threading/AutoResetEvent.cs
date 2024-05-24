using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Threading
{
	// Token: 0x020004E9 RID: 1257
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public sealed class AutoResetEvent : EventWaitHandle
	{
		// Token: 0x06003B85 RID: 15237 RVA: 0x000E24A6 File Offset: 0x000E06A6
		[__DynamicallyInvokable]
		public AutoResetEvent(bool initialState) : base(initialState, EventResetMode.AutoReset)
		{
		}
	}
}
