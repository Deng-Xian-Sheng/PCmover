using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x02000313 RID: 787
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum KeyContainerPermissionFlags
	{
		// Token: 0x04000F57 RID: 3927
		NoFlags = 0,
		// Token: 0x04000F58 RID: 3928
		Create = 1,
		// Token: 0x04000F59 RID: 3929
		Open = 2,
		// Token: 0x04000F5A RID: 3930
		Delete = 4,
		// Token: 0x04000F5B RID: 3931
		Import = 16,
		// Token: 0x04000F5C RID: 3932
		Export = 32,
		// Token: 0x04000F5D RID: 3933
		Sign = 256,
		// Token: 0x04000F5E RID: 3934
		Decrypt = 512,
		// Token: 0x04000F5F RID: 3935
		ViewAcl = 4096,
		// Token: 0x04000F60 RID: 3936
		ChangeAcl = 8192,
		// Token: 0x04000F61 RID: 3937
		AllFlags = 13111
	}
}
