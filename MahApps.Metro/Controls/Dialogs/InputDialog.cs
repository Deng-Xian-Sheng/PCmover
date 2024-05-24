using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000A7 RID: 167
	public class InputDialog : BaseMetroDialog, IComponentConnector
	{
		// Token: 0x06000908 RID: 2312 RVA: 0x00024338 File Offset: 0x00022538
		internal InputDialog() : this(null)
		{
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x00024341 File Offset: 0x00022541
		internal InputDialog(MetroWindow parentWindow) : this(parentWindow, null)
		{
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x0002434B File Offset: 0x0002254B
		internal InputDialog(MetroWindow parentWindow, MetroDialogSettings settings) : base(parentWindow, settings)
		{
			this.InitializeComponent();
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x0002435C File Offset: 0x0002255C
		internal Task<string> WaitForButtonPressAsync()
		{
			base.Dispatcher.BeginInvoke(new Action(delegate()
			{
				this.Focus();
				this.PART_TextBox.Focus();
			}), Array.Empty<object>());
			TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
			RoutedEventHandler negativeHandler = null;
			KeyEventHandler negativeKeyHandler = null;
			RoutedEventHandler affirmativeHandler = null;
			KeyEventHandler affirmativeKeyHandler = null;
			KeyEventHandler escapeKeyHandler = null;
			Action cleanUpHandlers = null;
			CancellationTokenRegistration cancellationTokenRegistration = base.DialogSettings.CancellationToken.Register(delegate()
			{
				cleanUpHandlers();
				tcs.TrySetResult(null);
			});
			cleanUpHandlers = delegate()
			{
				this.PART_TextBox.KeyDown -= affirmativeKeyHandler;
				this.KeyDown -= escapeKeyHandler;
				this.PART_NegativeButton.Click -= negativeHandler;
				this.PART_AffirmativeButton.Click -= affirmativeHandler;
				this.PART_NegativeButton.KeyDown -= negativeKeyHandler;
				this.PART_AffirmativeButton.KeyDown -= affirmativeKeyHandler;
				cancellationTokenRegistration.Dispose();
			};
			escapeKeyHandler = delegate(object sender, KeyEventArgs e)
			{
				if (e.Key == Key.Escape)
				{
					cleanUpHandlers();
					tcs.TrySetResult(null);
				}
			};
			negativeKeyHandler = delegate(object sender, KeyEventArgs e)
			{
				if (e.Key == Key.Return)
				{
					cleanUpHandlers();
					tcs.TrySetResult(null);
				}
			};
			affirmativeKeyHandler = delegate(object sender, KeyEventArgs e)
			{
				if (e.Key == Key.Return)
				{
					cleanUpHandlers();
					tcs.TrySetResult(this.Input);
				}
			};
			negativeHandler = delegate(object sender, RoutedEventArgs e)
			{
				cleanUpHandlers();
				tcs.TrySetResult(null);
				e.Handled = true;
			};
			affirmativeHandler = delegate(object sender, RoutedEventArgs e)
			{
				cleanUpHandlers();
				tcs.TrySetResult(this.Input);
				e.Handled = true;
			};
			this.PART_NegativeButton.KeyDown += negativeKeyHandler;
			this.PART_AffirmativeButton.KeyDown += affirmativeKeyHandler;
			this.PART_TextBox.KeyDown += affirmativeKeyHandler;
			base.KeyDown += escapeKeyHandler;
			this.PART_NegativeButton.Click += negativeHandler;
			this.PART_AffirmativeButton.Click += affirmativeHandler;
			return tcs.Task;
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x000244C8 File Offset: 0x000226C8
		protected override void OnLoaded()
		{
			this.AffirmativeButtonText = base.DialogSettings.AffirmativeButtonText;
			this.NegativeButtonText = base.DialogSettings.NegativeButtonText;
			MetroDialogColorScheme colorScheme = base.DialogSettings.ColorScheme;
			if (colorScheme == MetroDialogColorScheme.Accented)
			{
				this.PART_NegativeButton.SetResourceReference(FrameworkElement.StyleProperty, "AccentedDialogHighlightedSquareButton");
				this.PART_TextBox.SetResourceReference(Control.ForegroundProperty, "BlackColorBrush");
				this.PART_TextBox.SetResourceReference(ControlsHelper.FocusBorderBrushProperty, "TextBoxFocusBorderBrush");
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x0600090D RID: 2317 RVA: 0x00024546 File Offset: 0x00022746
		// (set) Token: 0x0600090E RID: 2318 RVA: 0x00024558 File Offset: 0x00022758
		public string Message
		{
			get
			{
				return (string)base.GetValue(InputDialog.MessageProperty);
			}
			set
			{
				base.SetValue(InputDialog.MessageProperty, value);
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x0600090F RID: 2319 RVA: 0x00024566 File Offset: 0x00022766
		// (set) Token: 0x06000910 RID: 2320 RVA: 0x00024578 File Offset: 0x00022778
		public string Input
		{
			get
			{
				return (string)base.GetValue(InputDialog.InputProperty);
			}
			set
			{
				base.SetValue(InputDialog.InputProperty, value);
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x00024586 File Offset: 0x00022786
		// (set) Token: 0x06000912 RID: 2322 RVA: 0x00024598 File Offset: 0x00022798
		public string AffirmativeButtonText
		{
			get
			{
				return (string)base.GetValue(InputDialog.AffirmativeButtonTextProperty);
			}
			set
			{
				base.SetValue(InputDialog.AffirmativeButtonTextProperty, value);
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000913 RID: 2323 RVA: 0x000245A6 File Offset: 0x000227A6
		// (set) Token: 0x06000914 RID: 2324 RVA: 0x000245B8 File Offset: 0x000227B8
		public string NegativeButtonText
		{
			get
			{
				return (string)base.GetValue(InputDialog.NegativeButtonTextProperty);
			}
			set
			{
				base.SetValue(InputDialog.NegativeButtonTextProperty, value);
			}
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x000245C8 File Offset: 0x000227C8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/MahApps.Metro;component/themes/dialogs/inputdialog.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x000245F8 File Offset: 0x000227F8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x00024604 File Offset: 0x00022804
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.PART_TextBox = (TextBox)target;
				return;
			case 2:
				this.PART_AffirmativeButton = (Button)target;
				return;
			case 3:
				this.PART_NegativeButton = (Button)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040003F6 RID: 1014
		public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(InputDialog), new PropertyMetadata(null));

		// Token: 0x040003F7 RID: 1015
		public static readonly DependencyProperty InputProperty = DependencyProperty.Register("Input", typeof(string), typeof(InputDialog), new PropertyMetadata(null));

		// Token: 0x040003F8 RID: 1016
		public static readonly DependencyProperty AffirmativeButtonTextProperty = DependencyProperty.Register("AffirmativeButtonText", typeof(string), typeof(InputDialog), new PropertyMetadata("OK"));

		// Token: 0x040003F9 RID: 1017
		public static readonly DependencyProperty NegativeButtonTextProperty = DependencyProperty.Register("NegativeButtonText", typeof(string), typeof(InputDialog), new PropertyMetadata("Cancel"));

		// Token: 0x040003FA RID: 1018
		internal TextBox PART_TextBox;

		// Token: 0x040003FB RID: 1019
		internal Button PART_AffirmativeButton;

		// Token: 0x040003FC RID: 1020
		internal Button PART_NegativeButton;

		// Token: 0x040003FD RID: 1021
		private bool _contentLoaded;
	}
}
