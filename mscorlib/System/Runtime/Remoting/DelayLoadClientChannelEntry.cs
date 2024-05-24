using System;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Channels;
using System.Security;

namespace System.Runtime.Remoting
{
	// Token: 0x020007AF RID: 1967
	internal class DelayLoadClientChannelEntry
	{
		// Token: 0x0600553D RID: 21821 RVA: 0x0012EF12 File Offset: 0x0012D112
		internal DelayLoadClientChannelEntry(RemotingXmlConfigFileData.ChannelEntry entry, bool ensureSecurity)
		{
			this._entry = entry;
			this._channel = null;
			this._bRegistered = false;
			this._ensureSecurity = ensureSecurity;
		}

		// Token: 0x17000E03 RID: 3587
		// (get) Token: 0x0600553E RID: 21822 RVA: 0x0012EF36 File Offset: 0x0012D136
		internal IChannelSender Channel
		{
			[SecurityCritical]
			get
			{
				if (this._channel == null && !this._bRegistered)
				{
					this._channel = (IChannelSender)RemotingConfigHandler.CreateChannelFromConfigEntry(this._entry);
					this._entry = null;
				}
				return this._channel;
			}
		}

		// Token: 0x0600553F RID: 21823 RVA: 0x0012EF6B File Offset: 0x0012D16B
		internal void RegisterChannel()
		{
			ChannelServices.RegisterChannel(this._channel, this._ensureSecurity);
			this._bRegistered = true;
			this._channel = null;
		}

		// Token: 0x04002737 RID: 10039
		private RemotingXmlConfigFileData.ChannelEntry _entry;

		// Token: 0x04002738 RID: 10040
		private IChannelSender _channel;

		// Token: 0x04002739 RID: 10041
		private bool _bRegistered;

		// Token: 0x0400273A RID: 10042
		private bool _ensureSecurity;
	}
}
