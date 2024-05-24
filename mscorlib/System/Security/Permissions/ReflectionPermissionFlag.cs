using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x02000301 RID: 769
	[ComVisible(true)]
	[Flags]
	[Serializable]
	public enum ReflectionPermissionFlag
	{
		// Token: 0x04000F0F RID: 3855
		NoFlags = 0,
		// Token: 0x04000F10 RID: 3856
		[Obsolete("This API has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		TypeInformation = 1,
		// Token: 0x04000F11 RID: 3857
		MemberAccess = 2,
		// Token: 0x04000F12 RID: 3858
		[Obsolete("This permission is no longer used by the CLR.")]
		ReflectionEmit = 4,
		// Token: 0x04000F13 RID: 3859
		[ComVisible(false)]
		RestrictedMemberAccess = 8,
		// Token: 0x04000F14 RID: 3860
		[Obsolete("This permission has been deprecated. Use PermissionState.Unrestricted to get full access.")]
		AllFlags = 7
	}
}
