using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006DB RID: 1755
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("0C66F299-E08E-48c5-9264-7CCBEB4D5CBB")]
	[ComImport]
	internal interface IFileAssociationEntry
	{
		// Token: 0x17000CE6 RID: 3302
		// (get) Token: 0x06005087 RID: 20615
		FileAssociationEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000CE7 RID: 3303
		// (get) Token: 0x06005088 RID: 20616
		string Extension { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000CE8 RID: 3304
		// (get) Token: 0x06005089 RID: 20617
		string Description { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000CE9 RID: 3305
		// (get) Token: 0x0600508A RID: 20618
		string ProgID { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000CEA RID: 3306
		// (get) Token: 0x0600508B RID: 20619
		string DefaultIcon { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000CEB RID: 3307
		// (get) Token: 0x0600508C RID: 20620
		string Parameter { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }
	}
}
