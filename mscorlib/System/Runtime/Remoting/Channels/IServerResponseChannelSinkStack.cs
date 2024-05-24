using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000830 RID: 2096
	[ComVisible(true)]
	public interface IServerResponseChannelSinkStack
	{
		// Token: 0x060059AB RID: 22955
		[SecurityCritical]
		void AsyncProcessResponse(IMessage msg, ITransportHeaders headers, Stream stream);

		// Token: 0x060059AC RID: 22956
		[SecurityCritical]
		Stream GetResponseStream(IMessage msg, ITransportHeaders headers);
	}
}
