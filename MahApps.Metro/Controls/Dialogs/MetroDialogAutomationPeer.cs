using System;
using System.Windows.Automation.Peers;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000AE RID: 174
	public class MetroDialogAutomationPeer : FrameworkElementAutomationPeer
	{
		// Token: 0x06000971 RID: 2417 RVA: 0x000256E0 File Offset: 0x000238E0
		public MetroDialogAutomationPeer(BaseMetroDialog owner) : base(owner)
		{
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x000256E9 File Offset: 0x000238E9
		protected override string GetClassNameCore()
		{
			return base.Owner.GetType().Name;
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x000256FB File Offset: 0x000238FB
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Custom;
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x00025700 File Offset: 0x00023900
		protected override string GetNameCore()
		{
			string text = base.GetNameCore();
			if (string.IsNullOrEmpty(text))
			{
				text = ((BaseMetroDialog)base.Owner).Title;
			}
			if (string.IsNullOrEmpty(text))
			{
				text = ((BaseMetroDialog)base.Owner).Name;
			}
			if (string.IsNullOrEmpty(text))
			{
				text = this.GetClassNameCore();
			}
			return text;
		}
	}
}
