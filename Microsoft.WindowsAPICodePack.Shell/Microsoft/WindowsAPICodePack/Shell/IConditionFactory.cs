using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000174 RID: 372
	[Guid("A5EFE073-B16F-474f-9F3E-9F8B497A3E08")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IConditionFactory
	{
		// Token: 0x06000EA7 RID: 3751
		[PreserveSig]
		HResult MakeNot([In] ICondition pcSub, [In] bool fSimplify, out ICondition ppcResult);

		// Token: 0x06000EA8 RID: 3752
		[PreserveSig]
		HResult MakeAndOr([In] SearchConditionType ct, [In] IEnumUnknown peuSubs, [In] bool fSimplify, out ICondition ppcResult);

		// Token: 0x06000EA9 RID: 3753
		[PreserveSig]
		HResult MakeLeaf([MarshalAs(UnmanagedType.LPWStr)] [In] string pszPropertyName, [In] SearchConditionOperation cop, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszValueType, [In] PropVariant ppropvar, IRichChunk richChunk1, IRichChunk richChunk2, IRichChunk richChunk3, [In] bool fExpand, out ICondition ppcResult);

		// Token: 0x06000EAA RID: 3754
		[PreserveSig]
		HResult Resolve();
	}
}
