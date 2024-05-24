using System;

namespace System.Security.Policy
{
	// Token: 0x02000356 RID: 854
	internal interface IDelayEvaluatedEvidence
	{
		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x06002A6B RID: 10859
		bool IsVerified { [SecurityCritical] get; }

		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x06002A6C RID: 10860
		bool WasUsed { get; }

		// Token: 0x06002A6D RID: 10861
		void MarkUsed();
	}
}
