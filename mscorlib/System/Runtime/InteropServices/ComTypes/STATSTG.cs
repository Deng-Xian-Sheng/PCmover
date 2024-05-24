using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A34 RID: 2612
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct STATSTG
	{
		// Token: 0x04002D46 RID: 11590
		[__DynamicallyInvokable]
		public string pwcsName;

		// Token: 0x04002D47 RID: 11591
		[__DynamicallyInvokable]
		public int type;

		// Token: 0x04002D48 RID: 11592
		[__DynamicallyInvokable]
		public long cbSize;

		// Token: 0x04002D49 RID: 11593
		[__DynamicallyInvokable]
		public FILETIME mtime;

		// Token: 0x04002D4A RID: 11594
		[__DynamicallyInvokable]
		public FILETIME ctime;

		// Token: 0x04002D4B RID: 11595
		[__DynamicallyInvokable]
		public FILETIME atime;

		// Token: 0x04002D4C RID: 11596
		[__DynamicallyInvokable]
		public int grfMode;

		// Token: 0x04002D4D RID: 11597
		[__DynamicallyInvokable]
		public int grfLocksSupported;

		// Token: 0x04002D4E RID: 11598
		[__DynamicallyInvokable]
		public Guid clsid;

		// Token: 0x04002D4F RID: 11599
		[__DynamicallyInvokable]
		public int grfStateBits;

		// Token: 0x04002D50 RID: 11600
		[__DynamicallyInvokable]
		public int reserved;
	}
}
