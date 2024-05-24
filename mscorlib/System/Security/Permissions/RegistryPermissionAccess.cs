using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x02000319 RID: 793
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum RegistryPermissionAccess
	{
		// Token: 0x04000F71 RID: 3953
		NoAccess = 0,
		// Token: 0x04000F72 RID: 3954
		Read = 1,
		// Token: 0x04000F73 RID: 3955
		Write = 2,
		// Token: 0x04000F74 RID: 3956
		Create = 4,
		// Token: 0x04000F75 RID: 3957
		AllAccess = 7
	}
}
