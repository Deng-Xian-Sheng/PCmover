using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002DE RID: 734
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum FileDialogPermissionAccess
	{
		// Token: 0x04000E70 RID: 3696
		None = 0,
		// Token: 0x04000E71 RID: 3697
		Open = 1,
		// Token: 0x04000E72 RID: 3698
		Save = 2,
		// Token: 0x04000E73 RID: 3699
		OpenSave = 3
	}
}
