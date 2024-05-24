using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000065 RID: 101
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[StructLayout(LayoutKind.Sequential)]
	public class NOTIFYICONDATA
	{
		// Token: 0x0400053C RID: 1340
		public int cbSize;

		// Token: 0x0400053D RID: 1341
		public IntPtr hWnd;

		// Token: 0x0400053E RID: 1342
		public int uID;

		// Token: 0x0400053F RID: 1343
		public NIF uFlags;

		// Token: 0x04000540 RID: 1344
		public int uCallbackMessage;

		// Token: 0x04000541 RID: 1345
		public IntPtr hIcon;

		// Token: 0x04000542 RID: 1346
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		public char[] szTip = new char[128];

		// Token: 0x04000543 RID: 1347
		public uint dwState;

		// Token: 0x04000544 RID: 1348
		public uint dwStateMask;

		// Token: 0x04000545 RID: 1349
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public char[] szInfo = new char[256];

		// Token: 0x04000546 RID: 1350
		public uint uVersion;

		// Token: 0x04000547 RID: 1351
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public char[] szInfoTitle = new char[64];

		// Token: 0x04000548 RID: 1352
		public uint dwInfoFlags;

		// Token: 0x04000549 RID: 1353
		public Guid guidItem;

		// Token: 0x0400054A RID: 1354
		private IntPtr hBalloonIcon;
	}
}
