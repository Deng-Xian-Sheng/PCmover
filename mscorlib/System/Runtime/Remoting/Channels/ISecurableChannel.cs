using System;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000853 RID: 2131
	public interface ISecurableChannel
	{
		// Token: 0x17000F1A RID: 3866
		// (get) Token: 0x06005A60 RID: 23136
		// (set) Token: 0x06005A61 RID: 23137
		bool IsSecured { [SecurityCritical] get; [SecurityCritical] set; }
	}
}
