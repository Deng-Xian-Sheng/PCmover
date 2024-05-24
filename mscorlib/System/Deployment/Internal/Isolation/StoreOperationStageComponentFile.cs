using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006A0 RID: 1696
	internal struct StoreOperationStageComponentFile
	{
		// Token: 0x06004FC0 RID: 20416 RVA: 0x0011C73C File Offset: 0x0011A93C
		public StoreOperationStageComponentFile(IDefinitionAppId App, string CompRelPath, string SrcFile)
		{
			this = new StoreOperationStageComponentFile(App, null, CompRelPath, SrcFile);
		}

		// Token: 0x06004FC1 RID: 20417 RVA: 0x0011C748 File Offset: 0x0011A948
		public StoreOperationStageComponentFile(IDefinitionAppId App, IDefinitionIdentity Component, string CompRelPath, string SrcFile)
		{
			this.Size = (uint)Marshal.SizeOf(typeof(StoreOperationStageComponentFile));
			this.Flags = StoreOperationStageComponentFile.OpFlags.Nothing;
			this.Application = App;
			this.Component = Component;
			this.ComponentRelativePath = CompRelPath;
			this.SourceFilePath = SrcFile;
		}

		// Token: 0x06004FC2 RID: 20418 RVA: 0x0011C783 File Offset: 0x0011A983
		public void Destroy()
		{
		}

		// Token: 0x04002221 RID: 8737
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x04002222 RID: 8738
		[MarshalAs(UnmanagedType.U4)]
		public StoreOperationStageComponentFile.OpFlags Flags;

		// Token: 0x04002223 RID: 8739
		[MarshalAs(UnmanagedType.Interface)]
		public IDefinitionAppId Application;

		// Token: 0x04002224 RID: 8740
		[MarshalAs(UnmanagedType.Interface)]
		public IDefinitionIdentity Component;

		// Token: 0x04002225 RID: 8741
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ComponentRelativePath;

		// Token: 0x04002226 RID: 8742
		[MarshalAs(UnmanagedType.LPWStr)]
		public string SourceFilePath;

		// Token: 0x02000C44 RID: 3140
		[Flags]
		public enum OpFlags
		{
			// Token: 0x0400375F RID: 14175
			Nothing = 0
		}

		// Token: 0x02000C45 RID: 3141
		public enum Disposition
		{
			// Token: 0x04003761 RID: 14177
			Failed,
			// Token: 0x04003762 RID: 14178
			Installed,
			// Token: 0x04003763 RID: 14179
			Refreshed,
			// Token: 0x04003764 RID: 14180
			AlreadyInstalled
		}
	}
}
