using System;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x02000039 RID: 57
	public class NavigationLogEventArgs : EventArgs
	{
		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000247 RID: 583 RVA: 0x0000A6D0 File Offset: 0x000088D0
		// (set) Token: 0x06000248 RID: 584 RVA: 0x0000A6E7 File Offset: 0x000088E7
		public bool CanNavigateForwardChanged { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000249 RID: 585 RVA: 0x0000A6F0 File Offset: 0x000088F0
		// (set) Token: 0x0600024A RID: 586 RVA: 0x0000A707 File Offset: 0x00008907
		public bool CanNavigateBackwardChanged { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600024B RID: 587 RVA: 0x0000A710 File Offset: 0x00008910
		// (set) Token: 0x0600024C RID: 588 RVA: 0x0000A727 File Offset: 0x00008927
		public bool LocationsChanged { get; set; }
	}
}
