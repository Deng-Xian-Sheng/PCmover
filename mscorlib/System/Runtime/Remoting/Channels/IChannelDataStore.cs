using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000849 RID: 2121
	[ComVisible(true)]
	public interface IChannelDataStore
	{
		// Token: 0x17000EFB RID: 3835
		// (get) Token: 0x06005A1E RID: 23070
		string[] ChannelUris { [SecurityCritical] get; }

		// Token: 0x17000EFC RID: 3836
		object this[object key]
		{
			[SecurityCritical]
			get;
			[SecurityCritical]
			set;
		}
	}
}
