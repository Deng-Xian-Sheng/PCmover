using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000974 RID: 2420
	[Flags]
	public enum RegistrationConnectionType
	{
		// Token: 0x04002BC7 RID: 11207
		SingleUse = 0,
		// Token: 0x04002BC8 RID: 11208
		MultipleUse = 1,
		// Token: 0x04002BC9 RID: 11209
		MultiSeparate = 2,
		// Token: 0x04002BCA RID: 11210
		Suspended = 4,
		// Token: 0x04002BCB RID: 11211
		Surrogate = 8
	}
}
