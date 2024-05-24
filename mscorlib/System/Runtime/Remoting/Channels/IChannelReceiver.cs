using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200083E RID: 2110
	[ComVisible(true)]
	public interface IChannelReceiver : IChannel
	{
		// Token: 0x17000EF2 RID: 3826
		// (get) Token: 0x06005A05 RID: 23045
		object ChannelData { [SecurityCritical] get; }

		// Token: 0x06005A06 RID: 23046
		[SecurityCritical]
		string[] GetUrlsForUri(string objectURI);

		// Token: 0x06005A07 RID: 23047
		[SecurityCritical]
		void StartListening(object data);

		// Token: 0x06005A08 RID: 23048
		[SecurityCritical]
		void StopListening(object data);
	}
}
