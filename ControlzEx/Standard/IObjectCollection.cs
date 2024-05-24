using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000A5 RID: 165
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("92CA9DCD-5622-4bba-A805-5E9F541BD8C9")]
	[ComImport]
	internal interface IObjectCollection : IObjectArray
	{
		// Token: 0x0600029C RID: 668
		uint GetCount();

		// Token: 0x0600029D RID: 669
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetAt([In] uint uiIndex, [In] ref Guid riid);

		// Token: 0x0600029E RID: 670
		void AddObject([MarshalAs(UnmanagedType.IUnknown)] object punk);

		// Token: 0x0600029F RID: 671
		void AddFromArray(IObjectArray poaSource);

		// Token: 0x060002A0 RID: 672
		void RemoveObjectAt(uint uiIndex);

		// Token: 0x060002A1 RID: 673
		void Clear();
	}
}
