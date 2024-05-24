using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	// Token: 0x02000323 RID: 803
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IIdentity
	{
		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x06002897 RID: 10391
		[__DynamicallyInvokable]
		string Name { [__DynamicallyInvokable] get; }

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x06002898 RID: 10392
		[__DynamicallyInvokable]
		string AuthenticationType { [__DynamicallyInvokable] get; }

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x06002899 RID: 10393
		[__DynamicallyInvokable]
		bool IsAuthenticated { [__DynamicallyInvokable] get; }
	}
}
