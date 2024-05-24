using System;
using System.Collections.Generic;

namespace System.Security.Policy
{
	// Token: 0x02000359 RID: 857
	internal interface IRuntimeEvidenceFactory
	{
		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x06002A73 RID: 10867
		IEvidenceFactory Target { get; }

		// Token: 0x06002A74 RID: 10868
		IEnumerable<EvidenceBase> GetFactorySuppliedEvidence();

		// Token: 0x06002A75 RID: 10869
		EvidenceBase GenerateEvidence(Type evidenceType);
	}
}
