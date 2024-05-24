using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000080 RID: 128
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 1044)]
	internal struct DROPDESCRIPTION
	{
		// Token: 0x040005F8 RID: 1528
		public DROPIMAGETYPE type;

		// Token: 0x040005F9 RID: 1529
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szMessage;

		// Token: 0x040005FA RID: 1530
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szInsert;
	}
}
