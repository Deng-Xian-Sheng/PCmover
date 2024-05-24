using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006EB RID: 1771
	[StructLayout(LayoutKind.Sequential)]
	internal class CLRSurrogateEntry
	{
		// Token: 0x0400234C RID: 9036
		public Guid Clsid;

		// Token: 0x0400234D RID: 9037
		[MarshalAs(UnmanagedType.LPWStr)]
		public string RuntimeVersion;

		// Token: 0x0400234E RID: 9038
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ClassName;
	}
}
