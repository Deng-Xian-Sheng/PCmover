using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting
{
	// Token: 0x020007B4 RID: 1972
	[ComVisible(true)]
	public interface IRemotingTypeInfo
	{
		// Token: 0x17000E15 RID: 3605
		// (get) Token: 0x0600557F RID: 21887
		// (set) Token: 0x06005580 RID: 21888
		string TypeName { [SecurityCritical] get; [SecurityCritical] set; }

		// Token: 0x06005581 RID: 21889
		[SecurityCritical]
		bool CanCastTo(Type fromType, object o);
	}
}
