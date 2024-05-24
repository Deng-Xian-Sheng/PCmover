using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200083B RID: 2107
	internal class DispatchChannelSink : IServerChannelSink, IChannelSinkBase
	{
		// Token: 0x060059FB RID: 23035 RVA: 0x0013D411 File Offset: 0x0013B611
		internal DispatchChannelSink()
		{
		}

		// Token: 0x060059FC RID: 23036 RVA: 0x0013D419 File Offset: 0x0013B619
		[SecurityCritical]
		public ServerProcessing ProcessMessage(IServerChannelSinkStack sinkStack, IMessage requestMsg, ITransportHeaders requestHeaders, Stream requestStream, out IMessage responseMsg, out ITransportHeaders responseHeaders, out Stream responseStream)
		{
			if (requestMsg == null)
			{
				throw new ArgumentNullException("requestMsg", Environment.GetResourceString("Remoting_Channel_DispatchSinkMessageMissing"));
			}
			if (requestStream != null)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Channel_DispatchSinkWantsNullRequestStream"));
			}
			responseHeaders = null;
			responseStream = null;
			return ChannelServices.DispatchMessage(sinkStack, requestMsg, out responseMsg);
		}

		// Token: 0x060059FD RID: 23037 RVA: 0x0013D458 File Offset: 0x0013B658
		[SecurityCritical]
		public void AsyncProcessResponse(IServerResponseChannelSinkStack sinkStack, object state, IMessage msg, ITransportHeaders headers, Stream stream)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060059FE RID: 23038 RVA: 0x0013D45F File Offset: 0x0013B65F
		[SecurityCritical]
		public Stream GetResponseStream(IServerResponseChannelSinkStack sinkStack, object state, IMessage msg, ITransportHeaders headers)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000EEE RID: 3822
		// (get) Token: 0x060059FF RID: 23039 RVA: 0x0013D466 File Offset: 0x0013B666
		public IServerChannelSink NextChannelSink
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x17000EEF RID: 3823
		// (get) Token: 0x06005A00 RID: 23040 RVA: 0x0013D469 File Offset: 0x0013B669
		public IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}
	}
}
