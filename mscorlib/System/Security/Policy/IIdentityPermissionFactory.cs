using System;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	// Token: 0x02000354 RID: 852
	[ComVisible(true)]
	public interface IIdentityPermissionFactory
	{
		// Token: 0x06002A6A RID: 10858
		IPermission CreateIdentityPermission(Evidence evidence);
	}
}
