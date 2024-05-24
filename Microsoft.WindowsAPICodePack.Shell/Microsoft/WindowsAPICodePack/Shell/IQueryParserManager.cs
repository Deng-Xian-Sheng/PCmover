using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200017C RID: 380
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("A879E3C4-AF77-44fb-8F37-EBD1487CF920")]
	[ComImport]
	internal interface IQueryParserManager
	{
		// Token: 0x06000EC8 RID: 3784
		[PreserveSig]
		HResult CreateLoadedParser([MarshalAs(UnmanagedType.LPWStr)] [In] string pszCatalog, [In] ushort langidForKeywords, [In] ref Guid riid, out IQueryParser ppQueryParser);

		// Token: 0x06000EC9 RID: 3785
		[PreserveSig]
		HResult InitializeOptions([In] bool fUnderstandNQS, [In] bool fAutoWildCard, [In] IQueryParser pQueryParser);

		// Token: 0x06000ECA RID: 3786
		[PreserveSig]
		HResult SetOption([In] QueryParserManagerOption option, [In] PropVariant pOptionValue);
	}
}
