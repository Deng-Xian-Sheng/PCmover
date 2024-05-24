using System;
using System.Windows;
using System.Windows.Automation.Peers;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000068 RID: 104
	public class MetroThumbContentControlAutomationPeer : FrameworkElementAutomationPeer
	{
		// Token: 0x0600049A RID: 1178 RVA: 0x00011B19 File Offset: 0x0000FD19
		public MetroThumbContentControlAutomationPeer(FrameworkElement owner) : base(owner)
		{
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00011B22 File Offset: 0x0000FD22
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Custom;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00011B26 File Offset: 0x0000FD26
		protected override string GetClassNameCore()
		{
			return "MetroThumbContentControl";
		}
	}
}
