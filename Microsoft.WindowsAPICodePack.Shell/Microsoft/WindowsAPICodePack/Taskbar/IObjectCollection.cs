using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x020000A8 RID: 168
	[Guid("5632B1A4-E38A-400A-928A-D4CD63230295")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IObjectCollection
	{
		// Token: 0x0600056D RID: 1389
		[PreserveSig]
		void GetCount(out uint cObjects);

		// Token: 0x0600056E RID: 1390
		[PreserveSig]
		void GetAt(uint iIndex, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvObject);

		// Token: 0x0600056F RID: 1391
		void AddObject([MarshalAs(UnmanagedType.Interface)] object pvObject);

		// Token: 0x06000570 RID: 1392
		void AddFromArray([MarshalAs(UnmanagedType.Interface)] IObjectArray poaSource);

		// Token: 0x06000571 RID: 1393
		void RemoveObject(uint uiIndex);

		// Token: 0x06000572 RID: 1394
		void Clear();
	}
}
