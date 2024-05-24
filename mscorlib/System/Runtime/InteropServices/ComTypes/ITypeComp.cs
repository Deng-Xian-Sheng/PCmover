using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A38 RID: 2616
	[Guid("00020403-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[__DynamicallyInvokable]
	[ComImport]
	public interface ITypeComp
	{
		// Token: 0x06006669 RID: 26217
		[__DynamicallyInvokable]
		void Bind([MarshalAs(UnmanagedType.LPWStr)] string szName, int lHashVal, short wFlags, out ITypeInfo ppTInfo, out DESCKIND pDescKind, out BINDPTR pBindPtr);

		// Token: 0x0600666A RID: 26218
		[__DynamicallyInvokable]
		void BindType([MarshalAs(UnmanagedType.LPWStr)] string szName, int lHashVal, out ITypeInfo ppTInfo, out ITypeComp ppTComp);
	}
}
