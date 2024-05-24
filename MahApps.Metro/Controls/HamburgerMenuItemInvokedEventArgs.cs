using System;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200003B RID: 59
	public class HamburgerMenuItemInvokedEventArgs : EventArgs
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000293 RID: 659 RVA: 0x0000BAC1 File Offset: 0x00009CC1
		// (set) Token: 0x06000294 RID: 660 RVA: 0x0000BAC9 File Offset: 0x00009CC9
		public object InvokedItem { get; internal set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000295 RID: 661 RVA: 0x0000BAD2 File Offset: 0x00009CD2
		// (set) Token: 0x06000296 RID: 662 RVA: 0x0000BADA File Offset: 0x00009CDA
		public bool IsItemOptions { get; internal set; }
	}
}
