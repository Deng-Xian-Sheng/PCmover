using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000AE RID: 174
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("12337d35-94c6-48a0-bce7-6a9c69d4d600")]
	[ComImport]
	internal interface IApplicationDestinations
	{
		// Token: 0x060002EC RID: 748
		void SetAppID([MarshalAs(UnmanagedType.LPWStr)] [In] string pszAppID);

		// Token: 0x060002ED RID: 749
		void RemoveDestination([MarshalAs(UnmanagedType.IUnknown)] object punk);

		// Token: 0x060002EE RID: 750
		void RemoveAllDestinations();
	}
}
