using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200097C RID: 2428
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IConnectionPoint instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("B196B286-BAB4-101A-B69C-00AA00341D07")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIConnectionPoint
	{
		// Token: 0x0600627D RID: 25213
		void GetConnectionInterface(out Guid pIID);

		// Token: 0x0600627E RID: 25214
		void GetConnectionPointContainer(out UCOMIConnectionPointContainer ppCPC);

		// Token: 0x0600627F RID: 25215
		void Advise([MarshalAs(UnmanagedType.Interface)] object pUnkSink, out int pdwCookie);

		// Token: 0x06006280 RID: 25216
		void Unadvise(int dwCookie);

		// Token: 0x06006281 RID: 25217
		void EnumConnections(out UCOMIEnumConnections ppEnum);
	}
}
