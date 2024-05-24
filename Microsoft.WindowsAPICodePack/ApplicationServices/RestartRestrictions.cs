using System;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x02000007 RID: 7
	[Flags]
	public enum RestartRestrictions
	{
		// Token: 0x04000006 RID: 6
		None = 0,
		// Token: 0x04000007 RID: 7
		NotOnCrash = 1,
		// Token: 0x04000008 RID: 8
		NotOnHang = 2,
		// Token: 0x04000009 RID: 9
		NotOnPatch = 4,
		// Token: 0x0400000A RID: 10
		NotOnReboot = 8
	}
}
