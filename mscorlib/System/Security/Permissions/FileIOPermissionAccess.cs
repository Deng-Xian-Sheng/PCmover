using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002E0 RID: 736
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum FileIOPermissionAccess
	{
		// Token: 0x04000E76 RID: 3702
		NoAccess = 0,
		// Token: 0x04000E77 RID: 3703
		Read = 1,
		// Token: 0x04000E78 RID: 3704
		Write = 2,
		// Token: 0x04000E79 RID: 3705
		Append = 4,
		// Token: 0x04000E7A RID: 3706
		PathDiscovery = 8,
		// Token: 0x04000E7B RID: 3707
		AllAccess = 15
	}
}
