using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006A3 RID: 1699
	internal struct StoreOperationUnpinDeployment
	{
		// Token: 0x06004FC9 RID: 20425 RVA: 0x0011C868 File Offset: 0x0011AA68
		[SecuritySafeCritical]
		public StoreOperationUnpinDeployment(IDefinitionAppId app, StoreApplicationReference reference)
		{
			this.Size = (uint)Marshal.SizeOf(typeof(StoreOperationUnpinDeployment));
			this.Flags = StoreOperationUnpinDeployment.OpFlags.Nothing;
			this.Application = app;
			this.Reference = reference.ToIntPtr();
		}

		// Token: 0x06004FCA RID: 20426 RVA: 0x0011C89A File Offset: 0x0011AA9A
		[SecurityCritical]
		public void Destroy()
		{
			StoreApplicationReference.Destroy(this.Reference);
		}

		// Token: 0x04002231 RID: 8753
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x04002232 RID: 8754
		[MarshalAs(UnmanagedType.U4)]
		public StoreOperationUnpinDeployment.OpFlags Flags;

		// Token: 0x04002233 RID: 8755
		[MarshalAs(UnmanagedType.Interface)]
		public IDefinitionAppId Application;

		// Token: 0x04002234 RID: 8756
		public IntPtr Reference;

		// Token: 0x02000C49 RID: 3145
		[Flags]
		public enum OpFlags
		{
			// Token: 0x0400376E RID: 14190
			Nothing = 0
		}

		// Token: 0x02000C4A RID: 3146
		public enum Disposition
		{
			// Token: 0x04003770 RID: 14192
			Failed,
			// Token: 0x04003771 RID: 14193
			Unpinned
		}
	}
}
