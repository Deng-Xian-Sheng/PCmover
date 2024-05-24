using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x0200069F RID: 1695
	internal struct StoreOperationStageComponent
	{
		// Token: 0x06004FBD RID: 20413 RVA: 0x0011C6FC File Offset: 0x0011A8FC
		public void Destroy()
		{
		}

		// Token: 0x06004FBE RID: 20414 RVA: 0x0011C6FE File Offset: 0x0011A8FE
		public StoreOperationStageComponent(IDefinitionAppId app, string Manifest)
		{
			this = new StoreOperationStageComponent(app, null, Manifest);
		}

		// Token: 0x06004FBF RID: 20415 RVA: 0x0011C709 File Offset: 0x0011A909
		public StoreOperationStageComponent(IDefinitionAppId app, IDefinitionIdentity comp, string Manifest)
		{
			this.Size = (uint)Marshal.SizeOf(typeof(StoreOperationStageComponent));
			this.Flags = StoreOperationStageComponent.OpFlags.Nothing;
			this.Application = app;
			this.Component = comp;
			this.ManifestPath = Manifest;
		}

		// Token: 0x0400221C RID: 8732
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x0400221D RID: 8733
		[MarshalAs(UnmanagedType.U4)]
		public StoreOperationStageComponent.OpFlags Flags;

		// Token: 0x0400221E RID: 8734
		[MarshalAs(UnmanagedType.Interface)]
		public IDefinitionAppId Application;

		// Token: 0x0400221F RID: 8735
		[MarshalAs(UnmanagedType.Interface)]
		public IDefinitionIdentity Component;

		// Token: 0x04002220 RID: 8736
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ManifestPath;

		// Token: 0x02000C42 RID: 3138
		[Flags]
		public enum OpFlags
		{
			// Token: 0x04003758 RID: 14168
			Nothing = 0
		}

		// Token: 0x02000C43 RID: 3139
		public enum Disposition
		{
			// Token: 0x0400375A RID: 14170
			Failed,
			// Token: 0x0400375B RID: 14171
			Installed,
			// Token: 0x0400375C RID: 14172
			Refreshed,
			// Token: 0x0400375D RID: 14173
			AlreadyInstalled
		}
	}
}
