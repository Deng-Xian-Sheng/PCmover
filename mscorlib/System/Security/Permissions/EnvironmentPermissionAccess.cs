using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002DB RID: 731
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum EnvironmentPermissionAccess
	{
		// Token: 0x04000E68 RID: 3688
		NoAccess = 0,
		// Token: 0x04000E69 RID: 3689
		Read = 1,
		// Token: 0x04000E6A RID: 3690
		Write = 2,
		// Token: 0x04000E6B RID: 3691
		AllAccess = 3
	}
}
