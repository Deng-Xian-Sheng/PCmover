using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x0200009E RID: 158
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("57D2EDED-5062-400E-B107-5DAE79FE57A6")]
	[ComImport]
	internal interface IPropertyDescription2 : IPropertyDescription
	{
		// Token: 0x06000527 RID: 1319
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetPropertyKey(out PropertyKey pkey);

		// Token: 0x06000528 RID: 1320
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetCanonicalName([MarshalAs(UnmanagedType.LPWStr)] out string ppszName);

		// Token: 0x06000529 RID: 1321
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetPropertyType(out VarEnum pvartype);

		// Token: 0x0600052A RID: 1322
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDisplayName([MarshalAs(UnmanagedType.LPWStr)] out string ppszName);

		// Token: 0x0600052B RID: 1323
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetEditInvitation([MarshalAs(UnmanagedType.LPWStr)] out string ppszInvite);

		// Token: 0x0600052C RID: 1324
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetTypeFlags([In] PropertyTypeOptions mask, out PropertyTypeOptions ppdtFlags);

		// Token: 0x0600052D RID: 1325
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetViewFlags(out PropertyViewOptions ppdvFlags);

		// Token: 0x0600052E RID: 1326
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDefaultColumnWidth(out uint pcxChars);

		// Token: 0x0600052F RID: 1327
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDisplayType(out PropertyDisplayType pdisplaytype);

		// Token: 0x06000530 RID: 1328
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetColumnState(out uint pcsFlags);

		// Token: 0x06000531 RID: 1329
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetGroupingRange(out PropertyGroupingRange pgr);

		// Token: 0x06000532 RID: 1330
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetRelativeDescriptionType(out PropertySystemNativeMethods.RelativeDescriptionType prdt);

		// Token: 0x06000533 RID: 1331
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetRelativeDescription([In] PropVariant propvar1, [In] PropVariant propvar2, [MarshalAs(UnmanagedType.LPWStr)] out string ppszDesc1, [MarshalAs(UnmanagedType.LPWStr)] out string ppszDesc2);

		// Token: 0x06000534 RID: 1332
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSortDescription(out PropertySortDescription psd);

		// Token: 0x06000535 RID: 1333
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSortDescriptionLabel([In] int fDescending, [MarshalAs(UnmanagedType.LPWStr)] out string ppszDescription);

		// Token: 0x06000536 RID: 1334
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetAggregationType(out PropertyAggregationType paggtype);

		// Token: 0x06000537 RID: 1335
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetConditionType(out PropertyConditionType pcontype, out PropertyConditionOperation popDefault);

		// Token: 0x06000538 RID: 1336
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetEnumTypeList([In] ref Guid riid, out IntPtr ppv);

		// Token: 0x06000539 RID: 1337
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CoerceToCanonicalValue([In] [Out] PropVariant ppropvar);

		// Token: 0x0600053A RID: 1338
		[MethodImpl(MethodImplOptions.InternalCall)]
		void FormatForDisplay([In] PropVariant propvar, [In] ref PropertyDescriptionFormatOptions pdfFlags, [MarshalAs(UnmanagedType.LPWStr)] out string ppszDisplay);

		// Token: 0x0600053B RID: 1339
		[MethodImpl(MethodImplOptions.InternalCall)]
		HResult IsValueCanonical([In] PropVariant propvar);

		// Token: 0x0600053C RID: 1340
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetImageReferenceForValue([In] PropVariant propvar, [MarshalAs(UnmanagedType.LPWStr)] out string ppszImageRes);
	}
}
