using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ControlzEx.Standard
{
	// Token: 0x02000085 RID: 133
	[Guid("4657278B-411B-11D2-839A-00C04FD918D0")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IDropTargetHelper
	{
		// Token: 0x060001C6 RID: 454
		void DragEnter(IntPtr hwndTarget, IDataObject pDataObject, ref POINT ppt, int effect);

		// Token: 0x060001C7 RID: 455
		void DragLeave();

		// Token: 0x060001C8 RID: 456
		void DragOver(ref POINT ppt, int effect);

		// Token: 0x060001C9 RID: 457
		void Drop(IDataObject dataObject, ref POINT ppt, int effect);

		// Token: 0x060001CA RID: 458
		void Show([MarshalAs(UnmanagedType.Bool)] bool fShow);
	}
}
