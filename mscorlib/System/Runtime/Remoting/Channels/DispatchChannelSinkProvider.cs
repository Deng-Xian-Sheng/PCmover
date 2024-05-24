using System;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200083A RID: 2106
	internal class DispatchChannelSinkProvider : IServerChannelSinkProvider
	{
		// Token: 0x060059F6 RID: 23030 RVA: 0x0013D3F6 File Offset: 0x0013B5F6
		internal DispatchChannelSinkProvider()
		{
		}

		// Token: 0x060059F7 RID: 23031 RVA: 0x0013D3FE File Offset: 0x0013B5FE
		[SecurityCritical]
		public void GetChannelData(IChannelDataStore channelData)
		{
		}

		// Token: 0x060059F8 RID: 23032 RVA: 0x0013D400 File Offset: 0x0013B600
		[SecurityCritical]
		public IServerChannelSink CreateSink(IChannelReceiver channel)
		{
			return new DispatchChannelSink();
		}

		// Token: 0x17000EED RID: 3821
		// (get) Token: 0x060059F9 RID: 23033 RVA: 0x0013D407 File Offset: 0x0013B607
		// (set) Token: 0x060059FA RID: 23034 RVA: 0x0013D40A File Offset: 0x0013B60A
		public IServerChannelSinkProvider Next
		{
			[SecurityCritical]
			get
			{
				return null;
			}
			[SecurityCritical]
			set
			{
				throw new NotSupportedException();
			}
		}
	}
}
