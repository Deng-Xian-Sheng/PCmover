using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Prism.Interactivity
{
	// Token: 0x02000070 RID: 112
	public class InvokeCommandAction : TriggerAction<UIElement>
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600034B RID: 843 RVA: 0x000089C2 File Offset: 0x00006BC2
		// (set) Token: 0x0600034C RID: 844 RVA: 0x000089D4 File Offset: 0x00006BD4
		public bool AutoEnable
		{
			get
			{
				return (bool)base.GetValue(InvokeCommandAction.AutoEnableProperty);
			}
			set
			{
				base.SetValue(InvokeCommandAction.AutoEnableProperty, value);
			}
		}

		// Token: 0x0600034D RID: 845 RVA: 0x000089E8 File Offset: 0x00006BE8
		private void OnAllowDisableChanged(bool newValue)
		{
			InvokeCommandAction.ExecutableCommandBehavior orCreateBehavior = this.GetOrCreateBehavior();
			if (orCreateBehavior != null)
			{
				orCreateBehavior.AutoEnable = newValue;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x0600034E RID: 846 RVA: 0x00008A06 File Offset: 0x00006C06
		// (set) Token: 0x0600034F RID: 847 RVA: 0x00008A18 File Offset: 0x00006C18
		public ICommand Command
		{
			get
			{
				return base.GetValue(InvokeCommandAction.CommandProperty) as ICommand;
			}
			set
			{
				base.SetValue(InvokeCommandAction.CommandProperty, value);
			}
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00008A28 File Offset: 0x00006C28
		private void OnCommandChanged(ICommand newValue)
		{
			InvokeCommandAction.ExecutableCommandBehavior orCreateBehavior = this.GetOrCreateBehavior();
			if (orCreateBehavior != null)
			{
				orCreateBehavior.Command = newValue;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000351 RID: 849 RVA: 0x00008A46 File Offset: 0x00006C46
		// (set) Token: 0x06000352 RID: 850 RVA: 0x00008A53 File Offset: 0x00006C53
		public object CommandParameter
		{
			get
			{
				return base.GetValue(InvokeCommandAction.CommandParameterProperty);
			}
			set
			{
				base.SetValue(InvokeCommandAction.CommandParameterProperty, value);
			}
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00008A64 File Offset: 0x00006C64
		private void OnCommandParameterChanged(object newValue)
		{
			InvokeCommandAction.ExecutableCommandBehavior orCreateBehavior = this.GetOrCreateBehavior();
			if (orCreateBehavior != null)
			{
				orCreateBehavior.CommandParameter = newValue;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000354 RID: 852 RVA: 0x00008A82 File Offset: 0x00006C82
		// (set) Token: 0x06000355 RID: 853 RVA: 0x00008A94 File Offset: 0x00006C94
		public string TriggerParameterPath
		{
			get
			{
				return base.GetValue(InvokeCommandAction.TriggerParameterPathProperty) as string;
			}
			set
			{
				base.SetValue(InvokeCommandAction.TriggerParameterPathProperty, value);
			}
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00008AA2 File Offset: 0x00006CA2
		public void InvokeAction(object parameter)
		{
			this.Invoke(parameter);
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00008AAC File Offset: 0x00006CAC
		protected override void Invoke(object parameter)
		{
			if (!string.IsNullOrEmpty(this.TriggerParameterPath))
			{
				string[] array = this.TriggerParameterPath.Split(new char[]
				{
					'.'
				});
				object obj = parameter;
				foreach (string name in array)
				{
					obj = obj.GetType().GetTypeInfo().GetProperty(name).GetValue(obj);
				}
				parameter = obj;
			}
			InvokeCommandAction.ExecutableCommandBehavior orCreateBehavior = this.GetOrCreateBehavior();
			if (orCreateBehavior != null)
			{
				orCreateBehavior.ExecuteCommand(parameter);
			}
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00008B1F File Offset: 0x00006D1F
		protected override void OnDetaching()
		{
			base.OnDetaching();
			this.Command = null;
			this.CommandParameter = null;
			this._commandBehavior = null;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00008B3C File Offset: 0x00006D3C
		protected override void OnAttached()
		{
			base.OnAttached();
			InvokeCommandAction.ExecutableCommandBehavior orCreateBehavior = this.GetOrCreateBehavior();
			orCreateBehavior.AutoEnable = this.AutoEnable;
			if (orCreateBehavior.Command != this.Command)
			{
				orCreateBehavior.Command = this.Command;
			}
			if (orCreateBehavior.CommandParameter != this.CommandParameter)
			{
				orCreateBehavior.CommandParameter = this.CommandParameter;
			}
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00008B96 File Offset: 0x00006D96
		private InvokeCommandAction.ExecutableCommandBehavior GetOrCreateBehavior()
		{
			if (this._commandBehavior == null && base.AssociatedObject != null)
			{
				this._commandBehavior = new InvokeCommandAction.ExecutableCommandBehavior(base.AssociatedObject);
			}
			return this._commandBehavior;
		}

		// Token: 0x0400009D RID: 157
		private InvokeCommandAction.ExecutableCommandBehavior _commandBehavior;

		// Token: 0x0400009E RID: 158
		public static readonly DependencyProperty AutoEnableProperty = DependencyProperty.Register("AutoEnable", typeof(bool), typeof(InvokeCommandAction), new PropertyMetadata(true, delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((InvokeCommandAction)d).OnAllowDisableChanged((bool)e.NewValue);
		}));

		// Token: 0x0400009F RID: 159
		public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(InvokeCommandAction), new PropertyMetadata(null, delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((InvokeCommandAction)d).OnCommandChanged((ICommand)e.NewValue);
		}));

		// Token: 0x040000A0 RID: 160
		public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(InvokeCommandAction), new PropertyMetadata(null, delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((InvokeCommandAction)d).OnCommandParameterChanged(e.NewValue);
		}));

		// Token: 0x040000A1 RID: 161
		public static readonly DependencyProperty TriggerParameterPathProperty = DependencyProperty.Register("TriggerParameterPath", typeof(string), typeof(InvokeCommandAction), new PropertyMetadata(null, delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}));

		// Token: 0x020000A8 RID: 168
		private class ExecutableCommandBehavior : CommandBehaviorBase<UIElement>
		{
			// Token: 0x0600044E RID: 1102 RVA: 0x0000A8F1 File Offset: 0x00008AF1
			public ExecutableCommandBehavior(UIElement target) : base(target)
			{
			}

			// Token: 0x0600044F RID: 1103 RVA: 0x0000A8FA File Offset: 0x00008AFA
			public new void ExecuteCommand(object parameter)
			{
				base.ExecuteCommand(parameter);
			}
		}
	}
}
