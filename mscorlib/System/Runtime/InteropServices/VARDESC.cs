using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200099B RID: 2459
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.VARDESC instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VARDESC
	{
		// Token: 0x04002C4C RID: 11340
		public int memid;

		// Token: 0x04002C4D RID: 11341
		public string lpstrSchema;

		// Token: 0x04002C4E RID: 11342
		public ELEMDESC elemdescVar;

		// Token: 0x04002C4F RID: 11343
		public short wVarFlags;

		// Token: 0x04002C50 RID: 11344
		public VarEnum varkind;

		// Token: 0x02000C99 RID: 3225
		[ComVisible(false)]
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct DESCUNION
		{
			// Token: 0x04003854 RID: 14420
			[FieldOffset(0)]
			public int oInst;

			// Token: 0x04003855 RID: 14421
			[FieldOffset(0)]
			public IntPtr lpvarValue;
		}
	}
}
