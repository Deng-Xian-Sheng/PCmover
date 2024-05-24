using System;

namespace ControlzEx.Standard
{
	// Token: 0x0200009A RID: 154
	[Flags]
	internal enum SHGDN
	{
		// Token: 0x04000689 RID: 1673
		SHGDN_NORMAL = 0,
		// Token: 0x0400068A RID: 1674
		SHGDN_INFOLDER = 1,
		// Token: 0x0400068B RID: 1675
		SHGDN_FOREDITING = 4096,
		// Token: 0x0400068C RID: 1676
		SHGDN_FORADDRESSBAR = 16384,
		// Token: 0x0400068D RID: 1677
		SHGDN_FORPARSING = 32768
	}
}
