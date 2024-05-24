using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006AE RID: 1710
	internal struct IStore_BindingResult_BoundVersion
	{
		// Token: 0x04002261 RID: 8801
		[MarshalAs(UnmanagedType.U2)]
		public ushort Revision;

		// Token: 0x04002262 RID: 8802
		[MarshalAs(UnmanagedType.U2)]
		public ushort Build;

		// Token: 0x04002263 RID: 8803
		[MarshalAs(UnmanagedType.U2)]
		public ushort Minor;

		// Token: 0x04002264 RID: 8804
		[MarshalAs(UnmanagedType.U2)]
		public ushort Major;
	}
}
