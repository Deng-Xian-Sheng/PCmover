using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000698 RID: 1688
	[Guid("261a6983-c35d-4d0d-aa5b-7867259e77bc")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IIdentityAuthority
	{
		// Token: 0x06004F9B RID: 20379
		[SecurityCritical]
		IDefinitionIdentity TextToDefinition([In] uint Flags, [MarshalAs(UnmanagedType.LPWStr)] [In] string Identity);

		// Token: 0x06004F9C RID: 20380
		[SecurityCritical]
		IReferenceIdentity TextToReference([In] uint Flags, [MarshalAs(UnmanagedType.LPWStr)] [In] string Identity);

		// Token: 0x06004F9D RID: 20381
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string DefinitionToText([In] uint Flags, [In] IDefinitionIdentity DefinitionIdentity);

		// Token: 0x06004F9E RID: 20382
		[SecurityCritical]
		uint DefinitionToTextBuffer([In] uint Flags, [In] IDefinitionIdentity DefinitionIdentity, [In] uint BufferSize, [MarshalAs(UnmanagedType.LPArray)] [Out] char[] Buffer);

		// Token: 0x06004F9F RID: 20383
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string ReferenceToText([In] uint Flags, [In] IReferenceIdentity ReferenceIdentity);

		// Token: 0x06004FA0 RID: 20384
		[SecurityCritical]
		uint ReferenceToTextBuffer([In] uint Flags, [In] IReferenceIdentity ReferenceIdentity, [In] uint BufferSize, [MarshalAs(UnmanagedType.LPArray)] [Out] char[] Buffer);

		// Token: 0x06004FA1 RID: 20385
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool AreDefinitionsEqual([In] uint Flags, [In] IDefinitionIdentity Definition1, [In] IDefinitionIdentity Definition2);

		// Token: 0x06004FA2 RID: 20386
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool AreReferencesEqual([In] uint Flags, [In] IReferenceIdentity Reference1, [In] IReferenceIdentity Reference2);

		// Token: 0x06004FA3 RID: 20387
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool AreTextualDefinitionsEqual([In] uint Flags, [MarshalAs(UnmanagedType.LPWStr)] [In] string IdentityLeft, [MarshalAs(UnmanagedType.LPWStr)] [In] string IdentityRight);

		// Token: 0x06004FA4 RID: 20388
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool AreTextualReferencesEqual([In] uint Flags, [MarshalAs(UnmanagedType.LPWStr)] [In] string IdentityLeft, [MarshalAs(UnmanagedType.LPWStr)] [In] string IdentityRight);

		// Token: 0x06004FA5 RID: 20389
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesDefinitionMatchReference([In] uint Flags, [In] IDefinitionIdentity DefinitionIdentity, [In] IReferenceIdentity ReferenceIdentity);

		// Token: 0x06004FA6 RID: 20390
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesTextualDefinitionMatchTextualReference([In] uint Flags, [MarshalAs(UnmanagedType.LPWStr)] [In] string Definition, [MarshalAs(UnmanagedType.LPWStr)] [In] string Reference);

		// Token: 0x06004FA7 RID: 20391
		[SecurityCritical]
		ulong HashReference([In] uint Flags, [In] IReferenceIdentity ReferenceIdentity);

		// Token: 0x06004FA8 RID: 20392
		[SecurityCritical]
		ulong HashDefinition([In] uint Flags, [In] IDefinitionIdentity DefinitionIdentity);

		// Token: 0x06004FA9 RID: 20393
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GenerateDefinitionKey([In] uint Flags, [In] IDefinitionIdentity DefinitionIdentity);

		// Token: 0x06004FAA RID: 20394
		[SecurityCritical]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GenerateReferenceKey([In] uint Flags, [In] IReferenceIdentity ReferenceIdentity);

		// Token: 0x06004FAB RID: 20395
		[SecurityCritical]
		IDefinitionIdentity CreateDefinition();

		// Token: 0x06004FAC RID: 20396
		[SecurityCritical]
		IReferenceIdentity CreateReference();
	}
}
