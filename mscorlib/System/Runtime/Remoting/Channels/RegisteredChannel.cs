using System;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000828 RID: 2088
	internal class RegisteredChannel
	{
		// Token: 0x06005987 RID: 22919 RVA: 0x0013BDD0 File Offset: 0x00139FD0
		internal RegisteredChannel(IChannel chnl)
		{
			this.channel = chnl;
			this.flags = 0;
			if (chnl is IChannelSender)
			{
				this.flags |= 1;
			}
			if (chnl is IChannelReceiver)
			{
				this.flags |= 2;
			}
		}

		// Token: 0x17000ED9 RID: 3801
		// (get) Token: 0x06005988 RID: 22920 RVA: 0x0013BE1F File Offset: 0x0013A01F
		internal virtual IChannel Channel
		{
			get
			{
				return this.channel;
			}
		}

		// Token: 0x06005989 RID: 22921 RVA: 0x0013BE27 File Offset: 0x0013A027
		internal virtual bool IsSender()
		{
			return (this.flags & 1) > 0;
		}

		// Token: 0x0600598A RID: 22922 RVA: 0x0013BE34 File Offset: 0x0013A034
		internal virtual bool IsReceiver()
		{
			return (this.flags & 2) > 0;
		}

		// Token: 0x040028C2 RID: 10434
		private IChannel channel;

		// Token: 0x040028C3 RID: 10435
		private byte flags;

		// Token: 0x040028C4 RID: 10436
		private const byte SENDER = 1;

		// Token: 0x040028C5 RID: 10437
		private const byte RECEIVER = 2;
	}
}
