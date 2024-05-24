using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200017B RID: 379
	[Guid("2EBDEE67-3505-43f8-9946-EA44ABC8E5B0")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IQueryParser
	{
		// Token: 0x06000EC0 RID: 3776
		[PreserveSig]
		HResult Parse([MarshalAs(UnmanagedType.LPWStr)] [In] string pszInputString, [In] IEnumUnknown pCustomProperties, out IQuerySolution ppSolution);

		// Token: 0x06000EC1 RID: 3777
		[PreserveSig]
		HResult SetOption([In] StructuredQuerySingleOption option, [In] PropVariant pOptionValue);

		// Token: 0x06000EC2 RID: 3778
		[PreserveSig]
		HResult GetOption([In] StructuredQuerySingleOption option, [Out] PropVariant pOptionValue);

		// Token: 0x06000EC3 RID: 3779
		[PreserveSig]
		HResult SetMultiOption([In] StructuredQueryMultipleOption option, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszOptionKey, [In] PropVariant pOptionValue);

		// Token: 0x06000EC4 RID: 3780
		[PreserveSig]
		HResult GetSchemaProvider(out IntPtr ppSchemaProvider);

		// Token: 0x06000EC5 RID: 3781
		[PreserveSig]
		HResult RestateToString([In] ICondition pCondition, [In] bool fUseEnglish, [MarshalAs(UnmanagedType.LPWStr)] out string ppszQueryString);

		// Token: 0x06000EC6 RID: 3782
		[PreserveSig]
		HResult ParsePropertyValue([MarshalAs(UnmanagedType.LPWStr)] [In] string pszPropertyName, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszInputString, out IQuerySolution ppSolution);

		// Token: 0x06000EC7 RID: 3783
		[PreserveSig]
		HResult RestatePropertyValueToString([In] ICondition pCondition, [In] bool fUseEnglish, [MarshalAs(UnmanagedType.LPWStr)] out string ppszPropertyName, [MarshalAs(UnmanagedType.LPWStr)] out string ppszQueryString);
	}
}
