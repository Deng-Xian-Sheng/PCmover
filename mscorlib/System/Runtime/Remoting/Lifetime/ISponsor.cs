using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Lifetime
{
	// Token: 0x0200081E RID: 2078
	[ComVisible(true)]
	public interface ISponsor
	{
		// Token: 0x06005923 RID: 22819
		[SecurityCritical]
		TimeSpan Renewal(ILease lease);
	}
}
