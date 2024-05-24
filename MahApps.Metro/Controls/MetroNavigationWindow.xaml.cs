using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000061 RID: 97
	[ContentProperty("OverlayContent")]
	public partial class MetroNavigationWindow : MetroWindow, IUriContext
	{
		// Token: 0x06000412 RID: 1042 RVA: 0x000100A8 File Offset: 0x0000E2A8
		public MetroNavigationWindow()
		{
			this.InitializeComponent();
			base.Loaded += this.MetroNavigationWindow_Loaded;
			base.Closing += this.MetroNavigationWindow_Closing;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x000100DC File Offset: 0x0000E2DC
		private void MetroNavigationWindow_Loaded(object sender, RoutedEventArgs e)
		{
			this.PART_Frame.Navigated += this.PART_Frame_Navigated;
			this.PART_Frame.Navigating += this.PART_Frame_Navigating;
			this.PART_Frame.NavigationFailed += this.PART_Frame_NavigationFailed;
			this.PART_Frame.NavigationProgress += this.PART_Frame_NavigationProgress;
			this.PART_Frame.NavigationStopped += this.PART_Frame_NavigationStopped;
			this.PART_Frame.LoadCompleted += this.PART_Frame_LoadCompleted;
			this.PART_Frame.FragmentNavigation += this.PART_Frame_FragmentNavigation;
			this.PART_BackButton.Click += this.PART_BackButton_Click;
			this.PART_ForwardButton.Click += this.PART_ForwardButton_Click;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x000101B8 File Offset: 0x0000E3B8
		[DebuggerNonUserCode]
		private void PART_ForwardButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.CanGoForward)
			{
				this.GoForward();
			}
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x000101C8 File Offset: 0x0000E3C8
		[DebuggerNonUserCode]
		private void PART_Frame_FragmentNavigation(object sender, FragmentNavigationEventArgs e)
		{
			if (this.FragmentNavigation != null)
			{
				this.FragmentNavigation(this, e);
			}
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x000101DF File Offset: 0x0000E3DF
		[DebuggerNonUserCode]
		private void PART_Frame_LoadCompleted(object sender, NavigationEventArgs e)
		{
			if (this.LoadCompleted != null)
			{
				this.LoadCompleted(this, e);
			}
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x000101F6 File Offset: 0x0000E3F6
		[DebuggerNonUserCode]
		private void PART_Frame_NavigationStopped(object sender, NavigationEventArgs e)
		{
			if (this.NavigationStopped != null)
			{
				this.NavigationStopped(this, e);
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x0001020D File Offset: 0x0000E40D
		[DebuggerNonUserCode]
		private void PART_Frame_NavigationProgress(object sender, NavigationProgressEventArgs e)
		{
			if (this.NavigationProgress != null)
			{
				this.NavigationProgress(this, e);
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00010224 File Offset: 0x0000E424
		[DebuggerNonUserCode]
		private void PART_Frame_NavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			if (this.NavigationFailed != null)
			{
				this.NavigationFailed(this, e);
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0001023B File Offset: 0x0000E43B
		[DebuggerNonUserCode]
		private void PART_Frame_Navigating(object sender, NavigatingCancelEventArgs e)
		{
			if (this.Navigating != null)
			{
				this.Navigating(this, e);
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00010252 File Offset: 0x0000E452
		[DebuggerNonUserCode]
		private void PART_BackButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.CanGoBack)
			{
				this.GoBack();
			}
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00010264 File Offset: 0x0000E464
		[DebuggerNonUserCode]
		private void MetroNavigationWindow_Closing(object sender, CancelEventArgs e)
		{
			this.PART_Frame.FragmentNavigation -= this.PART_Frame_FragmentNavigation;
			this.PART_Frame.Navigating -= this.PART_Frame_Navigating;
			this.PART_Frame.NavigationFailed -= this.PART_Frame_NavigationFailed;
			this.PART_Frame.NavigationProgress -= this.PART_Frame_NavigationProgress;
			this.PART_Frame.NavigationStopped -= this.PART_Frame_NavigationStopped;
			this.PART_Frame.LoadCompleted -= this.PART_Frame_LoadCompleted;
			this.PART_Frame.Navigated -= this.PART_Frame_Navigated;
			this.PART_ForwardButton.Click -= this.PART_ForwardButton_Click;
			this.PART_BackButton.Click -= this.PART_BackButton_Click;
			base.Loaded -= this.MetroNavigationWindow_Loaded;
			base.Closing -= this.MetroNavigationWindow_Closing;
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00010364 File Offset: 0x0000E564
		[DebuggerNonUserCode]
		private void PART_Frame_Navigated(object sender, NavigationEventArgs e)
		{
			this.PART_Title.Content = ((Page)this.PART_Frame.Content).Title;
			((IUriContext)this).BaseUri = e.Uri;
			this.PageContent = this.PART_Frame.Content;
			this.PART_BackButton.IsEnabled = this.CanGoBack;
			this.PART_ForwardButton.IsEnabled = this.CanGoForward;
			if (this.Navigated != null)
			{
				this.Navigated(this, e);
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x000103E5 File Offset: 0x0000E5E5
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x000103F2 File Offset: 0x0000E5F2
		public object OverlayContent
		{
			get
			{
				return base.GetValue(MetroNavigationWindow.OverlayContentProperty);
			}
			set
			{
				base.SetValue(MetroNavigationWindow.OverlayContentProperty, value);
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x00010400 File Offset: 0x0000E600
		// (set) Token: 0x06000421 RID: 1057 RVA: 0x0001040D File Offset: 0x0000E60D
		public object PageContent
		{
			get
			{
				return base.GetValue(MetroNavigationWindow.PageContentProperty);
			}
			private set
			{
				base.SetValue(MetroNavigationWindow.PageContentProperty, value);
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000422 RID: 1058 RVA: 0x0001041B File Offset: 0x0000E61B
		public IEnumerable ForwardStack
		{
			get
			{
				return this.PART_Frame.ForwardStack;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x00010428 File Offset: 0x0000E628
		public IEnumerable BackStack
		{
			get
			{
				return this.PART_Frame.BackStack;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x00010435 File Offset: 0x0000E635
		public NavigationService NavigationService
		{
			get
			{
				return this.PART_Frame.NavigationService;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x00010442 File Offset: 0x0000E642
		public bool CanGoBack
		{
			get
			{
				return this.PART_Frame.CanGoBack;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x0001044F File Offset: 0x0000E64F
		public bool CanGoForward
		{
			get
			{
				return this.PART_Frame.CanGoForward;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x0001045C File Offset: 0x0000E65C
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x00010464 File Offset: 0x0000E664
		Uri IUriContext.BaseUri { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x0001046D File Offset: 0x0000E66D
		// (set) Token: 0x0600042A RID: 1066 RVA: 0x0001047A File Offset: 0x0000E67A
		public Uri Source
		{
			get
			{
				return this.PART_Frame.Source;
			}
			set
			{
				this.PART_Frame.Source = value;
			}
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00010488 File Offset: 0x0000E688
		[DebuggerNonUserCode]
		public void AddBackEntry(CustomContentState state)
		{
			this.PART_Frame.AddBackEntry(state);
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x00010496 File Offset: 0x0000E696
		[DebuggerNonUserCode]
		public JournalEntry RemoveBackEntry()
		{
			return this.PART_Frame.RemoveBackEntry();
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x000104A3 File Offset: 0x0000E6A3
		[DebuggerNonUserCode]
		public void GoBack()
		{
			this.PART_Frame.GoBack();
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x000104B0 File Offset: 0x0000E6B0
		[DebuggerNonUserCode]
		public void GoForward()
		{
			this.PART_Frame.GoForward();
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x000104BD File Offset: 0x0000E6BD
		[DebuggerNonUserCode]
		public bool Navigate(object content)
		{
			return this.PART_Frame.Navigate(content);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x000104CB File Offset: 0x0000E6CB
		[DebuggerNonUserCode]
		public bool Navigate(Uri source)
		{
			return this.PART_Frame.Navigate(source);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x000104D9 File Offset: 0x0000E6D9
		[DebuggerNonUserCode]
		public bool Navigate(object content, object extraData)
		{
			return this.PART_Frame.Navigate(content, extraData);
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x000104E8 File Offset: 0x0000E6E8
		[DebuggerNonUserCode]
		public bool Navigate(Uri source, object extraData)
		{
			return this.PART_Frame.Navigate(source, extraData);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x000104F7 File Offset: 0x0000E6F7
		[DebuggerNonUserCode]
		public void StopLoading()
		{
			this.PART_Frame.StopLoading();
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000434 RID: 1076 RVA: 0x00010504 File Offset: 0x0000E704
		// (remove) Token: 0x06000435 RID: 1077 RVA: 0x0001053C File Offset: 0x0000E73C
		public event FragmentNavigationEventHandler FragmentNavigation;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000436 RID: 1078 RVA: 0x00010574 File Offset: 0x0000E774
		// (remove) Token: 0x06000437 RID: 1079 RVA: 0x000105AC File Offset: 0x0000E7AC
		public event NavigatingCancelEventHandler Navigating;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000438 RID: 1080 RVA: 0x000105E4 File Offset: 0x0000E7E4
		// (remove) Token: 0x06000439 RID: 1081 RVA: 0x0001061C File Offset: 0x0000E81C
		public event NavigationFailedEventHandler NavigationFailed;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x0600043A RID: 1082 RVA: 0x00010654 File Offset: 0x0000E854
		// (remove) Token: 0x0600043B RID: 1083 RVA: 0x0001068C File Offset: 0x0000E88C
		public event NavigationProgressEventHandler NavigationProgress;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x0600043C RID: 1084 RVA: 0x000106C4 File Offset: 0x0000E8C4
		// (remove) Token: 0x0600043D RID: 1085 RVA: 0x000106FC File Offset: 0x0000E8FC
		public event NavigationStoppedEventHandler NavigationStopped;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x0600043E RID: 1086 RVA: 0x00010734 File Offset: 0x0000E934
		// (remove) Token: 0x0600043F RID: 1087 RVA: 0x0001076C File Offset: 0x0000E96C
		public event NavigatedEventHandler Navigated;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000440 RID: 1088 RVA: 0x000107A4 File Offset: 0x0000E9A4
		// (remove) Token: 0x06000441 RID: 1089 RVA: 0x000107DC File Offset: 0x0000E9DC
		public event LoadCompletedEventHandler LoadCompleted;

		// Token: 0x0400018F RID: 399
		public static readonly DependencyProperty OverlayContentProperty = DependencyProperty.Register("OverlayContent", typeof(object), typeof(MetroNavigationWindow));

		// Token: 0x04000190 RID: 400
		public static readonly DependencyProperty PageContentProperty = DependencyProperty.Register("PageContent", typeof(object), typeof(MetroNavigationWindow));
	}
}
