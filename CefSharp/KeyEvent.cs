using System;

namespace CefSharp
{
	// Token: 0x02000095 RID: 149
	public struct KeyEvent
	{
		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x00006CC5 File Offset: 0x00004EC5
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x00006CCD File Offset: 0x00004ECD
		public KeyEventType Type { get; set; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x00006CD6 File Offset: 0x00004ED6
		// (set) Token: 0x06000456 RID: 1110 RVA: 0x00006CDE File Offset: 0x00004EDE
		public CefEventFlags Modifiers { get; set; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x00006CE7 File Offset: 0x00004EE7
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x00006CEF File Offset: 0x00004EEF
		public int WindowsKeyCode { get; set; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x00006CF8 File Offset: 0x00004EF8
		// (set) Token: 0x0600045A RID: 1114 RVA: 0x00006D00 File Offset: 0x00004F00
		public int NativeKeyCode { get; set; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x00006D09 File Offset: 0x00004F09
		// (set) Token: 0x0600045C RID: 1116 RVA: 0x00006D11 File Offset: 0x00004F11
		public bool IsSystemKey { get; set; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x00006D1A File Offset: 0x00004F1A
		// (set) Token: 0x0600045E RID: 1118 RVA: 0x00006D22 File Offset: 0x00004F22
		public bool FocusOnEditableField { get; set; }
	}
}
