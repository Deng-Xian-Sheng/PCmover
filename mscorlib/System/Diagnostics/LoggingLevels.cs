using System;

namespace System.Diagnostics
{
	// Token: 0x020003F4 RID: 1012
	[Serializable]
	internal enum LoggingLevels
	{
		// Token: 0x040016B5 RID: 5813
		TraceLevel0,
		// Token: 0x040016B6 RID: 5814
		TraceLevel1,
		// Token: 0x040016B7 RID: 5815
		TraceLevel2,
		// Token: 0x040016B8 RID: 5816
		TraceLevel3,
		// Token: 0x040016B9 RID: 5817
		TraceLevel4,
		// Token: 0x040016BA RID: 5818
		StatusLevel0 = 20,
		// Token: 0x040016BB RID: 5819
		StatusLevel1,
		// Token: 0x040016BC RID: 5820
		StatusLevel2,
		// Token: 0x040016BD RID: 5821
		StatusLevel3,
		// Token: 0x040016BE RID: 5822
		StatusLevel4,
		// Token: 0x040016BF RID: 5823
		WarningLevel = 40,
		// Token: 0x040016C0 RID: 5824
		ErrorLevel = 50,
		// Token: 0x040016C1 RID: 5825
		PanicLevel = 100
	}
}
