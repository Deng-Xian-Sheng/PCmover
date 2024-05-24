using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A2A RID: 2602
	[Guid("B196B287-BAB4-101A-B69C-00AA00341D07")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[__DynamicallyInvokable]
	[ComImport]
	public interface IEnumConnections
	{
		// Token: 0x0600661D RID: 26141
		[PreserveSig]
		int Next(int celt, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] [Out] CONNECTDATA[] rgelt, IntPtr pceltFetched);

		// Token: 0x0600661E RID: 26142
		[__DynamicallyInvokable]
		[PreserveSig]
		int Skip(int celt);

		// Token: 0x0600661F RID: 26143
		[__DynamicallyInvokable]
		void Reset();

		// Token: 0x06006620 RID: 26144
		[__DynamicallyInvokable]
		void Clone(out IEnumConnections ppenum);
	}
}
