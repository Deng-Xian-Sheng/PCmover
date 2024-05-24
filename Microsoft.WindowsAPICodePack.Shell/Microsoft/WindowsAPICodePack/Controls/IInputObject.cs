using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x0200005C RID: 92
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("68284fAA-6A48-11D0-8c78-00C04fd918b4")]
	[ComImport]
	internal interface IInputObject
	{
		// Token: 0x060002F1 RID: 753
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult UIActivateIO(bool fActivate, ref Message pMsg);

		// Token: 0x060002F2 RID: 754
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult HasFocusIO();

		// Token: 0x060002F3 RID: 755
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult TranslateAcceleratorIO(ref Message pMsg);
	}
}
