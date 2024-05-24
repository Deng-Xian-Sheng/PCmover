using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200017A RID: 378
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("D6EBC66B-8921-4193-AFDD-A1789FB7FF57")]
	[ComImport]
	internal interface IQuerySolution : IConditionFactory
	{
		// Token: 0x06000EB9 RID: 3769
		[PreserveSig]
		HResult MakeNot([In] ICondition pcSub, [In] bool fSimplify, out ICondition ppcResult);

		// Token: 0x06000EBA RID: 3770
		[PreserveSig]
		HResult MakeAndOr([In] SearchConditionType ct, [In] IEnumUnknown peuSubs, [In] bool fSimplify, out ICondition ppcResult);

		// Token: 0x06000EBB RID: 3771
		[PreserveSig]
		HResult MakeLeaf([MarshalAs(UnmanagedType.LPWStr)] [In] string pszPropertyName, [In] SearchConditionOperation cop, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszValueType, [In] PropVariant ppropvar, IRichChunk richChunk1, IRichChunk richChunk2, IRichChunk richChunk3, [In] bool fExpand, out ICondition ppcResult);

		// Token: 0x06000EBC RID: 3772
		[PreserveSig]
		HResult Resolve();

		// Token: 0x06000EBD RID: 3773
		[PreserveSig]
		HResult GetQuery([MarshalAs(UnmanagedType.Interface)] out ICondition ppQueryNode, [MarshalAs(UnmanagedType.Interface)] out IEntity ppMainType);

		// Token: 0x06000EBE RID: 3774
		[PreserveSig]
		HResult GetErrors([In] ref Guid riid, out IntPtr ppParseErrors);

		// Token: 0x06000EBF RID: 3775
		[PreserveSig]
		HResult GetLexicalData([MarshalAs(UnmanagedType.LPWStr)] out string ppszInputString, out IntPtr ppTokens, out uint plcid, out IntPtr ppWordBreaker);
	}
}
