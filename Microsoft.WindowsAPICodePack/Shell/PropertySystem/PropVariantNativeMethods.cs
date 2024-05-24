using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x02000048 RID: 72
	internal static class PropVariantNativeMethods
	{
		// Token: 0x0600017E RID: 382
		[DllImport("Ole32.dll", PreserveSig = false)]
		internal static extern void PropVariantClear([In] [Out] PropVariant pvar);

		// Token: 0x0600017F RID: 383
		[DllImport("OleAut32.dll")]
		internal static extern IntPtr SafeArrayCreateVector(ushort vt, int lowerBound, uint cElems);

		// Token: 0x06000180 RID: 384
		[DllImport("OleAut32.dll", PreserveSig = false)]
		internal static extern IntPtr SafeArrayAccessData(IntPtr psa);

		// Token: 0x06000181 RID: 385
		[DllImport("OleAut32.dll", PreserveSig = false)]
		internal static extern void SafeArrayUnaccessData(IntPtr psa);

		// Token: 0x06000182 RID: 386
		[DllImport("OleAut32.dll")]
		internal static extern uint SafeArrayGetDim(IntPtr psa);

		// Token: 0x06000183 RID: 387
		[DllImport("OleAut32.dll", PreserveSig = false)]
		internal static extern int SafeArrayGetLBound(IntPtr psa, uint nDim);

		// Token: 0x06000184 RID: 388
		[DllImport("OleAut32.dll", PreserveSig = false)]
		internal static extern int SafeArrayGetUBound(IntPtr psa, uint nDim);

		// Token: 0x06000185 RID: 389
		[DllImport("OleAut32.dll", PreserveSig = false)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		internal static extern object SafeArrayGetElement(IntPtr psa, ref int rgIndices);

		// Token: 0x06000186 RID: 390
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void InitPropVariantFromPropVariantVectorElem([In] PropVariant propvarIn, uint iElem, [Out] PropVariant ppropvar);

		// Token: 0x06000187 RID: 391
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void InitPropVariantFromFileTime([In] ref System.Runtime.InteropServices.ComTypes.FILETIME pftIn, [Out] PropVariant ppropvar);

		// Token: 0x06000188 RID: 392
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.I4)]
		internal static extern int PropVariantGetElementCount([In] PropVariant propVar);

		// Token: 0x06000189 RID: 393
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void PropVariantGetBooleanElem([In] PropVariant propVar, [In] uint iElem, [MarshalAs(UnmanagedType.Bool)] out bool pfVal);

		// Token: 0x0600018A RID: 394
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void PropVariantGetInt16Elem([In] PropVariant propVar, [In] uint iElem, out short pnVal);

		// Token: 0x0600018B RID: 395
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void PropVariantGetUInt16Elem([In] PropVariant propVar, [In] uint iElem, out ushort pnVal);

		// Token: 0x0600018C RID: 396
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void PropVariantGetInt32Elem([In] PropVariant propVar, [In] uint iElem, out int pnVal);

		// Token: 0x0600018D RID: 397
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void PropVariantGetUInt32Elem([In] PropVariant propVar, [In] uint iElem, out uint pnVal);

		// Token: 0x0600018E RID: 398
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void PropVariantGetInt64Elem([In] PropVariant propVar, [In] uint iElem, out long pnVal);

		// Token: 0x0600018F RID: 399
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void PropVariantGetUInt64Elem([In] PropVariant propVar, [In] uint iElem, out ulong pnVal);

		// Token: 0x06000190 RID: 400
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void PropVariantGetDoubleElem([In] PropVariant propVar, [In] uint iElem, out double pnVal);

		// Token: 0x06000191 RID: 401
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void PropVariantGetFileTimeElem([In] PropVariant propVar, [In] uint iElem, [MarshalAs(UnmanagedType.Struct)] out System.Runtime.InteropServices.ComTypes.FILETIME pftVal);

		// Token: 0x06000192 RID: 402
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void PropVariantGetStringElem([In] PropVariant propVar, [In] uint iElem, [MarshalAs(UnmanagedType.LPWStr)] ref string ppszVal);

		// Token: 0x06000193 RID: 403
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void InitPropVariantFromBooleanVector([MarshalAs(UnmanagedType.LPArray)] [In] bool[] prgf, uint cElems, [Out] PropVariant ppropvar);

		// Token: 0x06000194 RID: 404
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void InitPropVariantFromInt16Vector([In] [Out] short[] prgn, uint cElems, [Out] PropVariant ppropvar);

		// Token: 0x06000195 RID: 405
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void InitPropVariantFromUInt16Vector([In] [Out] ushort[] prgn, uint cElems, [Out] PropVariant ppropvar);

		// Token: 0x06000196 RID: 406
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void InitPropVariantFromInt32Vector([In] [Out] int[] prgn, uint cElems, [Out] PropVariant propVar);

		// Token: 0x06000197 RID: 407
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void InitPropVariantFromUInt32Vector([In] [Out] uint[] prgn, uint cElems, [Out] PropVariant ppropvar);

		// Token: 0x06000198 RID: 408
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void InitPropVariantFromInt64Vector([In] [Out] long[] prgn, uint cElems, [Out] PropVariant ppropvar);

		// Token: 0x06000199 RID: 409
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void InitPropVariantFromUInt64Vector([In] [Out] ulong[] prgn, uint cElems, [Out] PropVariant ppropvar);

		// Token: 0x0600019A RID: 410
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void InitPropVariantFromDoubleVector([In] [Out] double[] prgn, uint cElems, [Out] PropVariant propvar);

		// Token: 0x0600019B RID: 411
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void InitPropVariantFromFileTimeVector([In] [Out] System.Runtime.InteropServices.ComTypes.FILETIME[] prgft, uint cElems, [Out] PropVariant ppropvar);

		// Token: 0x0600019C RID: 412
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
		internal static extern void InitPropVariantFromStringVector([In] [Out] string[] prgsz, uint cElems, [Out] PropVariant ppropvar);
	}
}
