using System;

namespace CefSharp.Internals
{
	// Token: 0x020000DE RID: 222
	public sealed class MethodInvocationCompleteArgs : EventArgs
	{
		// Token: 0x1700020C RID: 524
		// (get) Token: 0x060006BC RID: 1724 RVA: 0x0000AFCA File Offset: 0x000091CA
		// (set) Token: 0x060006BD RID: 1725 RVA: 0x0000AFD2 File Offset: 0x000091D2
		public MethodInvocationResult Result { get; private set; }

		// Token: 0x060006BE RID: 1726 RVA: 0x0000AFDB File Offset: 0x000091DB
		public MethodInvocationCompleteArgs(MethodInvocationResult result)
		{
			this.Result = result;
		}
	}
}
