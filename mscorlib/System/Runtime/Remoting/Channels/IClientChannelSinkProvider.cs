using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000840 RID: 2112
	[ComVisible(true)]
	public interface IClientChannelSinkProvider
	{
		// Token: 0x06005A0D RID: 23053
		[SecurityCritical]
		IClientChannelSink CreateSink(IChannelSender channel, string url, object remoteChannelData);

		// Token: 0x17000EF6 RID: 3830
		// (get) Token: 0x06005A0E RID: 23054
		// (set) Token: 0x06005A0F RID: 23055
		IClientChannelSinkProvider Next { [SecurityCritical] get; [SecurityCritical] set; }
	}
}
