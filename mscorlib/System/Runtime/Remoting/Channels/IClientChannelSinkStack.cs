using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200082C RID: 2092
	[ComVisible(true)]
	public interface IClientChannelSinkStack : IClientResponseChannelSinkStack
	{
		// Token: 0x0600599A RID: 22938
		[SecurityCritical]
		void Push(IClientChannelSink sink, object state);

		// Token: 0x0600599B RID: 22939
		[SecurityCritical]
		object Pop(IClientChannelSink sink);
	}
}
