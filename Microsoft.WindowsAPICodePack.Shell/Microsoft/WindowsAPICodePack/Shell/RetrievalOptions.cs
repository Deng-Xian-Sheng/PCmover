using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000068 RID: 104
	internal enum RetrievalOptions
	{
		// Token: 0x04000244 RID: 580
		None,
		// Token: 0x04000245 RID: 581
		Create = 32768,
		// Token: 0x04000246 RID: 582
		DontVerify = 16384,
		// Token: 0x04000247 RID: 583
		DontUnexpand = 8192,
		// Token: 0x04000248 RID: 584
		NoAlias = 4096,
		// Token: 0x04000249 RID: 585
		Init = 2048,
		// Token: 0x0400024A RID: 586
		DefaultPath = 1024,
		// Token: 0x0400024B RID: 587
		NotParentRelative = 512
	}
}
