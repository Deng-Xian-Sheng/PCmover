using System;
using System.Runtime.InteropServices;

namespace System.Security
{
	// Token: 0x020001D2 RID: 466
	[ComVisible(true)]
	public interface IPermission : ISecurityEncodable
	{
		// Token: 0x06001C6E RID: 7278
		IPermission Copy();

		// Token: 0x06001C6F RID: 7279
		IPermission Intersect(IPermission target);

		// Token: 0x06001C70 RID: 7280
		IPermission Union(IPermission target);

		// Token: 0x06001C71 RID: 7281
		bool IsSubsetOf(IPermission target);

		// Token: 0x06001C72 RID: 7282
		void Demand();
	}
}
