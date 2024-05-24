using System;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000060 RID: 96
	public class MetroHeaderAutomationPeer : GroupBoxAutomationPeer
	{
		// Token: 0x06000410 RID: 1040 RVA: 0x00010098 File Offset: 0x0000E298
		public MetroHeaderAutomationPeer(GroupBox owner) : base(owner)
		{
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x000100A1 File Offset: 0x0000E2A1
		protected override string GetClassNameCore()
		{
			return "MetroHeader";
		}
	}
}
