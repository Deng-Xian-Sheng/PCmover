using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006A8 RID: 1704
	internal struct StoreOperationSetCanonicalizationContext
	{
		// Token: 0x06004FD7 RID: 20439 RVA: 0x0011CBBE File Offset: 0x0011ADBE
		[SecurityCritical]
		public StoreOperationSetCanonicalizationContext(string Bases, string Exports)
		{
			this.Size = (uint)Marshal.SizeOf(typeof(StoreOperationSetCanonicalizationContext));
			this.Flags = StoreOperationSetCanonicalizationContext.OpFlags.Nothing;
			this.BaseAddressFilePath = Bases;
			this.ExportsFilePath = Exports;
		}

		// Token: 0x06004FD8 RID: 20440 RVA: 0x0011CBEA File Offset: 0x0011ADEA
		public void Destroy()
		{
		}

		// Token: 0x04002249 RID: 8777
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x0400224A RID: 8778
		[MarshalAs(UnmanagedType.U4)]
		public StoreOperationSetCanonicalizationContext.OpFlags Flags;

		// Token: 0x0400224B RID: 8779
		[MarshalAs(UnmanagedType.LPWStr)]
		public string BaseAddressFilePath;

		// Token: 0x0400224C RID: 8780
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ExportsFilePath;

		// Token: 0x02000C51 RID: 3153
		[Flags]
		public enum OpFlags
		{
			// Token: 0x04003785 RID: 14213
			Nothing = 0
		}
	}
}
