using System;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x020000D7 RID: 215
	[Flags]
	public enum PropertyColumnStateOptions
	{
		// Token: 0x040003CD RID: 973
		None = 0,
		// Token: 0x040003CE RID: 974
		StringType = 1,
		// Token: 0x040003CF RID: 975
		IntegerType = 2,
		// Token: 0x040003D0 RID: 976
		DateType = 3,
		// Token: 0x040003D1 RID: 977
		TypeMask = 15,
		// Token: 0x040003D2 RID: 978
		OnByDefault = 16,
		// Token: 0x040003D3 RID: 979
		Slow = 32,
		// Token: 0x040003D4 RID: 980
		Extended = 64,
		// Token: 0x040003D5 RID: 981
		SecondaryUI = 128,
		// Token: 0x040003D6 RID: 982
		Hidden = 256,
		// Token: 0x040003D7 RID: 983
		PreferVariantCompare = 512,
		// Token: 0x040003D8 RID: 984
		PreferFormatForDisplay = 1024,
		// Token: 0x040003D9 RID: 985
		NoSortByFolders = 2048,
		// Token: 0x040003DA RID: 986
		ViewOnly = 65536,
		// Token: 0x040003DB RID: 987
		BatchRead = 131072,
		// Token: 0x040003DC RID: 988
		NoGroupBy = 262144,
		// Token: 0x040003DD RID: 989
		FixedWidth = 4096,
		// Token: 0x040003DE RID: 990
		NoDpiScale = 8192,
		// Token: 0x040003DF RID: 991
		FixedRatio = 16384,
		// Token: 0x040003E0 RID: 992
		DisplayMask = 61440
	}
}
