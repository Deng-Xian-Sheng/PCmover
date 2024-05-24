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
using ControlzEx;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000AB RID: 171
	public class MessageDialog : BaseMetroDialog, IComponentConnector
	{
		// Token: 0x06000959 RID: 2393 RVA: 0x00025020 File Offset: 0x00023220
		internal MessageDialog() : this(null)
		{
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x00025029 File Offset: 0x00023229
		internal MessageDialog(MetroWindow parentWindow) : this(parentWindow, null)
		{
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x00025033 File Offset: 0x00023233
		internal MessageDialog(MetroWindow parentWindow, MetroDialogSettings settings) : base(parentWindow, settings)
		{
			this.InitializeComponent();
			this.PART_MessageScrollViewer.Height = base.DialogSettings.MaximumBodyHeight;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0002505C File Offset: 0x0002325C
		internal Task<MessageDialogResult> WaitForButtonPressAsync()
		{
			base.Dispatcher.BeginInvoke(new Action(delegate()
			{
				this.Focus();
				MessageDialogResult value = this.DialogSettings.DefaultButtonFocus;
				if (!this.IsApplicable(value))
				{
					value = ((this.ButtonStyle == MessageDialogStyle.Affirmative) ? MessageDialogResult.Affirmative : MessageDialogResult.Negative);
				}
				switch (value)
				{
				case MessageDialogResult.Negative:
					this.PART_NegativeButton.SetResourceReference(FrameworkElement.StyleProperty, "AccentedDialogSquareButton");
					KeyboardNavigationEx.Focus(this.PART_NegativeButton);
					return;
				case MessageDialogResult.Affirmative:
					this.PART_AffirmativeButton.SetResourceReference(FrameworkElement.StyleProperty, "AccentedDialogSquareButton");
					KeyboardNavigationEx.Focus(this.PART_AffirmativeButton);
					return;
				case MessageDialogResult.FirstAuxiliary:
					this.PART_FirstAuxiliaryButton.SetResourceReference(FrameworkElement.StyleProperty, "AccentedDialogSquareButton");
					KeyboardNavigationEx.Focus(this.PART_FirstAuxiliaryButton);
					return;
				case MessageDialogResult.SecondAuxiliary:
					this.PART_SecondAuxiliaryButton.SetResourceReference(FrameworkElement.StyleProperty, "AccentedDialogSquareButton");
					KeyboardNavigationEx.Focus(this.PART_SecondAuxiliaryButton);
					return;
				default:
					return;
				}
			}), Array.Empty<object>());
			TaskCompletionSource<MessageDialogResult> tcs = new TaskCompletionSource<MessageDialogResult>();
			RoutedEventHandler negativeHandler = null;
			KeyEventHandler negativeKeyHandler = null;
			RoutedEventHandler affirmativeHandler = null;
			KeyEventHandler affirmativeKeyHandler = null;
			RoutedEventHandler firstAuxHandler = null;
			KeyEventHandler firstAuxKeyHandler = null;
			RoutedEventHandler secondAuxHandler = null;
			KeyEventHandler secondAuxKeyHandler = null;
			KeyEventHandler escapeKeyHandler = null;
			Action cleanUpHandlers = null;
			CancellationTokenRegistration cancellationTokenRegistration = base.DialogSettings.CancellationToken.Register(delegate()
			{
				Action cleanUpHandlers = cleanUpHandlers;
				if (cleanUpHandlers != null)
				{
					cleanUpHandlers();
				}
				tcs.TrySetResult((this.ButtonStyle == MessageDialogStyle.Affirmative) ? MessageDialogResult.Affirmative : MessageDialogResult.Negative);
			});
			cleanUpHandlers = delegate()
			{
				this.PART_NegativeButton.Click -= negativeHandler;
				this.PART_AffirmativeButton.Click -= affirmativeHandler;
				this.PART_FirstAuxiliaryButton.Click -= firstAuxHandler;
				this.PART_SecondAuxiliaryButton.Click -= secondAuxHandler;
				this.PART_NegativeButton.KeyDown -= negativeKeyHandler;
				this.PART_AffirmativeButton.KeyDown -= affirmativeKeyHandler;
				this.PART_FirstAuxiliaryButton.KeyDown -= firstAuxKeyHandler;
				this.PART_SecondAuxiliaryButton.KeyDown -= secondAuxKeyHandler;
				this.KeyDown -= escapeKeyHandler;
				cancellationTokenRegistration.Dispose();
			};
			negativeKeyHandler = delegate(object sender, KeyEventArgs e)
			{
				if (e.Key == Key.Return)
				{
					cleanUpHandlers();
					tcs.TrySetResult(MessageDialogResult.Negative);
				}
			};
			affirmativeKeyHandler = delegate(object sender, KeyEventArgs e)
			{
				if (e.Key == Key.Return)
				{
					cleanUpHandlers();
					tcs.TrySetResult(MessageDialogResult.Affirmative);
				}
			};
			firstAuxKeyHandler = delegate(object sender, KeyEventArgs e)
			{
				if (e.Key == Key.Return)
				{
					cleanUpHandlers();
					tcs.TrySetResult(MessageDialogResult.FirstAuxiliary);
				}
			};
			secondAuxKeyHandler = delegate(object sender, KeyEventArgs e)
			{
				if (e.Key == Key.Return)
				{
					cleanUpHandlers();
					tcs.TrySetResult(MessageDialogResult.SecondAuxiliary);
				}
			};
			negativeHandler = delegate(object sender, RoutedEventArgs e)
			{
				cleanUpHandlers();
				tcs.TrySetResult(MessageDialogResult.Negative);
				e.Handled = true;
			};
			affirmativeHandler = delegate(object sender, RoutedEventArgs e)
			{
				cleanUpHandlers();
				tcs.TrySetResult(MessageDialogResult.Affirmative);
				e.Handled = true;
			};
			firstAuxHandler = delegate(object sender, RoutedEventArgs e)
			{
				cleanUpHandlers();
				tcs.TrySetResult(MessageDialogResult.FirstAuxiliary);
				e.Handled = true;
			};
			secondAuxHandler = delegate(object sender, RoutedEventArgs e)
			{
				cleanUpHandlers();
				tcs.TrySetResult(MessageDialogResult.SecondAuxiliary);
				e.Handled = true;
			};
			escapeKeyHandler = delegate(object sender, KeyEventArgs e)
			{
				if (e.Key == Key.Escape)
				{
					cleanUpHandlers();
					tcs.TrySetResult(this.DialogSettings.DialogResultOnCancel ?? ((this.ButtonStyle == MessageDialogStyle.Affirmative) ? MessageDialogResult.Affirmative : MessageDialogResult.Negative));
					return;
				}
				if (e.Key == Key.Return)
				{
					cleanUpHandlers();
					tcs.TrySetResult(MessageDialogResult.Affirmative);
				}
			};
			this.PART_NegativeButton.KeyDown += negativeKeyHandler;
			this.PART_AffirmativeButton.KeyDown += affirmativeKeyHandler;
			this.PART_FirstAuxiliaryButton.KeyDown += firstAuxKeyHandler;
			this.PART_SecondAuxiliaryButton.KeyDown += secondAuxKeyHandler;
			this.PART_NegativeButton.Click += negativeHandler;
			this.PART_AffirmativeButton.Click += affirmativeHandler;
			this.PART_FirstAuxiliaryButton.Click += firstAuxHandler;
			this.PART_SecondAuxiliaryButton.Click += secondAuxHandler;
			base.KeyDown += escapeKeyHandler;
			return tcs.Task;
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0002525C File Offset: 0x0002345C
		private static void ButtonStylePropertyChangedCallback(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			MessageDialog.SetButtonState((MessageDialog)s);
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0002526C File Offset: 0x0002346C
		private static void SetButtonState(MessageDialog md)
		{
			if (md.PART_AffirmativeButton == null)
			{
				return;
			}
			MessageDialogStyle buttonStyle = md.ButtonStyle;
			if (buttonStyle != MessageDialogStyle.Affirmative)
			{
				if (buttonStyle - MessageDialogStyle.AffirmativeAndNegative <= 2)
				{
					md.PART_AffirmativeButton.Visibility = Visibility.Visible;
					md.PART_NegativeButton.Visibility = Visibility.Visible;
					if (md.ButtonStyle == MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary || md.ButtonStyle == MessageDialogStyle.AffirmativeAndNegativeAndDoubleAuxiliary)
					{
						md.PART_FirstAuxiliaryButton.Visibility = Visibility.Visible;
					}
					if (md.ButtonStyle == MessageDialogStyle.AffirmativeAndNegativeAndDoubleAuxiliary)
					{
						md.PART_SecondAuxiliaryButton.Visibility = Visibility.Visible;
					}
				}
			}
			else
			{
				md.PART_AffirmativeButton.Visibility = Visibility.Visible;
				md.PART_NegativeButton.Visibility = Visibility.Collapsed;
				md.PART_FirstAuxiliaryButton.Visibility = Visibility.Collapsed;
				md.PART_SecondAuxiliaryButton.Visibility = Visibility.Collapsed;
			}
			md.AffirmativeButtonText = md.DialogSettings.AffirmativeButtonText;
			md.NegativeButtonText = md.DialogSettings.NegativeButtonText;
			md.FirstAuxiliaryButtonText = md.DialogSettings.FirstAuxiliaryButtonText;
			md.SecondAuxiliaryButtonText = md.DialogSettings.SecondAuxiliaryButtonText;
			MetroDialogColorScheme colorScheme = md.DialogSettings.ColorScheme;
			if (colorScheme == MetroDialogColorScheme.Accented)
			{
				md.PART_AffirmativeButton.SetResourceReference(FrameworkElement.StyleProperty, "AccentedDialogHighlightedSquareButton");
				md.PART_NegativeButton.SetResourceReference(FrameworkElement.StyleProperty, "AccentedDialogHighlightedSquareButton");
				md.PART_FirstAuxiliaryButton.SetResourceReference(FrameworkElement.StyleProperty, "AccentedDialogHighlightedSquareButton");
				md.PART_SecondAuxiliaryButton.SetResourceReference(FrameworkElement.StyleProperty, "AccentedDialogHighlightedSquareButton");
			}
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x000253B9 File Offset: 0x000235B9
		protected override void OnLoaded()
		{
			MessageDialog.SetButtonState(this);
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000960 RID: 2400 RVA: 0x000253C1 File Offset: 0x000235C1
		// (set) Token: 0x06000961 RID: 2401 RVA: 0x000253D3 File Offset: 0x000235D3
		public MessageDialogStyle ButtonStyle
		{
			get
			{
				return (MessageDialogStyle)base.GetValue(MessageDialog.ButtonStyleProperty);
			}
			set
			{
				base.SetValue(MessageDialog.ButtonStyleProperty, value);
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x000253E6 File Offset: 0x000235E6
		// (set) Token: 0x06000963 RID: 2403 RVA: 0x000253F8 File Offset: 0x000235F8
		public string Message
		{
			get
			{
				return (string)base.GetValue(MessageDialog.MessageProperty);
			}
			set
			{
				base.SetValue(MessageDialog.MessageProperty, value);
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x00025406 File Offset: 0x00023606
		// (set) Token: 0x06000965 RID: 2405 RVA: 0x00025418 File Offset: 0x00023618
		public string AffirmativeButtonText
		{
			get
			{
				return (string)base.GetValue(MessageDialog.AffirmativeButtonTextProperty);
			}
			set
			{
				base.SetValue(MessageDialog.AffirmativeButtonTextProperty, value);
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000966 RID: 2406 RVA: 0x00025426 File Offset: 0x00023626
		// (set) Token: 0x06000967 RID: 2407 RVA: 0x00025438 File Offset: 0x00023638
		public string NegativeButtonText
		{
			get
			{
				return (string)base.GetValue(MessageDialog.NegativeButtonTextProperty);
			}
			set
			{
				base.SetValue(MessageDialog.NegativeButtonTextProperty, value);
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x00025446 File Offset: 0x00023646
		// (set) Token: 0x06000969 RID: 2409 RVA: 0x00025458 File Offset: 0x00023658
		public string FirstAuxiliaryButtonText
		{
			get
			{
				return (string)base.GetValue(MessageDialog.FirstAuxiliaryButtonTextProperty);
			}
			set
			{
				base.SetValue(MessageDialog.FirstAuxiliaryButtonTextProperty, value);
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x0600096A RID: 2410 RVA: 0x00025466 File Offset: 0x00023666
		// (set) Token: 0x0600096B RID: 2411 RVA: 0x00025478 File Offset: 0x00023678
		public string SecondAuxiliaryButtonText
		{
			get
			{
				return (string)base.GetValue(MessageDialog.SecondAuxiliaryButtonTextProperty);
			}
			set
			{
				base.SetValue(MessageDialog.SecondAuxiliaryButtonTextProperty, value);
			}
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x00025486 File Offset: 0x00023686
		private void OnKeyCopyExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			Clipboard.SetDataObject(this.Message);
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x00025494 File Offset: 0x00023694
		private bool IsApplicable(MessageDialogResult value)
		{
			switch (value)
			{
			case MessageDialogResult.Negative:
				return this.PART_NegativeButton.IsVisible;
			case MessageDialogResult.Affirmative:
				return this.PART_AffirmativeButton.IsVisible;
			case MessageDialogResult.FirstAuxiliary:
				return this.PART_FirstAuxiliaryButton.IsVisible;
			case MessageDialogResult.SecondAuxiliary:
				return this.PART_SecondAuxiliaryButton.IsVisible;
			default:
				return false;
			}
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x000254EC File Offset: 0x000236EC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/MahApps.Metro;component/themes/dialogs/messagedialog.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0002551C File Offset: 0x0002371C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((CommandBinding)target).Executed += this.OnKeyCopyExecuted;
				return;
			case 2:
				this.PART_MessageScrollViewer = (ScrollViewer)target;
				return;
			case 3:
				this.PART_MessageTextBlock = (TextBlock)target;
				return;
			case 4:
				this.PART_AffirmativeButton = (Button)target;
				return;
			case 5:
				this.PART_NegativeButton = (Button)target;
				return;
			case 6:
				this.PART_FirstAuxiliaryButton = (Button)target;
				return;
			case 7:
				this.PART_SecondAuxiliaryButton = (Button)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000421 RID: 1057
		public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(MessageDialog), new PropertyMetadata(null));

		// Token: 0x04000422 RID: 1058
		public static readonly DependencyProperty AffirmativeButtonTextProperty = DependencyProperty.Register("AffirmativeButtonText", typeof(string), typeof(MessageDialog), new PropertyMetadata("OK"));

		// Token: 0x04000423 RID: 1059
		public static readonly DependencyProperty NegativeButtonTextProperty = DependencyProperty.Register("NegativeButtonText", typeof(string), typeof(MessageDialog), new PropertyMetadata("Cancel"));

		// Token: 0x04000424 RID: 1060
		public static readonly DependencyProperty FirstAuxiliaryButtonTextProperty = DependencyProperty.Register("FirstAuxiliaryButtonText", typeof(string), typeof(MessageDialog), new PropertyMetadata("Cancel"));

		// Token: 0x04000425 RID: 1061
		public static readonly DependencyProperty SecondAuxiliaryButtonTextProperty = DependencyProperty.Register("SecondAuxiliaryButtonText", typeof(string), typeof(MessageDialog), new PropertyMetadata("Cancel"));

		// Token: 0x04000426 RID: 1062
		public static readonly DependencyProperty ButtonStyleProperty = DependencyProperty.Register("ButtonStyle", typeof(MessageDialogStyle), typeof(MessageDialog), new PropertyMetadata(MessageDialogStyle.Affirmative, new PropertyChangedCallback(MessageDialog.ButtonStylePropertyChangedCallback)));

		// Token: 0x04000427 RID: 1063
		internal ScrollViewer PART_MessageScrollViewer;

		// Token: 0x04000428 RID: 1064
		internal TextBlock PART_MessageTextBlock;

		// Token: 0x04000429 RID: 1065
		internal Button PART_AffirmativeButton;

		// Token: 0x0400042A RID: 1066
		internal Button PART_NegativeButton;

		// Token: 0x0400042B RID: 1067
		internal Button PART_FirstAuxiliaryButton;

		// Token: 0x0400042C RID: 1068
		internal Button PART_SecondAuxiliaryButton;

		// Token: 0x0400042D RID: 1069
		private bool _contentLoaded;
	}
}
