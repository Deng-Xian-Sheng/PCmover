using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006A4 RID: 1700
	internal struct StoreOperationInstallDeployment
	{
		// Token: 0x06004FCB RID: 20427 RVA: 0x0011C8A7 File Offset: 0x0011AAA7
		public StoreOperationInstallDeployment(IDefinitionAppId App, StoreApplicationReference reference)
		{
			this = new StoreOperationInstallDeployment(App, true, reference);
		}

		// Token: 0x06004FCC RID: 20428 RVA: 0x0011C8B4 File Offset: 0x0011AAB4
		[SecuritySafeCritical]
		public StoreOperationInstallDeployment(IDefinitionAppId App, bool UninstallOthers, StoreApplicationReference reference)
		{
			this.Size = (uint)Marshal.SizeOf(typeof(StoreOperationInstallDeployment));
			this.Flags = StoreOperationInstallDeployment.OpFlags.Nothing;
			this.Application = App;
			if (UninstallOthers)
			{
				this.Flags |= StoreOperationInstallDeployment.OpFlags.UninstallOthers;
			}
			this.Reference = reference.ToIntPtr();
		}

		// Token: 0x06004FCD RID: 20429 RVA: 0x0011C902 File Offset: 0x0011AB02
		[SecurityCritical]
		public void Destroy()
		{
			StoreApplicationReference.Destroy(this.Reference);
		}

		// Token: 0x04002235 RID: 8757
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x04002236 RID: 8758
		[MarshalAs(UnmanagedType.U4)]
		public StoreOperationInstallDeployment.OpFlags Flags;

		// Token: 0x04002237 RID: 8759
		[MarshalAs(UnmanagedType.Interface)]
		public IDefinitionAppId Application;

		// Token: 0x04002238 RID: 8760
		public IntPtr Reference;

		// Token: 0x02000C4B RID: 3147
		[Flags]
		public enum OpFlags
		{
			// Token: 0x04003773 RID: 14195
			Nothing = 0,
			// Token: 0x04003774 RID: 14196
			UninstallOthers = 1
		}

		// Token: 0x02000C4C RID: 3148
		public enum Disposition
		{
			// Token: 0x04003776 RID: 14198
			Failed,
			// Token: 0x04003777 RID: 14199
			AlreadyInstalled,
			// Token: 0x04003778 RID: 14200
			Installed
		}
	}
}
