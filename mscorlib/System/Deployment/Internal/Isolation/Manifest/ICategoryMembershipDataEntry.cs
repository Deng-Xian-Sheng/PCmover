using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006DE RID: 1758
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("DA0C3B27-6B6B-4b80-A8F8-6CE14F4BC0A4")]
	[ComImport]
	internal interface ICategoryMembershipDataEntry
	{
		// Token: 0x17000CEC RID: 3308
		// (get) Token: 0x0600508E RID: 20622
		CategoryMembershipDataEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000CED RID: 3309
		// (get) Token: 0x0600508F RID: 20623
		uint index { [SecurityCritical] get; }

		// Token: 0x17000CEE RID: 3310
		// (get) Token: 0x06005090 RID: 20624
		string Xml { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000CEF RID: 3311
		// (get) Token: 0x06005091 RID: 20625
		string Description { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }
	}
}
