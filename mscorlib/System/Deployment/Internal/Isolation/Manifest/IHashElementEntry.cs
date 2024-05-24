using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006D5 RID: 1749
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("9D46FB70-7B54-4f4f-9331-BA9E87833FF5")]
	[ComImport]
	internal interface IHashElementEntry
	{
		// Token: 0x17000CD0 RID: 3280
		// (get) Token: 0x0600506C RID: 20588
		HashElementEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000CD1 RID: 3281
		// (get) Token: 0x0600506D RID: 20589
		uint index { [SecurityCritical] get; }

		// Token: 0x17000CD2 RID: 3282
		// (get) Token: 0x0600506E RID: 20590
		byte Transform { [SecurityCritical] get; }

		// Token: 0x17000CD3 RID: 3283
		// (get) Token: 0x0600506F RID: 20591
		object TransformMetadata { [SecurityCritical] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000CD4 RID: 3284
		// (get) Token: 0x06005070 RID: 20592
		byte DigestMethod { [SecurityCritical] get; }

		// Token: 0x17000CD5 RID: 3285
		// (get) Token: 0x06005071 RID: 20593
		object DigestValue { [SecurityCritical] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000CD6 RID: 3286
		// (get) Token: 0x06005072 RID: 20594
		string Xml { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }
	}
}
