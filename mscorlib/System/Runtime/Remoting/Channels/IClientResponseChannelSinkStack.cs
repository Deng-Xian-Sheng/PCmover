using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200082D RID: 2093
	[ComVisible(true)]
	public interface IClientResponseChannelSinkStack
	{
		// Token: 0x0600599C RID: 22940
		[SecurityCritical]
		void AsyncProcessResponse(ITransportHeaders headers, Stream stream);

		// Token: 0x0600599D RID: 22941
		[SecurityCritical]
		void DispatchReplyMessage(IMessage msg);

		// Token: 0x0600599E RID: 22942
		[SecurityCritical]
		void DispatchException(Exception e);
	}
}
