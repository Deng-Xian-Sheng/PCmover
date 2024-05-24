using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting
{
	// Token: 0x020007B6 RID: 1974
	[ComVisible(true)]
	public interface IEnvoyInfo
	{
		// Token: 0x17000E17 RID: 3607
		// (get) Token: 0x06005584 RID: 21892
		// (set) Token: 0x06005585 RID: 21893
		IMessageSink EnvoySinks { [SecurityCritical] get; [SecurityCritical] set; }
	}
}
