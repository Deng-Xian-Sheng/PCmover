using System;
using System.Windows;
using System.Windows.Interactivity;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Actions
{
	// Token: 0x020000C1 RID: 193
	[Obsolete("This TargetedTriggerAction will be deleted in the next release.")]
	public class SetFlyoutOpenAction : TargetedTriggerAction<FrameworkElement>
	{
		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x000282E3 File Offset: 0x000264E3
		// (set) Token: 0x06000A54 RID: 2644 RVA: 0x000282F5 File Offset: 0x000264F5
		public bool Value
		{
			get
			{
				return (bool)base.GetValue(SetFlyoutOpenAction.ValueProperty);
			}
			set
			{
				base.SetValue(SetFlyoutOpenAction.ValueProperty, value);
			}
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x00028308 File Offset: 0x00026508
		protected override void Invoke(object parameter)
		{
			((Flyout)base.TargetObject).IsOpen = this.Value;
		}

		// Token: 0x0400047F RID: 1151
		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(bool), typeof(SetFlyoutOpenAction), new PropertyMetadata(false));
	}
}
