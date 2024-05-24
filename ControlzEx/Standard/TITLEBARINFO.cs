using System;

namespace ControlzEx.Standard
{
	// Token: 0x02000063 RID: 99
	internal struct TITLEBARINFO
	{
		// Token: 0x04000526 RID: 1318
		public int cbSize;

		// Token: 0x04000527 RID: 1319
		public RECT rcTitleBar;

		// Token: 0x04000528 RID: 1320
		public STATE_SYSTEM rgstate_TitleBar;

		// Token: 0x04000529 RID: 1321
		public STATE_SYSTEM rgstate_Reserved;

		// Token: 0x0400052A RID: 1322
		public STATE_SYSTEM rgstate_MinimizeButton;

		// Token: 0x0400052B RID: 1323
		public STATE_SYSTEM rgstate_MaximizeButton;

		// Token: 0x0400052C RID: 1324
		public STATE_SYSTEM rgstate_HelpButton;

		// Token: 0x0400052D RID: 1325
		public STATE_SYSTEM rgstate_CloseButton;
	}
}
