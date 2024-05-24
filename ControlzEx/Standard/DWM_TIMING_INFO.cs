using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x0200007E RID: 126
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct DWM_TIMING_INFO
	{
		// Token: 0x040005CC RID: 1484
		public int cbSize;

		// Token: 0x040005CD RID: 1485
		public UNSIGNED_RATIO rateRefresh;

		// Token: 0x040005CE RID: 1486
		public ulong qpcRefreshPeriod;

		// Token: 0x040005CF RID: 1487
		public UNSIGNED_RATIO rateCompose;

		// Token: 0x040005D0 RID: 1488
		public ulong qpcVBlank;

		// Token: 0x040005D1 RID: 1489
		public ulong cRefresh;

		// Token: 0x040005D2 RID: 1490
		public uint cDXRefresh;

		// Token: 0x040005D3 RID: 1491
		public ulong qpcCompose;

		// Token: 0x040005D4 RID: 1492
		public ulong cFrame;

		// Token: 0x040005D5 RID: 1493
		public uint cDXPresent;

		// Token: 0x040005D6 RID: 1494
		public ulong cRefreshFrame;

		// Token: 0x040005D7 RID: 1495
		public ulong cFrameSubmitted;

		// Token: 0x040005D8 RID: 1496
		public uint cDXPresentSubmitted;

		// Token: 0x040005D9 RID: 1497
		public ulong cFrameConfirmed;

		// Token: 0x040005DA RID: 1498
		public uint cDXPresentConfirmed;

		// Token: 0x040005DB RID: 1499
		public ulong cRefreshConfirmed;

		// Token: 0x040005DC RID: 1500
		public uint cDXRefreshConfirmed;

		// Token: 0x040005DD RID: 1501
		public ulong cFramesLate;

		// Token: 0x040005DE RID: 1502
		public uint cFramesOutstanding;

		// Token: 0x040005DF RID: 1503
		public ulong cFrameDisplayed;

		// Token: 0x040005E0 RID: 1504
		public ulong qpcFrameDisplayed;

		// Token: 0x040005E1 RID: 1505
		public ulong cRefreshFrameDisplayed;

		// Token: 0x040005E2 RID: 1506
		public ulong cFrameComplete;

		// Token: 0x040005E3 RID: 1507
		public ulong qpcFrameComplete;

		// Token: 0x040005E4 RID: 1508
		public ulong cFramePending;

		// Token: 0x040005E5 RID: 1509
		public ulong qpcFramePending;

		// Token: 0x040005E6 RID: 1510
		public ulong cFramesDisplayed;

		// Token: 0x040005E7 RID: 1511
		public ulong cFramesComplete;

		// Token: 0x040005E8 RID: 1512
		public ulong cFramesPending;

		// Token: 0x040005E9 RID: 1513
		public ulong cFramesAvailable;

		// Token: 0x040005EA RID: 1514
		public ulong cFramesDropped;

		// Token: 0x040005EB RID: 1515
		public ulong cFramesMissed;

		// Token: 0x040005EC RID: 1516
		public ulong cRefreshNextDisplayed;

		// Token: 0x040005ED RID: 1517
		public ulong cRefreshNextPresented;

		// Token: 0x040005EE RID: 1518
		public ulong cRefreshesDisplayed;

		// Token: 0x040005EF RID: 1519
		public ulong cRefreshesPresented;

		// Token: 0x040005F0 RID: 1520
		public ulong cRefreshStarted;

		// Token: 0x040005F1 RID: 1521
		public ulong cPixelsReceived;

		// Token: 0x040005F2 RID: 1522
		public ulong cPixelsDrawn;

		// Token: 0x040005F3 RID: 1523
		public ulong cBuffersEmpty;
	}
}
