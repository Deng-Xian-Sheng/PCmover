using System;

namespace System.Runtime.Versioning
{
	// Token: 0x02000721 RID: 1825
	[Flags]
	internal enum SxSRequirements
	{
		// Token: 0x04002414 RID: 9236
		None = 0,
		// Token: 0x04002415 RID: 9237
		AppDomainID = 1,
		// Token: 0x04002416 RID: 9238
		ProcessID = 2,
		// Token: 0x04002417 RID: 9239
		CLRInstanceID = 4,
		// Token: 0x04002418 RID: 9240
		AssemblyName = 8,
		// Token: 0x04002419 RID: 9241
		TypeName = 16
	}
}
