using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200083F RID: 2111
	[ComVisible(true)]
	public interface IChannelReceiverHook
	{
		// Token: 0x17000EF3 RID: 3827
		// (get) Token: 0x06005A09 RID: 23049
		string ChannelScheme { [SecurityCritical] get; }

		// Token: 0x17000EF4 RID: 3828
		// (get) Token: 0x06005A0A RID: 23050
		bool WantsToListen { [SecurityCritical] get; }

		// Token: 0x17000EF5 RID: 3829
		// (get) Token: 0x06005A0B RID: 23051
		IServerChannelSink ChannelSinkChain { [SecurityCritical] get; }

		// Token: 0x06005A0C RID: 23052
		[SecurityCritical]
		void AddHookChannelUri(string channelUri);
	}
}
