using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000678 RID: 1656
	internal struct STORE_ASSEMBLY_FILE
	{
		// Token: 0x040021E8 RID: 8680
		public uint Size;

		// Token: 0x040021E9 RID: 8681
		public uint Flags;

		// Token: 0x040021EA RID: 8682
		[MarshalAs(UnmanagedType.LPWStr)]
		public string FileName;

		// Token: 0x040021EB RID: 8683
		public uint FileStatusFlags;
	}
}
