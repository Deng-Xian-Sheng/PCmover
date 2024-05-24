using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000043 RID: 67
	[CompilerGenerated]
	[TypeIdentifier("014D1DE2-7A0B-457C-8B9C-A20AD2BF0977", "PcmComLib.CONNECTION_POLICY_METHODS")]
	public enum CONNECTION_POLICY_METHODS
	{
		// Token: 0x040000F0 RID: 240
		CPM_NONE,
		// Token: 0x040000F1 RID: 241
		CPM_NETWORK,
		// Token: 0x040000F2 RID: 242
		CPM_UDP,
		// Token: 0x040000F3 RID: 243
		CPM_TCP_OR_UDP,
		// Token: 0x040000F4 RID: 244
		CPM_USB,
		// Token: 0x040000F5 RID: 245
		CPM_FILE = 8,
		// Token: 0x040000F6 RID: 246
		CPM_IMAGE = 16,
		// Token: 0x040000F7 RID: 247
		CPM_SELF = 32,
		// Token: 0x040000F8 RID: 248
		CPM_ALL = 63,
		// Token: 0x040000F9 RID: 249
		CPM_DEFAULT = 63
	}
}
