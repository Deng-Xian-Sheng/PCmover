﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000846 RID: 2118
	[ComVisible(true)]
	public interface IServerChannelSink : IChannelSinkBase
	{
		// Token: 0x06005A19 RID: 23065
		[SecurityCritical]
		ServerProcessing ProcessMessage(IServerChannelSinkStack sinkStack, IMessage requestMsg, ITransportHeaders requestHeaders, Stream requestStream, out IMessage responseMsg, out ITransportHeaders responseHeaders, out Stream responseStream);

		// Token: 0x06005A1A RID: 23066
		[SecurityCritical]
		void AsyncProcessResponse(IServerResponseChannelSinkStack sinkStack, object state, IMessage msg, ITransportHeaders headers, Stream stream);

		// Token: 0x06005A1B RID: 23067
		[SecurityCritical]
		Stream GetResponseStream(IServerResponseChannelSinkStack sinkStack, object state, IMessage msg, ITransportHeaders headers);

		// Token: 0x17000EF9 RID: 3833
		// (get) Token: 0x06005A1C RID: 23068
		IServerChannelSink NextChannelSink { [SecurityCritical] get; }
	}
}
