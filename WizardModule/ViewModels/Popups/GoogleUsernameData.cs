using System;
using System.Threading;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000A2 RID: 162
	public class GoogleUsernameData
	{
		// Token: 0x17000671 RID: 1649
		// (get) Token: 0x06000E81 RID: 3713 RVA: 0x00026F36 File Offset: 0x00025136
		// (set) Token: 0x06000E82 RID: 3714 RVA: 0x00026F3E File Offset: 0x0002513E
		public AutoResetEvent ResetEvent { get; set; }

		// Token: 0x17000672 RID: 1650
		// (get) Token: 0x06000E83 RID: 3715 RVA: 0x00026F47 File Offset: 0x00025147
		// (set) Token: 0x06000E84 RID: 3716 RVA: 0x00026F4F File Offset: 0x0002514F
		public string Username { get; set; }
	}
}
