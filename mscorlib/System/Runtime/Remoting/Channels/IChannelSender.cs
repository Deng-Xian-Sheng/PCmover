using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200083D RID: 2109
	[ComVisible(true)]
	public interface IChannelSender : IChannel
	{
		// Token: 0x06005A04 RID: 23044
		[SecurityCritical]
		IMessageSink CreateMessageSink(string url, object remoteChannelData, out string objectURI);
	}
}
