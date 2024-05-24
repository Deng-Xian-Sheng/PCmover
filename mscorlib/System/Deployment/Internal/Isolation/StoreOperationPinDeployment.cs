using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006A2 RID: 1698
	internal struct StoreOperationPinDeployment
	{
		// Token: 0x06004FC6 RID: 20422 RVA: 0x0011C809 File Offset: 0x0011AA09
		[SecuritySafeCritical]
		public StoreOperationPinDeployment(IDefinitionAppId AppId, StoreApplicationReference Ref)
		{
			this.Size = (uint)Marshal.SizeOf(typeof(StoreOperationPinDeployment));
			this.Flags = StoreOperationPinDeployment.OpFlags.NeverExpires;
			this.Application = AppId;
			this.Reference = Ref.ToIntPtr();
			this.ExpirationTime = 0L;
		}

		// Token: 0x06004FC7 RID: 20423 RVA: 0x0011C843 File Offset: 0x0011AA43
		public StoreOperationPinDeployment(IDefinitionAppId AppId, DateTime Expiry, StoreApplicationReference Ref)
		{
			this = new StoreOperationPinDeployment(AppId, Ref);
			this.Flags |= StoreOperationPinDeployment.OpFlags.NeverExpires;
		}

		// Token: 0x06004FC8 RID: 20424 RVA: 0x0011C85B File Offset: 0x0011AA5B
		[SecurityCritical]
		public void Destroy()
		{
			StoreApplicationReference.Destroy(this.Reference);
		}

		// Token: 0x0400222C RID: 8748
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x0400222D RID: 8749
		[MarshalAs(UnmanagedType.U4)]
		public StoreOperationPinDeployment.OpFlags Flags;

		// Token: 0x0400222E RID: 8750
		[MarshalAs(UnmanagedType.Interface)]
		public IDefinitionAppId Application;

		// Token: 0x0400222F RID: 8751
		[MarshalAs(UnmanagedType.I8)]
		public long ExpirationTime;

		// Token: 0x04002230 RID: 8752
		public IntPtr Reference;

		// Token: 0x02000C47 RID: 3143
		[Flags]
		public enum OpFlags
		{
			// Token: 0x04003768 RID: 14184
			Nothing = 0,
			// Token: 0x04003769 RID: 14185
			NeverExpires = 1
		}

		// Token: 0x02000C48 RID: 3144
		public enum Disposition
		{
			// Token: 0x0400376B RID: 14187
			Failed,
			// Token: 0x0400376C RID: 14188
			Pinned
		}
	}
}
