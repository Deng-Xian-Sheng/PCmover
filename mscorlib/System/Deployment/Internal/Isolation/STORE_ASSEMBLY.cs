using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000676 RID: 1654
	internal struct STORE_ASSEMBLY
	{
		// Token: 0x040021E1 RID: 8673
		public uint Status;

		// Token: 0x040021E2 RID: 8674
		public IDefinitionIdentity DefinitionIdentity;

		// Token: 0x040021E3 RID: 8675
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ManifestPath;

		// Token: 0x040021E4 RID: 8676
		public ulong AssemblySize;

		// Token: 0x040021E5 RID: 8677
		public ulong ChangeId;
	}
}
