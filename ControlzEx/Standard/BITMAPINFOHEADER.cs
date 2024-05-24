using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x0200005E RID: 94
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	public struct BITMAPINFOHEADER
	{
		// Token: 0x04000503 RID: 1283
		public int biSize;

		// Token: 0x04000504 RID: 1284
		public int biWidth;

		// Token: 0x04000505 RID: 1285
		public int biHeight;

		// Token: 0x04000506 RID: 1286
		public short biPlanes;

		// Token: 0x04000507 RID: 1287
		public short biBitCount;

		// Token: 0x04000508 RID: 1288
		public BI biCompression;

		// Token: 0x04000509 RID: 1289
		public int biSizeImage;

		// Token: 0x0400050A RID: 1290
		public int biXPelsPerMeter;

		// Token: 0x0400050B RID: 1291
		public int biYPelsPerMeter;

		// Token: 0x0400050C RID: 1292
		public int biClrUsed;

		// Token: 0x0400050D RID: 1293
		public int biClrImportant;
	}
}
