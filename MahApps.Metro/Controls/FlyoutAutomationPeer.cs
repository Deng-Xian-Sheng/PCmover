using System;
using System.Windows.Automation.Peers;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000032 RID: 50
	public class FlyoutAutomationPeer : FrameworkElementAutomationPeer
	{
		// Token: 0x060001EE RID: 494 RVA: 0x000096C4 File Offset: 0x000078C4
		public FlyoutAutomationPeer(Flyout owner) : base(owner)
		{
		}

		// Token: 0x060001EF RID: 495 RVA: 0x000096CD File Offset: 0x000078CD
		protected override string GetClassNameCore()
		{
			return "Flyout";
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x000096D4 File Offset: 0x000078D4
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Custom;
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x000096D8 File Offset: 0x000078D8
		protected override string GetNameCore()
		{
			string text = base.GetNameCore();
			if (string.IsNullOrEmpty(text))
			{
				text = (((Flyout)base.Owner).Header as string);
			}
			if (string.IsNullOrEmpty(text))
			{
				text = ((Flyout)base.Owner).Name;
			}
			if (string.IsNullOrEmpty(text))
			{
				text = this.GetClassNameCore();
			}
			return text;
		}
	}
}
