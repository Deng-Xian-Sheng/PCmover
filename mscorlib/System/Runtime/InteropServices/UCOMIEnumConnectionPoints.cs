﻿using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000982 RID: 2434
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IEnumConnectionPoints instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("B196B285-BAB4-101A-B69C-00AA00341D07")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIEnumConnectionPoints
	{
		// Token: 0x0600628E RID: 25230
		[PreserveSig]
		int Next(int celt, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] [Out] UCOMIConnectionPoint[] rgelt, out int pceltFetched);

		// Token: 0x0600628F RID: 25231
		[PreserveSig]
		int Skip(int celt);

		// Token: 0x06006290 RID: 25232
		[PreserveSig]
		int Reset();

		// Token: 0x06006291 RID: 25233
		void Clone(out UCOMIEnumConnectionPoints ppenum);
	}
}
