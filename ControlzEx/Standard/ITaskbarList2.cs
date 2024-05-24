using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000AD RID: 173
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("602D4995-B13A-429b-A66E-1935E44F4317")]
	[ComImport]
	internal interface ITaskbarList2 : ITaskbarList
	{
		// Token: 0x060002E6 RID: 742
		void HrInit();

		// Token: 0x060002E7 RID: 743
		void AddTab(IntPtr hwnd);

		// Token: 0x060002E8 RID: 744
		void DeleteTab(IntPtr hwnd);

		// Token: 0x060002E9 RID: 745
		void ActivateTab(IntPtr hwnd);

		// Token: 0x060002EA RID: 746
		void SetActiveAlt(IntPtr hwnd);

		// Token: 0x060002EB RID: 747
		void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);
	}
}
