using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006AF RID: 1711
	internal struct IStore_BindingResult
	{
		// Token: 0x04002265 RID: 8805
		[MarshalAs(UnmanagedType.U4)]
		public uint Flags;

		// Token: 0x04002266 RID: 8806
		[MarshalAs(UnmanagedType.U4)]
		public uint Disposition;

		// Token: 0x04002267 RID: 8807
		public IStore_BindingResult_BoundVersion Component;

		// Token: 0x04002268 RID: 8808
		public Guid CacheCoherencyGuid;

		// Token: 0x04002269 RID: 8809
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr Reserved;
	}
}
