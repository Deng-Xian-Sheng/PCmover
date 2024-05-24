using System;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000012 RID: 18
	public interface ITransferParametersActivity
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000058 RID: 88
		ServiceTransferMethod ActivityServiceTransferMethod { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000059 RID: 89
		ServiceTask ActivityFillServiceTask { get; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600005A RID: 90
		bool ActivityAllowUndo { get; }
	}
}
