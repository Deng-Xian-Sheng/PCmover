using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000AC RID: 172
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("56FDF342-FD6D-11d0-958A-006097C9A090")]
	[ComImport]
	internal interface ITaskbarList
	{
		// Token: 0x060002E1 RID: 737
		void HrInit();

		// Token: 0x060002E2 RID: 738
		void AddTab(IntPtr hwnd);

		// Token: 0x060002E3 RID: 739
		void DeleteTab(IntPtr hwnd);

		// Token: 0x060002E4 RID: 740
		void ActivateTab(IntPtr hwnd);

		// Token: 0x060002E5 RID: 741
		void SetActiveAlt(IntPtr hwnd);
	}
}
