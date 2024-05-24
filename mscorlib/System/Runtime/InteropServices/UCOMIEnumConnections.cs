using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000981 RID: 2433
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IEnumConnections instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("B196B287-BAB4-101A-B69C-00AA00341D07")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIEnumConnections
	{
		// Token: 0x0600628A RID: 25226
		[PreserveSig]
		int Next(int celt, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] [Out] CONNECTDATA[] rgelt, out int pceltFetched);

		// Token: 0x0600628B RID: 25227
		[PreserveSig]
		int Skip(int celt);

		// Token: 0x0600628C RID: 25228
		[PreserveSig]
		void Reset();

		// Token: 0x0600628D RID: 25229
		void Clone(out UCOMIEnumConnections ppenum);
	}
}
