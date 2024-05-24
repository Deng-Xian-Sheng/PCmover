using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200099A RID: 2458
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.ELEMDESC instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ELEMDESC
	{
		// Token: 0x04002C4A RID: 11338
		public TYPEDESC tdesc;

		// Token: 0x04002C4B RID: 11339
		public ELEMDESC.DESCUNION desc;

		// Token: 0x02000C98 RID: 3224
		[ComVisible(false)]
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct DESCUNION
		{
			// Token: 0x04003852 RID: 14418
			[FieldOffset(0)]
			public IDLDESC idldesc;

			// Token: 0x04003853 RID: 14419
			[FieldOffset(0)]
			public PARAMDESC paramdesc;
		}
	}
}
