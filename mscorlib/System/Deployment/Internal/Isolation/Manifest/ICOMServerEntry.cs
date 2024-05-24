using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006E7 RID: 1767
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("3903B11B-FBE8-477c-825F-DB828B5FD174")]
	[ComImport]
	internal interface ICOMServerEntry
	{
		// Token: 0x17000CF6 RID: 3318
		// (get) Token: 0x0600509B RID: 20635
		COMServerEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000CF7 RID: 3319
		// (get) Token: 0x0600509C RID: 20636
		Guid Clsid { [SecurityCritical] get; }

		// Token: 0x17000CF8 RID: 3320
		// (get) Token: 0x0600509D RID: 20637
		uint Flags { [SecurityCritical] get; }

		// Token: 0x17000CF9 RID: 3321
		// (get) Token: 0x0600509E RID: 20638
		Guid ConfiguredGuid { [SecurityCritical] get; }

		// Token: 0x17000CFA RID: 3322
		// (get) Token: 0x0600509F RID: 20639
		Guid ImplementedClsid { [SecurityCritical] get; }

		// Token: 0x17000CFB RID: 3323
		// (get) Token: 0x060050A0 RID: 20640
		Guid TypeLibrary { [SecurityCritical] get; }

		// Token: 0x17000CFC RID: 3324
		// (get) Token: 0x060050A1 RID: 20641
		uint ThreadingModel { [SecurityCritical] get; }

		// Token: 0x17000CFD RID: 3325
		// (get) Token: 0x060050A2 RID: 20642
		string RuntimeVersion { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000CFE RID: 3326
		// (get) Token: 0x060050A3 RID: 20643
		string HostFile { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }
	}
}
