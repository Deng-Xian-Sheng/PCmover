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
	// Token: 0x020000A8 RID: 168
	public class LoginDialog : BaseMetroDialog, IComponentConnector
	{
		// Token: 0x06000919 RID: 2329 RVA: 0x00024711 File Offset: 0x00022911
		internal LoginDialog() : this(null)
		{
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x0002471A File Offset: 0x0002291A
		internal LoginDialog(MetroWindow parentWindow) : this(parentWindow, null)
		{
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00024724 File Offset: 0x00022924
		internal LoginDialog(MetroWindow parentWindow, LoginDialogSettings settings) : base(parentWindow, settings)
		{
			this.InitializeComponent();
			this.Username = settings.InitialUsername;
			this.Password = settings.InitialPassword;
			this.UsernameCharacterCasing = settings.UsernameCharacterCasing;
			this.UsernameWatermark = settings.UsernameWatermark;
			this.PasswordWatermark = settings.PasswordWatermark;
			this.NegativeButtonButtonVisibility = settings.NegativeButtonVisibility;
			this.ShouldHideUsername = settings.ShouldHideUsername;
			this.RememberCheckBoxVisibility = settings.RememberCheckBoxVisibility;
			this.RememberCheckBoxText = settings.RememberCheckBoxText;
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x000247AC File Offset: 0x000229AC
		internal Task<LoginDialogData> WaitForButtonPressAsync()
		{
			base.Dispatcher.BeginInvoke(new Action(delegate()
			{
				this.Focus();
				if (string.IsNullOrEmpty(this.PART_TextBox.Text) && !this.ShouldHideUsername)
				{
					this.PART_TextBox.Focus();
					return;
				}
				this.PART_TextBox2.Focus();
			}), Array.Empty<object>());
			TaskCompletionSource<LoginDialogData> tcs = new TaskCompletionSource<LoginDialogData>();
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
				this.PART_TextBox2.KeyDown -= affirmativeKeyHandler;
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
					tcs.TrySetResult(new LoginDialogData
					{
						Username = this.Username,
						SecurePassword = this.PART_TextBox2.SecurePassword,
						ShouldRemember = this.RememberCheckBoxChecked
					});
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
				tcs.TrySetResult(new LoginDialogData
				{
					Username = this.Username,
					SecurePassword = this.PART_TextBox2.SecurePassword,
					ShouldRemember = this.RememberCheckBoxChecked
				});
				e.Handled = true;
			};
			this.PART_NegativeButton.KeyDown += negativeKeyHandler;
			this.PART_AffirmativeButton.KeyDown += affirmativeKeyHandler;
			this.PART_TextBox.KeyDown += affirmativeKeyHandler;
			this.PART_TextBox2.KeyDown += affirmativeKeyHandler;
			base.KeyDown += escapeKeyHandler;
			this.PART_NegativeButton.Click += negativeHandler;
			this.PART_AffirmativeButton.Click += affirmativeHandler;
			return tcs.Task;
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x00024928 File Offset: 0x00022B28
		protected override void OnLoaded()
		{
			LoginDialogSettings loginDialogSettings = base.DialogSettings as LoginDialogSettings;
			if (loginDialogSettings != null && loginDialogSettings.EnablePasswordPreview)
			{
				Style style = base.FindResource("Win8MetroPasswordBox") as Style;
				if (style != null)
				{
					this.PART_TextBox2.Style = style;
					this.PART_TextBox2.ApplyTemplate();
				}
			}
			this.AffirmativeButtonText = base.DialogSettings.AffirmativeButtonText;
			this.NegativeButtonText = base.DialogSettings.NegativeButtonText;
			MetroDialogColorScheme colorScheme = base.DialogSettings.ColorScheme;
			if (colorScheme == MetroDialogColorScheme.Accented)
			{
				this.PART_NegativeButton.SetResourceReference(FrameworkElement.StyleProperty, "AccentedDialogHighlightedSquareButton");
				this.PART_TextBox.SetResourceReference(Control.ForegroundProperty, "BlackColorBrush");
				this.PART_TextBox2.SetResourceReference(Control.ForegroundProperty, "BlackColorBrush");
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x0600091E RID: 2334 RVA: 0x000249E9 File Offset: 0x00022BE9
		// (set) Token: 0x0600091F RID: 2335 RVA: 0x000249FB File Offset: 0x00022BFB
		public string Message
		{
			get
			{
				return (string)base.GetValue(LoginDialog.MessageProperty);
			}
			set
			{
				base.SetValue(LoginDialog.MessageProperty, value);
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000920 RID: 2336 RVA: 0x00024A09 File Offset: 0x00022C09
		// (set) Token: 0x06000921 RID: 2337 RVA: 0x00024A1B File Offset: 0x00022C1B
		public string Username
		{
			get
			{
				return (string)base.GetValue(LoginDialog.UsernameProperty);
			}
			set
			{
				base.SetValue(LoginDialog.UsernameProperty, value);
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000922 RID: 2338 RVA: 0x00024A29 File Offset: 0x00022C29
		// (set) Token: 0x06000923 RID: 2339 RVA: 0x00024A3B File Offset: 0x00022C3B
		public string Password
		{
			get
			{
				return (string)base.GetValue(LoginDialog.PasswordProperty);
			}
			set
			{
				base.SetValue(LoginDialog.PasswordProperty, value);
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000924 RID: 2340 RVA: 0x00024A49 File Offset: 0x00022C49
		// (set) Token: 0x06000925 RID: 2341 RVA: 0x00024A5B File Offset: 0x00022C5B
		public string UsernameWatermark
		{
			get
			{
				return (string)base.GetValue(LoginDialog.UsernameWatermarkProperty);
			}
			set
			{
				base.SetValue(LoginDialog.UsernameWatermarkProperty, value);
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000926 RID: 2342 RVA: 0x00024A69 File Offset: 0x00022C69
		// (set) Token: 0x06000927 RID: 2343 RVA: 0x00024A7B File Offset: 0x00022C7B
		public CharacterCasing UsernameCharacterCasing
		{
			get
			{
				return (CharacterCasing)base.GetValue(LoginDialog.UsernameCharacterCasingProperty);
			}
			set
			{
				base.SetValue(LoginDialog.UsernameCharacterCasingProperty, value);
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000928 RID: 2344 RVA: 0x00024A8E File Offset: 0x00022C8E
		// (set) Token: 0x06000929 RID: 2345 RVA: 0x00024AA0 File Offset: 0x00022CA0
		public string PasswordWatermark
		{
			get
			{
				return (string)base.GetValue(LoginDialog.PasswordWatermarkProperty);
			}
			set
			{
				base.SetValue(LoginDialog.PasswordWatermarkProperty, value);
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x0600092A RID: 2346 RVA: 0x00024AAE File Offset: 0x00022CAE
		// (set) Token: 0x0600092B RID: 2347 RVA: 0x00024AC0 File Offset: 0x00022CC0
		public string AffirmativeButtonText
		{
			get
			{
				return (string)base.GetValue(LoginDialog.AffirmativeButtonTextProperty);
			}
			set
			{
				base.SetValue(LoginDialog.AffirmativeButtonTextProperty, value);
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x0600092C RID: 2348 RVA: 0x00024ACE File Offset: 0x00022CCE
		// (set) Token: 0x0600092D RID: 2349 RVA: 0x00024AE0 File Offset: 0x00022CE0
		public string NegativeButtonText
		{
			get
			{
				return (string)base.GetValue(LoginDialog.NegativeButtonTextProperty);
			}
			set
			{
				base.SetValue(LoginDialog.NegativeButtonTextProperty, value);
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x0600092E RID: 2350 RVA: 0x00024AEE File Offset: 0x00022CEE
		// (set) Token: 0x0600092F RID: 2351 RVA: 0x00024B00 File Offset: 0x00022D00
		public Visibility NegativeButtonButtonVisibility
		{
			get
			{
				return (Visibility)base.GetValue(LoginDialog.NegativeButtonButtonVisibilityProperty);
			}
			set
			{
				base.SetValue(LoginDialog.NegativeButtonButtonVisibilityProperty, value);
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000930 RID: 2352 RVA: 0x00024B13 File Offset: 0x00022D13
		// (set) Token: 0x06000931 RID: 2353 RVA: 0x00024B25 File Offset: 0x00022D25
		public bool ShouldHideUsername
		{
			get
			{
				return (bool)base.GetValue(LoginDialog.ShouldHideUsernameProperty);
			}
			set
			{
				base.SetValue(LoginDialog.ShouldHideUsernameProperty, value);
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000932 RID: 2354 RVA: 0x00024B38 File Offset: 0x00022D38
		// (set) Token: 0x06000933 RID: 2355 RVA: 0x00024B4A File Offset: 0x00022D4A
		public Visibility RememberCheckBoxVisibility
		{
			get
			{
				return (Visibility)base.GetValue(LoginDialog.RememberCheckBoxVisibilityProperty);
			}
			set
			{
				base.SetValue(LoginDialog.RememberCheckBoxVisibilityProperty, value);
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000934 RID: 2356 RVA: 0x00024B5D File Offset: 0x00022D5D
		// (set) Token: 0x06000935 RID: 2357 RVA: 0x00024B6F File Offset: 0x00022D6F
		public string RememberCheckBoxText
		{
			get
			{
				return (string)base.GetValue(LoginDialog.RememberCheckBoxTextProperty);
			}
			set
			{
				base.SetValue(LoginDialog.RememberCheckBoxTextProperty, value);
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000936 RID: 2358 RVA: 0x00024B7D File Offset: 0x00022D7D
		// (set) Token: 0x06000937 RID: 2359 RVA: 0x00024B8F File Offset: 0x00022D8F
		public bool RememberCheckBoxChecked
		{
			get
			{
				return (bool)base.GetValue(LoginDialog.RememberCheckBoxCheckedProperty);
			}
			set
			{
				base.SetValue(LoginDialog.RememberCheckBoxCheckedProperty, value);
			}
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x00024BA4 File Offset: 0x00022DA4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/MahApps.Metro;component/themes/dialogs/logindialog.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x00024BD4 File Offset: 0x00022DD4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00024BE0 File Offset: 0x00022DE0
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
				this.PART_TextBox2 = (PasswordBox)target;
				return;
			case 3:
				this.PART_RememberCheckBox = (CheckBox)target;
				return;
			case 4:
				this.PART_AffirmativeButton = (Button)target;
				return;
			case 5:
				this.PART_NegativeButton = (Button)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040003FE RID: 1022
		public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(LoginDialog), new PropertyMetadata(null));

		// Token: 0x040003FF RID: 1023
		public static readonly DependencyProperty UsernameProperty = DependencyProperty.Register("Username", typeof(string), typeof(LoginDialog), new PropertyMetadata(null));

		// Token: 0x04000400 RID: 1024
		public static readonly DependencyProperty UsernameWatermarkProperty = DependencyProperty.Register("UsernameWatermark", typeof(string), typeof(LoginDialog), new PropertyMetadata(null));

		// Token: 0x04000401 RID: 1025
		public static readonly DependencyProperty UsernameCharacterCasingProperty = DependencyProperty.Register("UsernameCharacterCasing", typeof(CharacterCasing), typeof(LoginDialog), new PropertyMetadata(CharacterCasing.Normal));

		// Token: 0x04000402 RID: 1026
		public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(LoginDialog), new PropertyMetadata(null));

		// Token: 0x04000403 RID: 1027
		public static readonly DependencyProperty PasswordWatermarkProperty = DependencyProperty.Register("PasswordWatermark", typeof(string), typeof(LoginDialog), new PropertyMetadata(null));

		// Token: 0x04000404 RID: 1028
		public static readonly DependencyProperty AffirmativeButtonTextProperty = DependencyProperty.Register("AffirmativeButtonText", typeof(string), typeof(LoginDialog), new PropertyMetadata("OK"));

		// Token: 0x04000405 RID: 1029
		public static readonly DependencyProperty NegativeButtonTextProperty = DependencyProperty.Register("NegativeButtonText", typeof(string), typeof(LoginDialog), new PropertyMetadata("Cancel"));

		// Token: 0x04000406 RID: 1030
		public static readonly DependencyProperty NegativeButtonButtonVisibilityProperty = DependencyProperty.Register("NegativeButtonButtonVisibility", typeof(Visibility), typeof(LoginDialog), new PropertyMetadata(Visibility.Collapsed));

		// Token: 0x04000407 RID: 1031
		public static readonly DependencyProperty ShouldHideUsernameProperty = DependencyProperty.Register("ShouldHideUsername", typeof(bool), typeof(LoginDialog), new PropertyMetadata(false));

		// Token: 0x04000408 RID: 1032
		public static readonly DependencyProperty RememberCheckBoxVisibilityProperty = DependencyProperty.Register("RememberCheckBoxVisibility", typeof(Visibility), typeof(LoginDialog), new PropertyMetadata(Visibility.Collapsed));

		// Token: 0x04000409 RID: 1033
		public static readonly DependencyProperty RememberCheckBoxTextProperty = DependencyProperty.Register("RememberCheckBoxText", typeof(string), typeof(LoginDialog), new PropertyMetadata("Remember"));

		// Token: 0x0400040A RID: 1034
		public static readonly DependencyProperty RememberCheckBoxCheckedProperty = DependencyProperty.Register("RememberCheckBoxChecked", typeof(bool), typeof(LoginDialog), new PropertyMetadata(false));

		// Token: 0x0400040B RID: 1035
		internal TextBox PART_TextBox;

		// Token: 0x0400040C RID: 1036
		internal PasswordBox PART_TextBox2;

		// Token: 0x0400040D RID: 1037
		internal CheckBox PART_RememberCheckBox;

		// Token: 0x0400040E RID: 1038
		internal Button PART_AffirmativeButton;

		// Token: 0x0400040F RID: 1039
		internal Button PART_NegativeButton;

		// Token: 0x04000410 RID: 1040
		private bool _contentLoaded;
	}
}
