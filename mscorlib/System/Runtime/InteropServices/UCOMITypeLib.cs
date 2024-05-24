using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009A7 RID: 2471
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.ITypeLib instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("00020402-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMITypeLib
	{
		// Token: 0x060062EB RID: 25323
		[PreserveSig]
		int GetTypeInfoCount();

		// Token: 0x060062EC RID: 25324
		void GetTypeInfo(int index, out UCOMITypeInfo ppTI);

		// Token: 0x060062ED RID: 25325
		void GetTypeInfoType(int index, out TYPEKIND pTKind);

		// Token: 0x060062EE RID: 25326
		void GetTypeInfoOfGuid(ref Guid guid, out UCOMITypeInfo ppTInfo);

		// Token: 0x060062EF RID: 25327
		void GetLibAttr(out IntPtr ppTLibAttr);

		// Token: 0x060062F0 RID: 25328
		void GetTypeComp(out UCOMITypeComp ppTComp);

		// Token: 0x060062F1 RID: 25329
		void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);

		// Token: 0x060062F2 RID: 25330
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsName([MarshalAs(UnmanagedType.LPWStr)] string szNameBuf, int lHashVal);

		// Token: 0x060062F3 RID: 25331
		void FindName([MarshalAs(UnmanagedType.LPWStr)] string szNameBuf, int lHashVal, [MarshalAs(UnmanagedType.LPArray)] [Out] UCOMITypeInfo[] ppTInfo, [MarshalAs(UnmanagedType.LPArray)] [Out] int[] rgMemId, ref short pcFound);

		// Token: 0x060062F4 RID: 25332
		[PreserveSig]
		void ReleaseTLibAttr(IntPtr pTLibAttr);
	}
}
