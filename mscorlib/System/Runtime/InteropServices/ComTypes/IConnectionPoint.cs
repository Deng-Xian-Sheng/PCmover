using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A25 RID: 2597
	[Guid("B196B286-BAB4-101A-B69C-00AA00341D07")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[__DynamicallyInvokable]
	[ComImport]
	public interface IConnectionPoint
	{
		// Token: 0x06006610 RID: 26128
		[__DynamicallyInvokable]
		void GetConnectionInterface(out Guid pIID);

		// Token: 0x06006611 RID: 26129
		[__DynamicallyInvokable]
		void GetConnectionPointContainer(out IConnectionPointContainer ppCPC);

		// Token: 0x06006612 RID: 26130
		[__DynamicallyInvokable]
		void Advise([MarshalAs(UnmanagedType.Interface)] object pUnkSink, out int pdwCookie);

		// Token: 0x06006613 RID: 26131
		[__DynamicallyInvokable]
		void Unadvise(int dwCookie);

		// Token: 0x06006614 RID: 26132
		[__DynamicallyInvokable]
		void EnumConnections(out IEnumConnections ppEnum);
	}
}
