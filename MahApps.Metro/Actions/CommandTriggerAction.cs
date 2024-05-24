using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace MahApps.Metro.Actions
{
	// Token: 0x020000C0 RID: 192
	public class CommandTriggerAction : TriggerAction<FrameworkElement>
	{
		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000A47 RID: 2631 RVA: 0x00028107 File Offset: 0x00026307
		// (set) Token: 0x06000A48 RID: 2632 RVA: 0x00028119 File Offset: 0x00026319
		public ICommand Command
		{
			get
			{
				return (ICommand)base.GetValue(CommandTriggerAction.CommandProperty);
			}
			set
			{
				base.SetValue(CommandTriggerAction.CommandProperty, value);
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000A49 RID: 2633 RVA: 0x00028127 File Offset: 0x00026327
		// (set) Token: 0x06000A4A RID: 2634 RVA: 0x00028134 File Offset: 0x00026334
		public object CommandParameter
		{
			get
			{
				return base.GetValue(CommandTriggerAction.CommandParameterProperty);
			}
			set
			{
				base.SetValue(CommandTriggerAction.CommandParameterProperty, value);
			}
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x00028142 File Offset: 0x00026342
		protected override void OnAttached()
		{
			base.OnAttached();
			this.EnableDisableElement();
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x00028150 File Offset: 0x00026350
		protected override void Invoke(object parameter)
		{
			if (base.AssociatedObject == null || (base.AssociatedObject != null && !base.AssociatedObject.IsEnabled))
			{
				return;
			}
			ICommand command = this.Command;
			if (command != null)
			{
				object commandParameter = this.GetCommandParameter();
				if (command.CanExecute(commandParameter))
				{
					command.Execute(commandParameter);
				}
			}
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x0002819C File Offset: 0x0002639C
		private static void OnCommandChanged(CommandTriggerAction action, DependencyPropertyChangedEventArgs e)
		{
			if (action == null)
			{
				return;
			}
			if (e.OldValue != null)
			{
				((ICommand)e.OldValue).CanExecuteChanged -= action.OnCommandCanExecuteChanged;
			}
			ICommand command = (ICommand)e.NewValue;
			if (command != null)
			{
				command.CanExecuteChanged += action.OnCommandCanExecuteChanged;
			}
			action.EnableDisableElement();
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x000281FB File Offset: 0x000263FB
		protected virtual object GetCommandParameter()
		{
			return this.CommandParameter ?? base.AssociatedObject;
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x00028210 File Offset: 0x00026410
		private void EnableDisableElement()
		{
			if (base.AssociatedObject == null)
			{
				return;
			}
			ICommand command = this.Command;
			base.AssociatedObject.SetCurrentValue(UIElement.IsEnabledProperty, command == null || command.CanExecute(this.GetCommandParameter()));
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x00028254 File Offset: 0x00026454
		private void OnCommandCanExecuteChanged(object sender, EventArgs e)
		{
			this.EnableDisableElement();
		}

		// Token: 0x0400047D RID: 1149
		public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(CommandTriggerAction), new PropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			CommandTriggerAction.OnCommandChanged(s as CommandTriggerAction, e);
		}));

		// Token: 0x0400047E RID: 1150
		public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(CommandTriggerAction), new PropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			CommandTriggerAction commandTriggerAction = s as CommandTriggerAction;
			if (((commandTriggerAction != null) ? commandTriggerAction.AssociatedObject : null) != null)
			{
				commandTriggerAction.EnableDisableElement();
			}
		}));
	}
}
