using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000B1 RID: 177
	public class ProgressDialog : BaseMetroDialog, IComponentConnector
	{
		// Token: 0x06000998 RID: 2456 RVA: 0x00025919 File Offset: 0x00023B19
		internal ProgressDialog() : this(null)
		{
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x00025922 File Offset: 0x00023B22
		internal ProgressDialog(MetroWindow parentWindow) : this(parentWindow, null)
		{
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0002592C File Offset: 0x00023B2C
		internal ProgressDialog(MetroWindow parentWindow, MetroDialogSettings settings) : base(parentWindow, settings)
		{
			this.InitializeComponent();
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0002593C File Offset: 0x00023B3C
		protected override void OnLoaded()
		{
			this.NegativeButtonText = base.DialogSettings.NegativeButtonText;
			base.SetResourceReference(ProgressDialog.ProgressBarForegroundProperty, (base.DialogSettings.ColorScheme == MetroDialogColorScheme.Theme) ? "AccentColorBrush" : "BlackBrush");
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x0600099C RID: 2460 RVA: 0x00025973 File Offset: 0x00023B73
		// (set) Token: 0x0600099D RID: 2461 RVA: 0x00025985 File Offset: 0x00023B85
		public string Message
		{
			get
			{
				return (string)base.GetValue(ProgressDialog.MessageProperty);
			}
			set
			{
				base.SetValue(ProgressDialog.MessageProperty, value);
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x0600099E RID: 2462 RVA: 0x00025993 File Offset: 0x00023B93
		// (set) Token: 0x0600099F RID: 2463 RVA: 0x000259A5 File Offset: 0x00023BA5
		public bool IsCancelable
		{
			get
			{
				return (bool)base.GetValue(ProgressDialog.IsCancelableProperty);
			}
			set
			{
				base.SetValue(ProgressDialog.IsCancelableProperty, value);
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x060009A0 RID: 2464 RVA: 0x000259B8 File Offset: 0x00023BB8
		// (set) Token: 0x060009A1 RID: 2465 RVA: 0x000259CA File Offset: 0x00023BCA
		public string NegativeButtonText
		{
			get
			{
				return (string)base.GetValue(ProgressDialog.NegativeButtonTextProperty);
			}
			set
			{
				base.SetValue(ProgressDialog.NegativeButtonTextProperty, value);
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x060009A2 RID: 2466 RVA: 0x000259D8 File Offset: 0x00023BD8
		// (set) Token: 0x060009A3 RID: 2467 RVA: 0x000259EA File Offset: 0x00023BEA
		public Brush ProgressBarForeground
		{
			get
			{
				return (Brush)base.GetValue(ProgressDialog.ProgressBarForegroundProperty);
			}
			set
			{
				base.SetValue(ProgressDialog.ProgressBarForegroundProperty, value);
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x060009A4 RID: 2468 RVA: 0x000259F8 File Offset: 0x00023BF8
		internal CancellationToken CancellationToken
		{
			get
			{
				return base.DialogSettings.CancellationToken;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x060009A5 RID: 2469 RVA: 0x00025A05 File Offset: 0x00023C05
		// (set) Token: 0x060009A6 RID: 2470 RVA: 0x00025A12 File Offset: 0x00023C12
		internal double Minimum
		{
			get
			{
				return this.PART_ProgressBar.Minimum;
			}
			set
			{
				this.PART_ProgressBar.Minimum = value;
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x060009A7 RID: 2471 RVA: 0x00025A20 File Offset: 0x00023C20
		// (set) Token: 0x060009A8 RID: 2472 RVA: 0x00025A2D File Offset: 0x00023C2D
		internal double Maximum
		{
			get
			{
				return this.PART_ProgressBar.Maximum;
			}
			set
			{
				this.PART_ProgressBar.Maximum = value;
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x060009A9 RID: 2473 RVA: 0x00025A3B File Offset: 0x00023C3B
		// (set) Token: 0x060009AA RID: 2474 RVA: 0x00025A48 File Offset: 0x00023C48
		internal double ProgressValue
		{
			get
			{
				return this.PART_ProgressBar.Value;
			}
			set
			{
				this.PART_ProgressBar.IsIndeterminate = false;
				this.PART_ProgressBar.Value = value;
				this.PART_ProgressBar.ApplyTemplate();
			}
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x00025A6E File Offset: 0x00023C6E
		internal void SetIndeterminate()
		{
			this.PART_ProgressBar.IsIndeterminate = true;
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x00025A7C File Offset: 0x00023C7C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/MahApps.Metro;component/themes/dialogs/progressdialog.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x00025AAC File Offset: 0x00023CAC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x00025AB6 File Offset: 0x00023CB6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PART_NegativeButton = (Button)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.PART_ProgressBar = (MetroProgressBar)target;
		}

		// Token: 0x0400044E RID: 1102
		public static readonly DependencyProperty ProgressBarForegroundProperty = DependencyProperty.Register("ProgressBarForeground", typeof(Brush), typeof(ProgressDialog), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x0400044F RID: 1103
		public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(ProgressDialog), new PropertyMetadata(null));

		// Token: 0x04000450 RID: 1104
		public static readonly DependencyProperty IsCancelableProperty = DependencyProperty.Register("IsCancelable", typeof(bool), typeof(ProgressDialog), new PropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((ProgressDialog)s).PART_NegativeButton.Visibility = (((bool)e.NewValue) ? Visibility.Visible : Visibility.Hidden);
		}));

		// Token: 0x04000451 RID: 1105
		public static readonly DependencyProperty NegativeButtonTextProperty = DependencyProperty.Register("NegativeButtonText", typeof(string), typeof(ProgressDialog), new PropertyMetadata("Cancel"));

		// Token: 0x04000452 RID: 1106
		internal Button PART_NegativeButton;

		// Token: 0x04000453 RID: 1107
		internal MetroProgressBar PART_ProgressBar;

		// Token: 0x04000454 RID: 1108
		private bool _contentLoaded;
	}
}
