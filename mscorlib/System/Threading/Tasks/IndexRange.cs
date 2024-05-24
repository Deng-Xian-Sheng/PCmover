using System;
using System.Runtime.InteropServices;

namespace System.Threading.Tasks
{
	// Token: 0x02000551 RID: 1361
	[StructLayout(LayoutKind.Auto)]
	internal struct IndexRange
	{
		// Token: 0x04001AC9 RID: 6857
		internal long m_nFromInclusive;

		// Token: 0x04001ACA RID: 6858
		internal long m_nToExclusive;

		// Token: 0x04001ACB RID: 6859
		internal volatile Shared<long> m_nSharedCurrentIndexOffset;

		// Token: 0x04001ACC RID: 6860
		internal int m_bRangeFinished;
	}
}
