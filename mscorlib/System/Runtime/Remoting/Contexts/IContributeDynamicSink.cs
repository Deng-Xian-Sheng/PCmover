using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x02000812 RID: 2066
	[ComVisible(true)]
	public interface IContributeDynamicSink
	{
		// Token: 0x060058D6 RID: 22742
		[SecurityCritical]
		IDynamicMessageSink GetDynamicSink();
	}
}
