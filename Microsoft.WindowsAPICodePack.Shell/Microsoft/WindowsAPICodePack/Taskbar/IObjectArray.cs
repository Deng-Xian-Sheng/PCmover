using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x020000A7 RID: 167
	[Guid("92CA9DCD-5622-4BBA-A805-5E9F541BD8C9")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IObjectArray
	{
		// Token: 0x0600056B RID: 1387
		void GetCount(out uint cObjects);

		// Token: 0x0600056C RID: 1388
		void GetAt(uint iIndex, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvObject);
	}
}
