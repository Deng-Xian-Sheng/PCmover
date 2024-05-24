using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x02000708 RID: 1800
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("CFA3F59F-334D-46bf-A5A5-5D11BB2D7EBC")]
	[ComImport]
	internal interface IDeploymentMetadataEntry
	{
		// Token: 0x17000D2F RID: 3375
		// (get) Token: 0x060050E2 RID: 20706
		DeploymentMetadataEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000D30 RID: 3376
		// (get) Token: 0x060050E3 RID: 20707
		string DeploymentProviderCodebase { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D31 RID: 3377
		// (get) Token: 0x060050E4 RID: 20708
		string MinimumRequiredVersion { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D32 RID: 3378
		// (get) Token: 0x060050E5 RID: 20709
		ushort MaximumAge { [SecurityCritical] get; }

		// Token: 0x17000D33 RID: 3379
		// (get) Token: 0x060050E6 RID: 20710
		byte MaximumAge_Unit { [SecurityCritical] get; }

		// Token: 0x17000D34 RID: 3380
		// (get) Token: 0x060050E7 RID: 20711
		uint DeploymentFlags { [SecurityCritical] get; }
	}
}
