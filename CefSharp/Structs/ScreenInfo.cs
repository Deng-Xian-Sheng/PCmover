using System;

namespace CefSharp.Structs
{
	// Token: 0x020000A9 RID: 169
	public struct ScreenInfo
	{
		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000531 RID: 1329 RVA: 0x0000830A File Offset: 0x0000650A
		// (set) Token: 0x06000532 RID: 1330 RVA: 0x00008312 File Offset: 0x00006512
		public float DeviceScaleFactor { get; set; }

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x0000831B File Offset: 0x0000651B
		// (set) Token: 0x06000534 RID: 1332 RVA: 0x00008323 File Offset: 0x00006523
		public int Depth { get; set; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000535 RID: 1333 RVA: 0x0000832C File Offset: 0x0000652C
		// (set) Token: 0x06000536 RID: 1334 RVA: 0x00008334 File Offset: 0x00006534
		public int DepthPerComponent { get; set; }

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x0000833D File Offset: 0x0000653D
		// (set) Token: 0x06000538 RID: 1336 RVA: 0x00008345 File Offset: 0x00006545
		public bool IsMonochrome { get; set; }

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x0000834E File Offset: 0x0000654E
		// (set) Token: 0x0600053A RID: 1338 RVA: 0x00008356 File Offset: 0x00006556
		public Rect? Rect { get; set; }

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600053B RID: 1339 RVA: 0x0000835F File Offset: 0x0000655F
		// (set) Token: 0x0600053C RID: 1340 RVA: 0x00008367 File Offset: 0x00006567
		public Rect? AvailableRect { get; set; }
	}
}
