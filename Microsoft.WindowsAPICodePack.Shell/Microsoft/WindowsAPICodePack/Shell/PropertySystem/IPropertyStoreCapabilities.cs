using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x02000099 RID: 153
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("c8e2d566-186e-4d49-bf41-6909ead56acc")]
	[ComImport]
	internal interface IPropertyStoreCapabilities
	{
		// Token: 0x06000506 RID: 1286
		HResult IsPropertyWritable([In] ref PropertyKey propertyKey);
	}
}
