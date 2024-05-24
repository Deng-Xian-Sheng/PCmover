using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A2B RID: 2603
	[Guid("B196B285-BAB4-101A-B69C-00AA00341D07")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[__DynamicallyInvokable]
	[ComImport]
	public interface IEnumConnectionPoints
	{
		// Token: 0x06006621 RID: 26145
		[PreserveSig]
		int Next(int celt, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] [Out] IConnectionPoint[] rgelt, IntPtr pceltFetched);

		// Token: 0x06006622 RID: 26146
		[__DynamicallyInvokable]
		[PreserveSig]
		int Skip(int celt);

		// Token: 0x06006623 RID: 26147
		[__DynamicallyInvokable]
		void Reset();

		// Token: 0x06006624 RID: 26148
		[__DynamicallyInvokable]
		void Clone(out IEnumConnectionPoints ppenum);
	}
}
