using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009A3 RID: 2467
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.ITypeInfo instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("00020401-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMITypeInfo
	{
		// Token: 0x060062D8 RID: 25304
		void GetTypeAttr(out IntPtr ppTypeAttr);

		// Token: 0x060062D9 RID: 25305
		void GetTypeComp(out UCOMITypeComp ppTComp);

		// Token: 0x060062DA RID: 25306
		void GetFuncDesc(int index, out IntPtr ppFuncDesc);

		// Token: 0x060062DB RID: 25307
		void GetVarDesc(int index, out IntPtr ppVarDesc);

		// Token: 0x060062DC RID: 25308
		void GetNames(int memid, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] [Out] string[] rgBstrNames, int cMaxNames, out int pcNames);

		// Token: 0x060062DD RID: 25309
		void GetRefTypeOfImplType(int index, out int href);

		// Token: 0x060062DE RID: 25310
		void GetImplTypeFlags(int index, out int pImplTypeFlags);

		// Token: 0x060062DF RID: 25311
		void GetIDsOfNames([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] [In] string[] rgszNames, int cNames, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [Out] int[] pMemId);

		// Token: 0x060062E0 RID: 25312
		void Invoke([MarshalAs(UnmanagedType.IUnknown)] object pvInstance, int memid, short wFlags, ref DISPPARAMS pDispParams, out object pVarResult, out EXCEPINFO pExcepInfo, out int puArgErr);

		// Token: 0x060062E1 RID: 25313
		void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);

		// Token: 0x060062E2 RID: 25314
		void GetDllEntry(int memid, INVOKEKIND invKind, out string pBstrDllName, out string pBstrName, out short pwOrdinal);

		// Token: 0x060062E3 RID: 25315
		void GetRefTypeInfo(int hRef, out UCOMITypeInfo ppTI);

		// Token: 0x060062E4 RID: 25316
		void AddressOfMember(int memid, INVOKEKIND invKind, out IntPtr ppv);

		// Token: 0x060062E5 RID: 25317
		void CreateInstance([MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		// Token: 0x060062E6 RID: 25318
		void GetMops(int memid, out string pBstrMops);

		// Token: 0x060062E7 RID: 25319
		void GetContainingTypeLib(out UCOMITypeLib ppTLB, out int pIndex);

		// Token: 0x060062E8 RID: 25320
		void ReleaseTypeAttr(IntPtr pTypeAttr);

		// Token: 0x060062E9 RID: 25321
		void ReleaseFuncDesc(IntPtr pFuncDesc);

		// Token: 0x060062EA RID: 25322
		void ReleaseVarDesc(IntPtr pVarDesc);
	}
}
