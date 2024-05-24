using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006F3 RID: 1779
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("FD47B733-AFBC-45e4-B7C2-BBEB1D9F766C")]
	[ComImport]
	internal interface IAssemblyReferenceEntry
	{
		// Token: 0x17000D11 RID: 3345
		// (get) Token: 0x060050BD RID: 20669
		AssemblyReferenceEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000D12 RID: 3346
		// (get) Token: 0x060050BE RID: 20670
		IReferenceIdentity ReferenceIdentity { [SecurityCritical] get; }

		// Token: 0x17000D13 RID: 3347
		// (get) Token: 0x060050BF RID: 20671
		uint Flags { [SecurityCritical] get; }

		// Token: 0x17000D14 RID: 3348
		// (get) Token: 0x060050C0 RID: 20672
		IAssemblyReferenceDependentAssemblyEntry DependentAssembly { [SecurityCritical] get; }
	}
}
