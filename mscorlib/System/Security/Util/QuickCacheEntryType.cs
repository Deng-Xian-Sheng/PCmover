using System;

namespace System.Security.Util
{
	// Token: 0x02000378 RID: 888
	[Flags]
	[Serializable]
	internal enum QuickCacheEntryType
	{
		// Token: 0x040011B6 RID: 4534
		FullTrustZoneMyComputer = 16777216,
		// Token: 0x040011B7 RID: 4535
		FullTrustZoneIntranet = 33554432,
		// Token: 0x040011B8 RID: 4536
		FullTrustZoneInternet = 67108864,
		// Token: 0x040011B9 RID: 4537
		FullTrustZoneTrusted = 134217728,
		// Token: 0x040011BA RID: 4538
		FullTrustZoneUntrusted = 268435456,
		// Token: 0x040011BB RID: 4539
		FullTrustAll = 536870912
	}
}
