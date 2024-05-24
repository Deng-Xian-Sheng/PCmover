using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000077 RID: 119
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public class WINDOWPLACEMENT
	{
		// Token: 0x0400059F RID: 1439
		public int length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));

		// Token: 0x040005A0 RID: 1440
		public int flags;

		// Token: 0x040005A1 RID: 1441
		public SW showCmd;

		// Token: 0x040005A2 RID: 1442
		public POINT minPosition;

		// Token: 0x040005A3 RID: 1443
		public POINT maxPosition;

		// Token: 0x040005A4 RID: 1444
		public RECT normalPosition;
	}
}
