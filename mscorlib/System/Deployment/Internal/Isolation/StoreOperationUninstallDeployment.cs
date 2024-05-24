using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006A5 RID: 1701
	internal struct StoreOperationUninstallDeployment
	{
		// Token: 0x06004FCE RID: 20430 RVA: 0x0011C90F File Offset: 0x0011AB0F
		[SecuritySafeCritical]
		public StoreOperationUninstallDeployment(IDefinitionAppId appid, StoreApplicationReference AppRef)
		{
			this.Size = (uint)Marshal.SizeOf(typeof(StoreOperationUninstallDeployment));
			this.Flags = StoreOperationUninstallDeployment.OpFlags.Nothing;
			this.Application = appid;
			this.Reference = AppRef.ToIntPtr();
		}

		// Token: 0x06004FCF RID: 20431 RVA: 0x0011C941 File Offset: 0x0011AB41
		[SecurityCritical]
		public void Destroy()
		{
			StoreApplicationReference.Destroy(this.Reference);
		}

		// Token: 0x04002239 RID: 8761
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x0400223A RID: 8762
		[MarshalAs(UnmanagedType.U4)]
		public StoreOperationUninstallDeployment.OpFlags Flags;

		// Token: 0x0400223B RID: 8763
		[MarshalAs(UnmanagedType.Interface)]
		public IDefinitionAppId Application;

		// Token: 0x0400223C RID: 8764
		public IntPtr Reference;

		// Token: 0x02000C4D RID: 3149
		[Flags]
		public enum OpFlags
		{
			// Token: 0x0400377A RID: 14202
			Nothing = 0
		}

		// Token: 0x02000C4E RID: 3150
		public enum Disposition
		{
			// Token: 0x0400377C RID: 14204
			Failed,
			// Token: 0x0400377D RID: 14205
			DidNotExist,
			// Token: 0x0400377E RID: 14206
			Uninstalled
		}
	}
}
