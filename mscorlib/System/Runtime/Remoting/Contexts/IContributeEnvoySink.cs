using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x02000813 RID: 2067
	[ComVisible(true)]
	public interface IContributeEnvoySink
	{
		// Token: 0x060058D7 RID: 22743
		[SecurityCritical]
		IMessageSink GetEnvoySink(MarshalByRefObject obj, IMessageSink nextSink);
	}
}
