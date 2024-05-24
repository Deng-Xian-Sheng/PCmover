using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x02000811 RID: 2065
	[ComVisible(true)]
	public interface IContributeClientContextSink
	{
		// Token: 0x060058D5 RID: 22741
		[SecurityCritical]
		IMessageSink GetClientContextSink(IMessageSink nextSink);
	}
}
