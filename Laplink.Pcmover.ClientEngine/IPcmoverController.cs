using System;
using Laplink.Pcmover.Contracts;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x02000006 RID: 6
	public interface IPcmoverController
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000039 RID: 57
		IPcmoverControl ControlInterface { get; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003A RID: 58
		string HostName { get; }
	}
}
