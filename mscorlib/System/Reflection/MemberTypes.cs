using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x02000602 RID: 1538
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum MemberTypes
	{
		// Token: 0x04001D57 RID: 7511
		Constructor = 1,
		// Token: 0x04001D58 RID: 7512
		Event = 2,
		// Token: 0x04001D59 RID: 7513
		Field = 4,
		// Token: 0x04001D5A RID: 7514
		Method = 8,
		// Token: 0x04001D5B RID: 7515
		Property = 16,
		// Token: 0x04001D5C RID: 7516
		TypeInfo = 32,
		// Token: 0x04001D5D RID: 7517
		Custom = 64,
		// Token: 0x04001D5E RID: 7518
		NestedType = 128,
		// Token: 0x04001D5F RID: 7519
		All = 191
	}
}
