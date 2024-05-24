using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200096B RID: 2411
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum TypeLibExporterFlags
	{
		// Token: 0x04002BA5 RID: 11173
		None = 0,
		// Token: 0x04002BA6 RID: 11174
		OnlyReferenceRegistered = 1,
		// Token: 0x04002BA7 RID: 11175
		CallerResolvedReferences = 2,
		// Token: 0x04002BA8 RID: 11176
		OldNames = 4,
		// Token: 0x04002BA9 RID: 11177
		ExportAs32Bit = 16,
		// Token: 0x04002BAA RID: 11178
		ExportAs64Bit = 32
	}
}
