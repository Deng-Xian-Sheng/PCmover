using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006B7 RID: 1719
	[Guid("07662534-750b-4ed5-9cfb-1c5bc5acfd07")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IStateManager
	{
		// Token: 0x06005036 RID: 20534
		[SecurityCritical]
		void PrepareApplicationState([In] UIntPtr Inputs, ref UIntPtr Outputs);

		// Token: 0x06005037 RID: 20535
		[SecurityCritical]
		void SetApplicationRunningState([In] uint Flags, [In] IActContext Context, [In] uint RunningState, out uint Disposition);

		// Token: 0x06005038 RID: 20536
		[SecurityCritical]
		void GetApplicationStateFilesystemLocation([In] uint Flags, [In] IDefinitionAppId Appidentity, [In] IDefinitionIdentity ComponentIdentity, [In] UIntPtr Coordinates, [MarshalAs(UnmanagedType.LPWStr)] out string Path);

		// Token: 0x06005039 RID: 20537
		[SecurityCritical]
		void Scavenge([In] uint Flags, out uint Disposition);
	}
}
