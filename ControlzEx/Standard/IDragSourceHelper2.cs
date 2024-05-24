using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ControlzEx.Standard
{
	// Token: 0x02000084 RID: 132
	[Guid("83E07D0D-0C5F-4163-BF1A-60B274051E40")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IDragSourceHelper2 : IDragSourceHelper
	{
		// Token: 0x060001C3 RID: 451
		void InitializeFromBitmap([In] ref SHDRAGIMAGE pshdi, [In] IDataObject pDataObject);

		// Token: 0x060001C4 RID: 452
		void InitializeFromWindow(IntPtr hwnd, [In] ref POINT ppt, [In] IDataObject pDataObject);

		// Token: 0x060001C5 RID: 453
		void SetFlags(DSH dwFlags);
	}
}
