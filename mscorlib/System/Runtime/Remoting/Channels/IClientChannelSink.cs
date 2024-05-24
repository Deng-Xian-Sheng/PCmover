using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000844 RID: 2116
	[ComVisible(true)]
	public interface IClientChannelSink : IChannelSinkBase
	{
		// Token: 0x06005A14 RID: 23060
		[SecurityCritical]
		void ProcessMessage(IMessage msg, ITransportHeaders requestHeaders, Stream requestStream, out ITransportHeaders responseHeaders, out Stream responseStream);

		// Token: 0x06005A15 RID: 23061
		[SecurityCritical]
		void AsyncProcessRequest(IClientChannelSinkStack sinkStack, IMessage msg, ITransportHeaders headers, Stream stream);

		// Token: 0x06005A16 RID: 23062
		[SecurityCritical]
		void AsyncProcessResponse(IClientResponseChannelSinkStack sinkStack, object state, ITransportHeaders headers, Stream stream);

		// Token: 0x06005A17 RID: 23063
		[SecurityCritical]
		Stream GetRequestStream(IMessage msg, ITransportHeaders headers);

		// Token: 0x17000EF8 RID: 3832
		// (get) Token: 0x06005A18 RID: 23064
		IClientChannelSink NextChannelSink { [SecurityCritical] get; }
	}
}
