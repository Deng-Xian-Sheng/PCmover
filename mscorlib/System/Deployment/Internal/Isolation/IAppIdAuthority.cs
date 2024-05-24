using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x0200069B RID: 1691
	[Guid("8c87810c-2541-4f75-b2d0-9af515488e23")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IAppIdAuthority
	{
		// Token: 0x06004FAD RID: 20397
		[SecurityCritical]
		IDefinitionAppId TextToDefinition([In] uint Flags, [MarshalAs(UnmanagedType.LPWStr)] [In] string Identity);

		// Token: 0x06004FAE RID: 20398
		[SecurityCritical]
		IReferenceAppId TextToReference([In] uint Flags, [MarshalAs(UnmanagedType.LPWStr)] [In] string Identity);

		// Token: 0x06004FAF RID: 20399
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string DefinitionToText([In] uint Flags, [In] IDefinitionAppId DefinitionAppId);

		// Token: 0x06004FB0 RID: 20400
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string ReferenceToText([In] uint Flags, [In] IReferenceAppId ReferenceAppId);

		// Token: 0x06004FB1 RID: 20401
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool AreDefinitionsEqual([In] uint Flags, [In] IDefinitionAppId Definition1, [In] IDefinitionAppId Definition2);

		// Token: 0x06004FB2 RID: 20402
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool AreReferencesEqual([In] uint Flags, [In] IReferenceAppId Reference1, [In] IReferenceAppId Reference2);

		// Token: 0x06004FB3 RID: 20403
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool AreTextualDefinitionsEqual([In] uint Flags, [MarshalAs(UnmanagedType.LPWStr)] [In] string AppIdLeft, [MarshalAs(UnmanagedType.LPWStr)] [In] string AppIdRight);

		// Token: 0x06004FB4 RID: 20404
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool AreTextualReferencesEqual([In] uint Flags, [MarshalAs(UnmanagedType.LPWStr)] [In] string AppIdLeft, [MarshalAs(UnmanagedType.LPWStr)] [In] string AppIdRight);

		// Token: 0x06004FB5 RID: 20405
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesDefinitionMatchReference([In] uint Flags, [In] IDefinitionAppId DefinitionIdentity, [In] IReferenceAppId ReferenceIdentity);

		// Token: 0x06004FB6 RID: 20406
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesTextualDefinitionMatchTextualReference([In] uint Flags, [MarshalAs(UnmanagedType.LPWStr)] [In] string Definition, [MarshalAs(UnmanagedType.LPWStr)] [In] string Reference);

		// Token: 0x06004FB7 RID: 20407
		[SecurityCritical]
		ulong HashReference([In] uint Flags, [In] IReferenceAppId ReferenceIdentity);

		// Token: 0x06004FB8 RID: 20408
		[SecurityCritical]
		ulong HashDefinition([In] uint Flags, [In] IDefinitionAppId DefinitionIdentity);

		// Token: 0x06004FB9 RID: 20409
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GenerateDefinitionKey([In] uint Flags, [In] IDefinitionAppId DefinitionIdentity);

		// Token: 0x06004FBA RID: 20410
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GenerateReferenceKey([In] uint Flags, [In] IReferenceAppId ReferenceIdentity);

		// Token: 0x06004FBB RID: 20411
		[SecurityCritical]
		IDefinitionAppId CreateDefinition();

		// Token: 0x06004FBC RID: 20412
		[SecurityCritical]
		IReferenceAppId CreateReference();
	}
}
