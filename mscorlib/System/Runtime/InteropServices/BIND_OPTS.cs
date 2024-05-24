using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000979 RID: 2425
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.BIND_OPTS instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	public struct BIND_OPTS
	{
		// Token: 0x04002BDA RID: 11226
		public int cbStruct;

		// Token: 0x04002BDB RID: 11227
		public int grfFlags;

		// Token: 0x04002BDC RID: 11228
		public int grfMode;

		// Token: 0x04002BDD RID: 11229
		public int dwTickCountDeadline;
	}
}
