using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006F0 RID: 1776
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("C31FF59E-CD25-47b8-9EF3-CF4433EB97CC")]
	[ComImport]
	internal interface IAssemblyReferenceDependentAssemblyEntry
	{
		// Token: 0x17000D06 RID: 3334
		// (get) Token: 0x060050B1 RID: 20657
		AssemblyReferenceDependentAssemblyEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000D07 RID: 3335
		// (get) Token: 0x060050B2 RID: 20658
		string Group { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D08 RID: 3336
		// (get) Token: 0x060050B3 RID: 20659
		string Codebase { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D09 RID: 3337
		// (get) Token: 0x060050B4 RID: 20660
		ulong Size { [SecurityCritical] get; }

		// Token: 0x17000D0A RID: 3338
		// (get) Token: 0x060050B5 RID: 20661
		object HashValue { [SecurityCritical] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000D0B RID: 3339
		// (get) Token: 0x060050B6 RID: 20662
		uint HashAlgorithm { [SecurityCritical] get; }

		// Token: 0x17000D0C RID: 3340
		// (get) Token: 0x060050B7 RID: 20663
		uint Flags { [SecurityCritical] get; }

		// Token: 0x17000D0D RID: 3341
		// (get) Token: 0x060050B8 RID: 20664
		string ResourceFallbackCulture { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D0E RID: 3342
		// (get) Token: 0x060050B9 RID: 20665
		string Description { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D0F RID: 3343
		// (get) Token: 0x060050BA RID: 20666
		string SupportUrl { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D10 RID: 3344
		// (get) Token: 0x060050BB RID: 20667
		ISection HashElements { [SecurityCritical] get; }
	}
}
