using System;

namespace System.Runtime.Serialization
{
	// Token: 0x0200074C RID: 1868
	[Serializable]
	internal class FixupHolder
	{
		// Token: 0x060052AC RID: 21164 RVA: 0x00122A86 File Offset: 0x00120C86
		internal FixupHolder(long id, object fixupInfo, int fixupType)
		{
			this.m_id = id;
			this.m_fixupInfo = fixupInfo;
			this.m_fixupType = fixupType;
		}

		// Token: 0x04002498 RID: 9368
		internal const int ArrayFixup = 1;

		// Token: 0x04002499 RID: 9369
		internal const int MemberFixup = 2;

		// Token: 0x0400249A RID: 9370
		internal const int DelayedFixup = 4;

		// Token: 0x0400249B RID: 9371
		internal long m_id;

		// Token: 0x0400249C RID: 9372
		internal object m_fixupInfo;

		// Token: 0x0400249D RID: 9373
		internal int m_fixupType;
	}
}
