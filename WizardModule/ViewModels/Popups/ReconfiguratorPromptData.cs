using System;
using System.Threading;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000AC RID: 172
	public class ReconfiguratorPromptData
	{
		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x06000EE5 RID: 3813 RVA: 0x00027BD2 File Offset: 0x00025DD2
		// (set) Token: 0x06000EE6 RID: 3814 RVA: 0x00027BDA File Offset: 0x00025DDA
		public AutoResetEvent ResetEvent { get; set; }

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x06000EE7 RID: 3815 RVA: 0x00027BE3 File Offset: 0x00025DE3
		// (set) Token: 0x06000EE8 RID: 3816 RVA: 0x00027BEB File Offset: 0x00025DEB
		public bool Run { get; set; }
	}
}
