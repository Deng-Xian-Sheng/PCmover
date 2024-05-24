using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000067 RID: 103
	public enum RedirectionCapability
	{
		// Token: 0x0400023C RID: 572
		None,
		// Token: 0x0400023D RID: 573
		AllowAll = 255,
		// Token: 0x0400023E RID: 574
		Redirectable = 1,
		// Token: 0x0400023F RID: 575
		DenyAll = 1048320,
		// Token: 0x04000240 RID: 576
		DenyPolicyRedirected = 256,
		// Token: 0x04000241 RID: 577
		DenyPolicy = 512,
		// Token: 0x04000242 RID: 578
		DenyPermissions = 1024
	}
}
