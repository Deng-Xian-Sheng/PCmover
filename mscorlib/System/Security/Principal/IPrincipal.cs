using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	// Token: 0x02000324 RID: 804
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IPrincipal
	{
		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x0600289A RID: 10394
		[__DynamicallyInvokable]
		IIdentity Identity { [__DynamicallyInvokable] get; }

		// Token: 0x0600289B RID: 10395
		[__DynamicallyInvokable]
		bool IsInRole(string role);
	}
}
