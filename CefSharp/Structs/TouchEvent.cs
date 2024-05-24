using System;
using CefSharp.Enums;

namespace CefSharp.Structs
{
	// Token: 0x020000AB RID: 171
	public struct TouchEvent
	{
		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x000083A9 File Offset: 0x000065A9
		// (set) Token: 0x06000543 RID: 1347 RVA: 0x000083B1 File Offset: 0x000065B1
		public int Id { get; set; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x000083BA File Offset: 0x000065BA
		// (set) Token: 0x06000545 RID: 1349 RVA: 0x000083C2 File Offset: 0x000065C2
		public float X { get; set; }

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x000083CB File Offset: 0x000065CB
		// (set) Token: 0x06000547 RID: 1351 RVA: 0x000083D3 File Offset: 0x000065D3
		public float Y { get; set; }

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000548 RID: 1352 RVA: 0x000083DC File Offset: 0x000065DC
		// (set) Token: 0x06000549 RID: 1353 RVA: 0x000083E4 File Offset: 0x000065E4
		public float RadiusX { get; set; }

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600054A RID: 1354 RVA: 0x000083ED File Offset: 0x000065ED
		// (set) Token: 0x0600054B RID: 1355 RVA: 0x000083F5 File Offset: 0x000065F5
		public float RadiusY { get; set; }

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x000083FE File Offset: 0x000065FE
		// (set) Token: 0x0600054D RID: 1357 RVA: 0x00008406 File Offset: 0x00006606
		public float RotationAngle { get; set; }

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x0000840F File Offset: 0x0000660F
		// (set) Token: 0x0600054F RID: 1359 RVA: 0x00008417 File Offset: 0x00006617
		public PointerType PointerType { get; set; }

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000550 RID: 1360 RVA: 0x00008420 File Offset: 0x00006620
		// (set) Token: 0x06000551 RID: 1361 RVA: 0x00008428 File Offset: 0x00006628
		public float Pressure { get; set; }

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000552 RID: 1362 RVA: 0x00008431 File Offset: 0x00006631
		// (set) Token: 0x06000553 RID: 1363 RVA: 0x00008439 File Offset: 0x00006639
		public TouchEventType Type { get; set; }

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000554 RID: 1364 RVA: 0x00008442 File Offset: 0x00006642
		// (set) Token: 0x06000555 RID: 1365 RVA: 0x0000844A File Offset: 0x0000664A
		public CefEventFlags Modifiers { get; set; }
	}
}
