using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x0200009D RID: 157
	[Guid("6F79D558-3E96-4549-A1D1-7D75D2288814")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IPropertyDescription
	{
		// Token: 0x06000512 RID: 1298
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetPropertyKey(out PropertyKey pkey);

		// Token: 0x06000513 RID: 1299
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetCanonicalName([MarshalAs(UnmanagedType.LPWStr)] out string ppszName);

		// Token: 0x06000514 RID: 1300
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetPropertyType(out VarEnum pvartype);

		// Token: 0x06000515 RID: 1301
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetDisplayName(out IntPtr ppszName);

		// Token: 0x06000516 RID: 1302
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetEditInvitation(out IntPtr ppszInvite);

		// Token: 0x06000517 RID: 1303
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetTypeFlags([In] PropertyTypeOptions mask, out PropertyTypeOptions ppdtFlags);

		// Token: 0x06000518 RID: 1304
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetViewFlags(out PropertyViewOptions ppdvFlags);

		// Token: 0x06000519 RID: 1305
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetDefaultColumnWidth(out uint pcxChars);

		// Token: 0x0600051A RID: 1306
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetDisplayType(out PropertyDisplayType pdisplaytype);

		// Token: 0x0600051B RID: 1307
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetColumnState(out PropertyColumnStateOptions pcsFlags);

		// Token: 0x0600051C RID: 1308
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetGroupingRange(out PropertyGroupingRange pgr);

		// Token: 0x0600051D RID: 1309
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetRelativeDescriptionType(out PropertySystemNativeMethods.RelativeDescriptionType prdt);

		// Token: 0x0600051E RID: 1310
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetRelativeDescription([In] PropVariant propvar1, [In] PropVariant propvar2, [MarshalAs(UnmanagedType.LPWStr)] out string ppszDesc1, [MarshalAs(UnmanagedType.LPWStr)] out string ppszDesc2);

		// Token: 0x0600051F RID: 1311
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetSortDescription(out PropertySortDescription psd);

		// Token: 0x06000520 RID: 1312
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetSortDescriptionLabel([In] bool fDescending, out IntPtr ppszDescription);

		// Token: 0x06000521 RID: 1313
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetAggregationType(out PropertyAggregationType paggtype);

		// Token: 0x06000522 RID: 1314
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetConditionType(out PropertyConditionType pcontype, out PropertyConditionOperation popDefault);

		// Token: 0x06000523 RID: 1315
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult GetEnumTypeList([In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IPropertyEnumTypeList ppv);

		// Token: 0x06000524 RID: 1316
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CoerceToCanonicalValue([In] [Out] PropVariant propvar);

		// Token: 0x06000525 RID: 1317
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		HResult FormatForDisplay([In] PropVariant propvar, [In] ref PropertyDescriptionFormatOptions pdfFlags, [MarshalAs(UnmanagedType.LPWStr)] out string ppszDisplay);

		// Token: 0x06000526 RID: 1318
		[MethodImpl(MethodImplOptions.InternalCall)]
		HResult IsValueCanonical([In] PropVariant propvar);
	}
}
