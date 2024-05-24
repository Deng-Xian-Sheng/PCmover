using System;
using System.Runtime.Remoting.Channels;
using System.Security;

namespace System.Runtime.Remoting
{
	// Token: 0x020007B9 RID: 1977
	[Serializable]
	internal sealed class ChannelInfo : IChannelInfo
	{
		// Token: 0x06005596 RID: 21910 RVA: 0x0012FF9E File Offset: 0x0012E19E
		[SecurityCritical]
		internal ChannelInfo()
		{
			this.ChannelData = ChannelServices.CurrentChannelData;
		}

		// Token: 0x17000E1C RID: 3612
		// (get) Token: 0x06005597 RID: 21911 RVA: 0x0012FFB1 File Offset: 0x0012E1B1
		// (set) Token: 0x06005598 RID: 21912 RVA: 0x0012FFB9 File Offset: 0x0012E1B9
		public object[] ChannelData
		{
			[SecurityCritical]
			get
			{
				return this.channelData;
			}
			[SecurityCritical]
			set
			{
				this.channelData = value;
			}
		}

		// Token: 0x04002761 RID: 10081
		private object[] channelData;
	}
}
