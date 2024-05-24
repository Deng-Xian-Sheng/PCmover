using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000856 RID: 2134
	[ComVisible(true)]
	public interface IMessage
	{
		// Token: 0x17000F24 RID: 3876
		// (get) Token: 0x06005A77 RID: 23159
		IDictionary Properties { [SecurityCritical] get; }
	}
}
