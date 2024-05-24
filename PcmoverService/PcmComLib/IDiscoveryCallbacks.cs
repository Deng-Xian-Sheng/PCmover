using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000064 RID: 100
	[CompilerGenerated]
	[Guid("B0EAF05A-BF5E-4117-800D-BE531C84FFE1")]
	[TypeIdentifier]
	[ComImport]
	public interface IDiscoveryCallbacks
	{
		// Token: 0x060002F9 RID: 761
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnMachineFound([MarshalAs(UnmanagedType.Interface)] [In] RemoteMachine pMachine);

		// Token: 0x060002FA RID: 762
		[DispId(2)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnMachineLost([MarshalAs(UnmanagedType.Interface)] [In] RemoteMachine pMachine);

		// Token: 0x060002FB RID: 763
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnUSBStateChanged(USB_STATE newState);
	}
}
