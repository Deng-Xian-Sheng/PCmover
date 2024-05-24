using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A52 RID: 2642
	[Guid("00020411-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[__DynamicallyInvokable]
	[ComImport]
	public interface ITypeLib2 : ITypeLib
	{
		// Token: 0x06006688 RID: 26248
		[__DynamicallyInvokable]
		[PreserveSig]
		int GetTypeInfoCount();

		// Token: 0x06006689 RID: 26249
		[__DynamicallyInvokable]
		void GetTypeInfo(int index, out ITypeInfo ppTI);

		// Token: 0x0600668A RID: 26250
		[__DynamicallyInvokable]
		void GetTypeInfoType(int index, out TYPEKIND pTKind);

		// Token: 0x0600668B RID: 26251
		[__DynamicallyInvokable]
		void GetTypeInfoOfGuid(ref Guid guid, out ITypeInfo ppTInfo);

		// Token: 0x0600668C RID: 26252
		void GetLibAttr(out IntPtr ppTLibAttr);

		// Token: 0x0600668D RID: 26253
		[__DynamicallyInvokable]
		void GetTypeComp(out ITypeComp ppTComp);

		// Token: 0x0600668E RID: 26254
		[__DynamicallyInvokable]
		void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);

		// Token: 0x0600668F RID: 26255
		[__DynamicallyInvokable]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsName([MarshalAs(UnmanagedType.LPWStr)] string szNameBuf, int lHashVal);

		// Token: 0x06006690 RID: 26256
		[__DynamicallyInvokable]
		void FindName([MarshalAs(UnmanagedType.LPWStr)] string szNameBuf, int lHashVal, [MarshalAs(UnmanagedType.LPArray)] [Out] ITypeInfo[] ppTInfo, [MarshalAs(UnmanagedType.LPArray)] [Out] int[] rgMemId, ref short pcFound);

		// Token: 0x06006691 RID: 26257
		[PreserveSig]
		void ReleaseTLibAttr(IntPtr pTLibAttr);

		// Token: 0x06006692 RID: 26258
		[__DynamicallyInvokable]
		void GetCustData(ref Guid guid, out object pVarVal);

		// Token: 0x06006693 RID: 26259
		[LCIDConversion(1)]
		[__DynamicallyInvokable]
		void GetDocumentation2(int index, out string pbstrHelpString, out int pdwHelpStringContext, out string pbstrHelpStringDll);

		// Token: 0x06006694 RID: 26260
		void GetLibStatistics(IntPtr pcUniqueNames, out int pcchUniqueNames);

		// Token: 0x06006695 RID: 26261
		void GetAllCustData(IntPtr pCustData);
	}
}
