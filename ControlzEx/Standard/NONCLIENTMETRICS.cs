using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x0200006C RID: 108
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public struct NONCLIENTMETRICS
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600018D RID: 397 RVA: 0x000088C0 File Offset: 0x00006AC0
		public static NONCLIENTMETRICS VistaMetricsStruct
		{
			get
			{
				return new NONCLIENTMETRICS
				{
					cbSize = Marshal.SizeOf(typeof(NONCLIENTMETRICS))
				};
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600018E RID: 398 RVA: 0x000088EC File Offset: 0x00006AEC
		public static NONCLIENTMETRICS XPMetricsStruct
		{
			get
			{
				return new NONCLIENTMETRICS
				{
					cbSize = Marshal.SizeOf(typeof(NONCLIENTMETRICS)) - 4
				};
			}
		}

		// Token: 0x04000569 RID: 1385
		public int cbSize;

		// Token: 0x0400056A RID: 1386
		public int iBorderWidth;

		// Token: 0x0400056B RID: 1387
		public int iScrollWidth;

		// Token: 0x0400056C RID: 1388
		public int iScrollHeight;

		// Token: 0x0400056D RID: 1389
		public int iCaptionWidth;

		// Token: 0x0400056E RID: 1390
		public int iCaptionHeight;

		// Token: 0x0400056F RID: 1391
		public LOGFONT lfCaptionFont;

		// Token: 0x04000570 RID: 1392
		public int iSmCaptionWidth;

		// Token: 0x04000571 RID: 1393
		public int iSmCaptionHeight;

		// Token: 0x04000572 RID: 1394
		public LOGFONT lfSmCaptionFont;

		// Token: 0x04000573 RID: 1395
		public int iMenuWidth;

		// Token: 0x04000574 RID: 1396
		public int iMenuHeight;

		// Token: 0x04000575 RID: 1397
		public LOGFONT lfMenuFont;

		// Token: 0x04000576 RID: 1398
		public LOGFONT lfStatusFont;

		// Token: 0x04000577 RID: 1399
		public LOGFONT lfMessageFont;

		// Token: 0x04000578 RID: 1400
		public int iPaddedBorderWidth;
	}
}
