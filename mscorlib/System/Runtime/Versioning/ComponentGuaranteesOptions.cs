using System;

namespace System.Runtime.Versioning
{
	// Token: 0x0200071C RID: 1820
	[Flags]
	[Serializable]
	public enum ComponentGuaranteesOptions
	{
		// Token: 0x04002403 RID: 9219
		None = 0,
		// Token: 0x04002404 RID: 9220
		Exchange = 1,
		// Token: 0x04002405 RID: 9221
		Stable = 2,
		// Token: 0x04002406 RID: 9222
		SideBySide = 4
	}
}
