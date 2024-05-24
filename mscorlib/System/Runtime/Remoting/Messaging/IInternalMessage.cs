using System;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000855 RID: 2133
	internal interface IInternalMessage
	{
		// Token: 0x17000F22 RID: 3874
		// (get) Token: 0x06005A70 RID: 23152
		// (set) Token: 0x06005A71 RID: 23153
		ServerIdentity ServerIdentityObject { [SecurityCritical] get; [SecurityCritical] set; }

		// Token: 0x17000F23 RID: 3875
		// (get) Token: 0x06005A72 RID: 23154
		// (set) Token: 0x06005A73 RID: 23155
		Identity IdentityObject { [SecurityCritical] get; [SecurityCritical] set; }

		// Token: 0x06005A74 RID: 23156
		[SecurityCritical]
		void SetURI(string uri);

		// Token: 0x06005A75 RID: 23157
		[SecurityCritical]
		void SetCallContext(LogicalCallContext callContext);

		// Token: 0x06005A76 RID: 23158
		[SecurityCritical]
		bool HasProperties();
	}
}
