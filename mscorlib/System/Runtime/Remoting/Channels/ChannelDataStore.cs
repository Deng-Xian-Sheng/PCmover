using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200084A RID: 2122
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	[Serializable]
	public class ChannelDataStore : IChannelDataStore
	{
		// Token: 0x06005A21 RID: 23073 RVA: 0x0013D46C File Offset: 0x0013B66C
		private ChannelDataStore(string[] channelUrls, DictionaryEntry[] extraData)
		{
			this._channelURIs = channelUrls;
			this._extraData = extraData;
		}

		// Token: 0x06005A22 RID: 23074 RVA: 0x0013D482 File Offset: 0x0013B682
		public ChannelDataStore(string[] channelURIs)
		{
			this._channelURIs = channelURIs;
			this._extraData = null;
		}

		// Token: 0x06005A23 RID: 23075 RVA: 0x0013D498 File Offset: 0x0013B698
		[SecurityCritical]
		internal ChannelDataStore InternalShallowCopy()
		{
			return new ChannelDataStore(this._channelURIs, this._extraData);
		}

		// Token: 0x17000EFD RID: 3837
		// (get) Token: 0x06005A24 RID: 23076 RVA: 0x0013D4AB File Offset: 0x0013B6AB
		// (set) Token: 0x06005A25 RID: 23077 RVA: 0x0013D4B3 File Offset: 0x0013B6B3
		public string[] ChannelUris
		{
			[SecurityCritical]
			get
			{
				return this._channelURIs;
			}
			set
			{
				this._channelURIs = value;
			}
		}

		// Token: 0x17000EFE RID: 3838
		public object this[object key]
		{
			[SecurityCritical]
			get
			{
				foreach (DictionaryEntry dictionaryEntry in this._extraData)
				{
					if (dictionaryEntry.Key.Equals(key))
					{
						return dictionaryEntry.Value;
					}
				}
				return null;
			}
			[SecurityCritical]
			set
			{
				if (this._extraData == null)
				{
					this._extraData = new DictionaryEntry[1];
					this._extraData[0] = new DictionaryEntry(key, value);
					return;
				}
				int num = this._extraData.Length;
				DictionaryEntry[] array = new DictionaryEntry[num + 1];
				int i;
				for (i = 0; i < num; i++)
				{
					array[i] = this._extraData[i];
				}
				array[i] = new DictionaryEntry(key, value);
				this._extraData = array;
			}
		}

		// Token: 0x040028F4 RID: 10484
		private string[] _channelURIs;

		// Token: 0x040028F5 RID: 10485
		private DictionaryEntry[] _extraData;
	}
}
