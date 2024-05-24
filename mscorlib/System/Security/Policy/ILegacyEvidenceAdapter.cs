using System;

namespace System.Security.Policy
{
	// Token: 0x0200034E RID: 846
	internal interface ILegacyEvidenceAdapter
	{
		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x06002A39 RID: 10809
		object EvidenceObject { get; }

		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x06002A3A RID: 10810
		Type EvidenceType { get; }
	}
}
