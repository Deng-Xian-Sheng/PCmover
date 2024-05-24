using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200005F RID: 95
	public class MetroHeader : GroupBox
	{
		// Token: 0x0600040D RID: 1037 RVA: 0x00010063 File Offset: 0x0000E263
		static MetroHeader()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroHeader), new FrameworkPropertyMetadata(typeof(MetroHeader)));
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00010088 File Offset: 0x0000E288
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new MetroHeaderAutomationPeer(this);
		}
	}
}
