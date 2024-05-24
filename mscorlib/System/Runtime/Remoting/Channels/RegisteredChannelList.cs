using System;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000829 RID: 2089
	internal class RegisteredChannelList
	{
		// Token: 0x0600598B RID: 22923 RVA: 0x0013BE41 File Offset: 0x0013A041
		internal RegisteredChannelList()
		{
			this._channels = new RegisteredChannel[0];
		}

		// Token: 0x0600598C RID: 22924 RVA: 0x0013BE55 File Offset: 0x0013A055
		internal RegisteredChannelList(RegisteredChannel[] channels)
		{
			this._channels = channels;
		}

		// Token: 0x17000EDA RID: 3802
		// (get) Token: 0x0600598D RID: 22925 RVA: 0x0013BE64 File Offset: 0x0013A064
		internal RegisteredChannel[] RegisteredChannels
		{
			get
			{
				return this._channels;
			}
		}

		// Token: 0x17000EDB RID: 3803
		// (get) Token: 0x0600598E RID: 22926 RVA: 0x0013BE6C File Offset: 0x0013A06C
		internal int Count
		{
			get
			{
				if (this._channels == null)
				{
					return 0;
				}
				return this._channels.Length;
			}
		}

		// Token: 0x0600598F RID: 22927 RVA: 0x0013BE80 File Offset: 0x0013A080
		internal IChannel GetChannel(int index)
		{
			return this._channels[index].Channel;
		}

		// Token: 0x06005990 RID: 22928 RVA: 0x0013BE8F File Offset: 0x0013A08F
		internal bool IsSender(int index)
		{
			return this._channels[index].IsSender();
		}

		// Token: 0x06005991 RID: 22929 RVA: 0x0013BE9E File Offset: 0x0013A09E
		internal bool IsReceiver(int index)
		{
			return this._channels[index].IsReceiver();
		}

		// Token: 0x17000EDC RID: 3804
		// (get) Token: 0x06005992 RID: 22930 RVA: 0x0013BEB0 File Offset: 0x0013A0B0
		internal int ReceiverCount
		{
			get
			{
				if (this._channels == null)
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < this._channels.Length; i++)
				{
					if (this.IsReceiver(i))
					{
						num++;
					}
				}
				return num;
			}
		}

		// Token: 0x06005993 RID: 22931 RVA: 0x0013BEEC File Offset: 0x0013A0EC
		internal int FindChannelIndex(IChannel channel)
		{
			for (int i = 0; i < this._channels.Length; i++)
			{
				if (channel == this.GetChannel(i))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06005994 RID: 22932 RVA: 0x0013BF1C File Offset: 0x0013A11C
		[SecurityCritical]
		internal int FindChannelIndex(string name)
		{
			for (int i = 0; i < this._channels.Length; i++)
			{
				if (string.Compare(name, this.GetChannel(i).ChannelName, StringComparison.OrdinalIgnoreCase) == 0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x040028C6 RID: 10438
		private RegisteredChannel[] _channels;
	}
}
