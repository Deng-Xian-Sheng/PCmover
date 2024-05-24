using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x0200006A RID: 106
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct LOGFONT
	{
		// Token: 0x04000556 RID: 1366
		public int lfHeight;

		// Token: 0x04000557 RID: 1367
		public int lfWidth;

		// Token: 0x04000558 RID: 1368
		public int lfEscapement;

		// Token: 0x04000559 RID: 1369
		public int lfOrientation;

		// Token: 0x0400055A RID: 1370
		public int lfWeight;

		// Token: 0x0400055B RID: 1371
		public byte lfItalic;

		// Token: 0x0400055C RID: 1372
		public byte lfUnderline;

		// Token: 0x0400055D RID: 1373
		public byte lfStrikeOut;

		// Token: 0x0400055E RID: 1374
		public byte lfCharSet;

		// Token: 0x0400055F RID: 1375
		public byte lfOutPrecision;

		// Token: 0x04000560 RID: 1376
		public byte lfClipPrecision;

		// Token: 0x04000561 RID: 1377
		public byte lfQuality;

		// Token: 0x04000562 RID: 1378
		public byte lfPitchAndFamily;

		// Token: 0x04000563 RID: 1379
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string lfFaceName;
	}
}
