using System;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
	// Token: 0x02000019 RID: 25
	[Flags]
	internal enum StorageStreamCommitOptions
	{
		// Token: 0x0400003D RID: 61
		None = 0,
		// Token: 0x0400003E RID: 62
		Overwrite = 1,
		// Token: 0x0400003F RID: 63
		OnlyIfCurrent = 2,
		// Token: 0x04000040 RID: 64
		DangerouslyCommitMerelyToDiskCache = 4,
		// Token: 0x04000041 RID: 65
		Consolidate = 8
	}
}
