using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200083C RID: 2108
	[ComVisible(true)]
	public interface IChannel
	{
		// Token: 0x17000EF0 RID: 3824
		// (get) Token: 0x06005A01 RID: 23041
		int ChannelPriority { [SecurityCritical] get; }

		// Token: 0x17000EF1 RID: 3825
		// (get) Token: 0x06005A02 RID: 23042
		string ChannelName { [SecurityCritical] get; }

		// Token: 0x06005A03 RID: 23043
		[SecurityCritical]
		string Parse(string url, out string objectURI);
	}
}
