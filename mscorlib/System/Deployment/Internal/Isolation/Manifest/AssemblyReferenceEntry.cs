using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006F1 RID: 1777
	[StructLayout(LayoutKind.Sequential)]
	internal class AssemblyReferenceEntry
	{
		// Token: 0x04002369 RID: 9065
		public IReferenceIdentity ReferenceIdentity;

		// Token: 0x0400236A RID: 9066
		public uint Flags;

		// Token: 0x0400236B RID: 9067
		public AssemblyReferenceDependentAssemblyEntry DependentAssembly;
	}
}
