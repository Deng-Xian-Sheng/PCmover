using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000172 RID: 370
	[Guid("0FC988D4-C935-4b97-A973-46282EA175C8")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface ICondition : IPersistStream
	{
		// Token: 0x06000E9A RID: 3738
		[PreserveSig]
		void GetClassID(out Guid pClassID);

		// Token: 0x06000E9B RID: 3739
		[PreserveSig]
		HResult IsDirty();

		// Token: 0x06000E9C RID: 3740
		[PreserveSig]
		HResult Load([MarshalAs(UnmanagedType.Interface)] [In] IStream stm);

		// Token: 0x06000E9D RID: 3741
		[PreserveSig]
		HResult Save([MarshalAs(UnmanagedType.Interface)] [In] IStream stm, bool fRemember);

		// Token: 0x06000E9E RID: 3742
		[PreserveSig]
		HResult GetSizeMax(out ulong cbSize);

		// Token: 0x06000E9F RID: 3743
		[PreserveSig]
		HResult GetConditionType(out SearchConditionType pNodeType);

		// Token: 0x06000EA0 RID: 3744
		[PreserveSig]
		HResult GetSubConditions([In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

		// Token: 0x06000EA1 RID: 3745
		[PreserveSig]
		HResult GetComparisonInfo([MarshalAs(UnmanagedType.LPWStr)] out string ppszPropertyName, out SearchConditionOperation pcop, [Out] PropVariant ppropvar);

		// Token: 0x06000EA2 RID: 3746
		[PreserveSig]
		HResult GetValueType([MarshalAs(UnmanagedType.LPWStr)] out string ppszValueTypeName);

		// Token: 0x06000EA3 RID: 3747
		[PreserveSig]
		HResult GetValueNormalization([MarshalAs(UnmanagedType.LPWStr)] out string ppszNormalization);

		// Token: 0x06000EA4 RID: 3748
		[PreserveSig]
		HResult GetInputTerms(out IRichChunk ppPropertyTerm, out IRichChunk ppOperationTerm, out IRichChunk ppValueTerm);

		// Token: 0x06000EA5 RID: 3749
		[PreserveSig]
		HResult Clone(out ICondition ppc);
	}
}
