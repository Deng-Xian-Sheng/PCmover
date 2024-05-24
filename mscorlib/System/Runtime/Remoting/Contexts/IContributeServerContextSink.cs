using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x02000815 RID: 2069
	[ComVisible(true)]
	public interface IContributeServerContextSink
	{
		// Token: 0x060058D9 RID: 22745
		[SecurityCritical]
		IMessageSink GetServerContextSink(IMessageSink nextSink);
	}
}
