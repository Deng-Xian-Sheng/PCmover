using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000B1 RID: 177
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("36db0196-9665-46d1-9ba7-d3709eecf9ed")]
	[ComImport]
	internal interface IObjectWithAppUserModelId
	{
		// Token: 0x060002FA RID: 762
		void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

		// Token: 0x060002FB RID: 763
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetAppID();
	}
}
