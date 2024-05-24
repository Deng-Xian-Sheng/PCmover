using System;
using System.Windows;
using System.Windows.Input;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200003F RID: 63
	public class HamburgerMenuItem : Freezable, ICommandSource
	{
		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x0000BBF4 File Offset: 0x00009DF4
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x0000BC06 File Offset: 0x00009E06
		public string Label
		{
			get
			{
				return (string)base.GetValue(HamburgerMenuItem.LabelProperty);
			}
			set
			{
				base.SetValue(HamburgerMenuItem.LabelProperty, value);
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x0000BC14 File Offset: 0x00009E14
		// (set) Token: 0x060002AA RID: 682 RVA: 0x0000BC26 File Offset: 0x00009E26
		public Type TargetPageType
		{
			get
			{
				return (Type)base.GetValue(HamburgerMenuItem.TargetPageTypeProperty);
			}
			set
			{
				base.SetValue(HamburgerMenuItem.TargetPageTypeProperty, value);
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060002AB RID: 683 RVA: 0x0000BC34 File Offset: 0x00009E34
		// (set) Token: 0x060002AC RID: 684 RVA: 0x0000BC41 File Offset: 0x00009E41
		public object Tag
		{
			get
			{
				return base.GetValue(HamburgerMenuItem.TagProperty);
			}
			set
			{
				base.SetValue(HamburgerMenuItem.TagProperty, value);
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060002AD RID: 685 RVA: 0x0000BC4F File Offset: 0x00009E4F
		// (set) Token: 0x060002AE RID: 686 RVA: 0x0000BC61 File Offset: 0x00009E61
		public ICommand Command
		{
			get
			{
				return (ICommand)base.GetValue(HamburgerMenuItem.CommandProperty);
			}
			set
			{
				base.SetValue(HamburgerMenuItem.CommandProperty, value);
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060002AF RID: 687 RVA: 0x0000BC6F File Offset: 0x00009E6F
		// (set) Token: 0x060002B0 RID: 688 RVA: 0x0000BC7C File Offset: 0x00009E7C
		public object CommandParameter
		{
			get
			{
				return base.GetValue(HamburgerMenuItem.CommandParameterProperty);
			}
			set
			{
				base.SetValue(HamburgerMenuItem.CommandParameterProperty, value);
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x0000BC8A File Offset: 0x00009E8A
		// (set) Token: 0x060002B2 RID: 690 RVA: 0x0000BC9C File Offset: 0x00009E9C
		public IInputElement CommandTarget
		{
			get
			{
				return (IInputElement)base.GetValue(HamburgerMenuItem.CommandTargetProperty);
			}
			set
			{
				base.SetValue(HamburgerMenuItem.CommandTargetProperty, value);
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x0000BCAA File Offset: 0x00009EAA
		// (set) Token: 0x060002B4 RID: 692 RVA: 0x0000BCBC File Offset: 0x00009EBC
		public bool IsEnabled
		{
			get
			{
				return (bool)base.GetValue(HamburgerMenuItem.IsEnabledProperty);
			}
			set
			{
				base.SetValue(HamburgerMenuItem.IsEnabledProperty, value);
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x0000BCCF File Offset: 0x00009ECF
		// (set) Token: 0x060002B6 RID: 694 RVA: 0x0000BCDC File Offset: 0x00009EDC
		public object ToolTip
		{
			get
			{
				return base.GetValue(HamburgerMenuItem.ToolTipProperty);
			}
			set
			{
				base.SetValue(HamburgerMenuItem.ToolTipProperty, value);
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000BCEA File Offset: 0x00009EEA
		public void RaiseCommand()
		{
			CommandHelpers.ExecuteCommandSource(this);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000BCF2 File Offset: 0x00009EF2
		private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((HamburgerMenuItem)d).OnCommandChanged((ICommand)e.OldValue, (ICommand)e.NewValue);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000BD17 File Offset: 0x00009F17
		private void OnCommandChanged(ICommand oldCommand, ICommand newCommand)
		{
			if (oldCommand != null)
			{
				this.UnhookCommand(oldCommand);
			}
			if (newCommand != null)
			{
				this.HookCommand(newCommand);
			}
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000BD2D File Offset: 0x00009F2D
		private void UnhookCommand(ICommand command)
		{
			CanExecuteChangedEventManager.RemoveHandler(command, new EventHandler<EventArgs>(this.OnCanExecuteChanged));
			this.UpdateCanExecute();
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000BD47 File Offset: 0x00009F47
		private void HookCommand(ICommand command)
		{
			CanExecuteChangedEventManager.AddHandler(command, new EventHandler<EventArgs>(this.OnCanExecuteChanged));
			this.UpdateCanExecute();
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000BD61 File Offset: 0x00009F61
		private void OnCanExecuteChanged(object sender, EventArgs e)
		{
			this.UpdateCanExecute();
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000BD69 File Offset: 0x00009F69
		private void UpdateCanExecute()
		{
			if (this.Command != null)
			{
				this.CanExecute = CommandHelpers.CanExecuteCommandSource(this);
				return;
			}
			this.CanExecute = true;
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000BD87 File Offset: 0x00009F87
		private static object IsEnabledCoerceValueCallback(DependencyObject d, object value)
		{
			if (!(bool)value)
			{
				return false;
			}
			return ((HamburgerMenuItem)d).CanExecute;
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002BF RID: 703 RVA: 0x0000BDA8 File Offset: 0x00009FA8
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x0000BDB0 File Offset: 0x00009FB0
		private bool CanExecute
		{
			get
			{
				return this.canExecute;
			}
			set
			{
				if (value == this.canExecute)
				{
					return;
				}
				this.canExecute = value;
				base.CoerceValue(HamburgerMenuItem.IsEnabledProperty);
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000BDCE File Offset: 0x00009FCE
		protected override Freezable CreateInstanceCore()
		{
			return new HamburgerMenuItem();
		}

		// Token: 0x040000FF RID: 255
		public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(HamburgerMenuItem), new PropertyMetadata(null));

		// Token: 0x04000100 RID: 256
		public static readonly DependencyProperty TargetPageTypeProperty = DependencyProperty.Register("TargetPageType", typeof(Type), typeof(HamburgerMenuItem), new PropertyMetadata(null));

		// Token: 0x04000101 RID: 257
		public static readonly DependencyProperty TagProperty = DependencyProperty.Register("Tag", typeof(object), typeof(HamburgerMenuItem), new PropertyMetadata(null));

		// Token: 0x04000102 RID: 258
		public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(HamburgerMenuItem), new PropertyMetadata(null, new PropertyChangedCallback(HamburgerMenuItem.OnCommandChanged)));

		// Token: 0x04000103 RID: 259
		public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(HamburgerMenuItem), new PropertyMetadata(null));

		// Token: 0x04000104 RID: 260
		public static readonly DependencyProperty CommandTargetProperty = DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(HamburgerMenuItem), new PropertyMetadata(null));

		// Token: 0x04000105 RID: 261
		public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.Register("IsEnabled", typeof(bool), typeof(HamburgerMenuItem), new PropertyMetadata(true, null, new CoerceValueCallback(HamburgerMenuItem.IsEnabledCoerceValueCallback)));

		// Token: 0x04000106 RID: 262
		public static readonly DependencyProperty ToolTipProperty = DependencyProperty.Register("ToolTip", typeof(object), typeof(HamburgerMenuItem), new PropertyMetadata(null));

		// Token: 0x04000107 RID: 263
		private bool canExecute;
	}
}
