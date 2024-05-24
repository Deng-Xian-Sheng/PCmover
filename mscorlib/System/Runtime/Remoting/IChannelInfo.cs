using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting
{
	// Token: 0x020007B5 RID: 1973
	[ComVisible(true)]
	public interface IChannelInfo
	{
		// Token: 0x17000E16 RID: 3606
		// (get) Token: 0x06005582 RID: 21890
		// (set) Token: 0x06005583 RID: 21891
		object[] ChannelData { [SecurityCritical] get; [SecurityCritical] set; }
	}
}
