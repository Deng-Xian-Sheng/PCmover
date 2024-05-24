using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A2D RID: 2605
	[Guid("00020404-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[__DynamicallyInvokable]
	[ComImport]
	public interface IEnumVARIANT
	{
		// Token: 0x06006629 RID: 26153
		[PreserveSig]
		int Next(int celt, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] [Out] object[] rgVar, IntPtr pceltFetched);

		// Token: 0x0600662A RID: 26154
		[__DynamicallyInvokable]
		[PreserveSig]
		int Skip(int celt);

		// Token: 0x0600662B RID: 26155
		[__DynamicallyInvokable]
		[PreserveSig]
		int Reset();

		// Token: 0x0600662C RID: 26156
		[__DynamicallyInvokable]
		IEnumVARIANT Clone();
	}
}
