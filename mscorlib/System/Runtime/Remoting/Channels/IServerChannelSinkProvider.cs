using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000841 RID: 2113
	[ComVisible(true)]
	public interface IServerChannelSinkProvider
	{
		// Token: 0x06005A10 RID: 23056
		[SecurityCritical]
		void GetChannelData(IChannelDataStore channelData);

		// Token: 0x06005A11 RID: 23057
		[SecurityCritical]
		IServerChannelSink CreateSink(IChannelReceiver channel);

		// Token: 0x17000EF7 RID: 3831
		// (get) Token: 0x06005A12 RID: 23058
		// (set) Token: 0x06005A13 RID: 23059
		IServerChannelSinkProvider Next { [SecurityCritical] get; [SecurityCritical] set; }
	}
}
