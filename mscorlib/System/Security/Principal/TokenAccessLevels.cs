using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	// Token: 0x02000326 RID: 806
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum TokenAccessLevels
	{
		// Token: 0x0400100C RID: 4108
		AssignPrimary = 1,
		// Token: 0x0400100D RID: 4109
		Duplicate = 2,
		// Token: 0x0400100E RID: 4110
		Impersonate = 4,
		// Token: 0x0400100F RID: 4111
		Query = 8,
		// Token: 0x04001010 RID: 4112
		QuerySource = 16,
		// Token: 0x04001011 RID: 4113
		AdjustPrivileges = 32,
		// Token: 0x04001012 RID: 4114
		AdjustGroups = 64,
		// Token: 0x04001013 RID: 4115
		AdjustDefault = 128,
		// Token: 0x04001014 RID: 4116
		AdjustSessionId = 256,
		// Token: 0x04001015 RID: 4117
		Read = 131080,
		// Token: 0x04001016 RID: 4118
		Write = 131296,
		// Token: 0x04001017 RID: 4119
		AllAccess = 983551,
		// Token: 0x04001018 RID: 4120
		MaximumAllowed = 33554432
	}
}
