using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x02000705 RID: 1797
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("CB73147E-5FC2-4c31-B4E6-58D13DBE1A08")]
	[ComImport]
	internal interface IDescriptionMetadataEntry
	{
		// Token: 0x17000D28 RID: 3368
		// (get) Token: 0x060050DA RID: 20698
		DescriptionMetadataEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000D29 RID: 3369
		// (get) Token: 0x060050DB RID: 20699
		string Publisher { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D2A RID: 3370
		// (get) Token: 0x060050DC RID: 20700
		string Product { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D2B RID: 3371
		// (get) Token: 0x060050DD RID: 20701
		string SupportUrl { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D2C RID: 3372
		// (get) Token: 0x060050DE RID: 20702
		string IconFile { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D2D RID: 3373
		// (get) Token: 0x060050DF RID: 20703
		string ErrorReportUrl { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D2E RID: 3374
		// (get) Token: 0x060050E0 RID: 20704
		string SuiteName { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }
	}
}
