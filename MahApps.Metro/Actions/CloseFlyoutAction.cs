using System;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Actions
{
	// Token: 0x020000BE RID: 190
	public class CloseFlyoutAction : CommandTriggerAction
	{
		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000A3A RID: 2618 RVA: 0x00027EA8 File Offset: 0x000260A8
		private Flyout AssociatedFlyout
		{
			get
			{
				Flyout result;
				if ((result = this.associatedFlyout) == null)
				{
					result = (this.associatedFlyout = base.AssociatedObject.TryFindParent<Flyout>());
				}
				return result;
			}
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00027ED4 File Offset: 0x000260D4
		protected override void Invoke(object parameter)
		{
			if (base.AssociatedObject == null || (base.AssociatedObject != null && !base.AssociatedObject.IsEnabled))
			{
				return;
			}
			ICommand command = base.Command;
			if (command != null)
			{
				object commandParameter = this.GetCommandParameter();
				if (command.CanExecute(commandParameter))
				{
					command.Execute(commandParameter);
					return;
				}
			}
			else
			{
				Flyout flyout = this.AssociatedFlyout;
				if (flyout == null)
				{
					return;
				}
				flyout.SetCurrentValue(Flyout.IsOpenProperty, false);
			}
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00027F3C File Offset: 0x0002613C
		protected override object GetCommandParameter()
		{
			return base.CommandParameter ?? this.AssociatedFlyout;
		}

		// Token: 0x04000479 RID: 1145
		private Flyout associatedFlyout;
	}
}
