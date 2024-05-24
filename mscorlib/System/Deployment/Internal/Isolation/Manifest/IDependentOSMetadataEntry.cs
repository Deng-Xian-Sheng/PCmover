using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x0200070B RID: 1803
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("CF168CF4-4E8F-4d92-9D2A-60E5CA21CF85")]
	[ComImport]
	internal interface IDependentOSMetadataEntry
	{
		// Token: 0x17000D35 RID: 3381
		// (get) Token: 0x060050E9 RID: 20713
		DependentOSMetadataEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000D36 RID: 3382
		// (get) Token: 0x060050EA RID: 20714
		string SupportUrl { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D37 RID: 3383
		// (get) Token: 0x060050EB RID: 20715
		string Description { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D38 RID: 3384
		// (get) Token: 0x060050EC RID: 20716
		ushort MajorVersion { [SecurityCritical] get; }

		// Token: 0x17000D39 RID: 3385
		// (get) Token: 0x060050ED RID: 20717
		ushort MinorVersion { [SecurityCritical] get; }

		// Token: 0x17000D3A RID: 3386
		// (get) Token: 0x060050EE RID: 20718
		ushort BuildNumber { [SecurityCritical] get; }

		// Token: 0x17000D3B RID: 3387
		// (get) Token: 0x060050EF RID: 20719
		byte ServicePackMajor { [SecurityCritical] get; }

		// Token: 0x17000D3C RID: 3388
		// (get) Token: 0x060050F0 RID: 20720
		byte ServicePackMinor { [SecurityCritical] get; }
	}
}
