using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Markup;
using System.Windows.Threading;
using Microsoft.WindowsAPICodePack.Controls.WindowsForms;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Controls.WindowsPresentationFoundation
{
	// Token: 0x0200002B RID: 43
	public class ExplorerBrowser : UserControl, IDisposable, IComponentConnector
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00007AC0 File Offset: 0x00005CC0
		// (set) Token: 0x06000186 RID: 390 RVA: 0x00007AD7 File Offset: 0x00005CD7
		public ExplorerBrowser ExplorerBrowserControl { get; set; }

		// Token: 0x06000187 RID: 391 RVA: 0x00007AE0 File Offset: 0x00005CE0
		public ExplorerBrowser()
		{
			this.InitializeComponent();
			this.ExplorerBrowserControl = new ExplorerBrowser();
			this.SelectedItems = (this.selectedItems = new ObservableCollection<ShellObject>());
			this.Items = (this.items = new ObservableCollection<ShellObject>());
			this.NavigationLog = (this.navigationLog = new ObservableCollection<ShellObject>());
			this.ExplorerBrowserControl.ItemsChanged += this.ItemsChanged;
			this.ExplorerBrowserControl.SelectionChanged += this.SelectionChanged;
			this.ExplorerBrowserControl.ViewEnumerationComplete += this.ExplorerBrowserControl_ViewEnumerationComplete;
			this.ExplorerBrowserControl.ViewSelectedItemChanged += this.ExplorerBrowserControl_ViewSelectedItemChanged;
			this.ExplorerBrowserControl.NavigationLog.NavigationLogChanged += this.NavigationLogChanged;
			WindowsFormsHost windowsFormsHost = new WindowsFormsHost();
			try
			{
				windowsFormsHost.Child = this.ExplorerBrowserControl;
				this.root.Children.Clear();
				this.root.Children.Add(windowsFormsHost);
			}
			catch
			{
				windowsFormsHost.Dispose();
				throw;
			}
			base.Loaded += this.ExplorerBrowser_Loaded;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00007C54 File Offset: 0x00005E54
		private void ExplorerBrowserControl_ViewSelectedItemChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00007C57 File Offset: 0x00005E57
		private void ExplorerBrowserControl_ViewEnumerationComplete(object sender, EventArgs e)
		{
			this.itemsChanged.Set();
			this.selectionChanged.Set();
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00007C74 File Offset: 0x00005E74
		private void ExplorerBrowser_Loaded(object sender, RoutedEventArgs e)
		{
			this.dtCLRUpdater.Tick += this.UpdateDependencyPropertiesFromCLRPRoperties;
			this.dtCLRUpdater.Interval = new TimeSpan(1000000L);
			this.dtCLRUpdater.Start();
			if (this.initialNavigationTarget != null)
			{
				this.ExplorerBrowserControl.Navigate(this.initialNavigationTarget);
				this.initialNavigationTarget = null;
			}
			if (this.initialViewMode != null)
			{
				this.ExplorerBrowserControl.ContentOptions.ViewMode = this.initialViewMode.Value;
				this.initialViewMode = null;
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00007D28 File Offset: 0x00005F28
		private void UpdateDependencyPropertiesFromCLRPRoperties(object sender, EventArgs e)
		{
			this.AlignLeft = this.ExplorerBrowserControl.ContentOptions.AlignLeft;
			this.AutoArrange = this.ExplorerBrowserControl.ContentOptions.AutoArrange;
			this.CheckSelect = this.ExplorerBrowserControl.ContentOptions.CheckSelect;
			this.ExtendedTiles = this.ExplorerBrowserControl.ContentOptions.ExtendedTiles;
			this.FullRowSelect = this.ExplorerBrowserControl.ContentOptions.FullRowSelect;
			this.HideFileNames = this.ExplorerBrowserControl.ContentOptions.HideFileNames;
			this.NoBrowserViewState = this.ExplorerBrowserControl.ContentOptions.NoBrowserViewState;
			this.NoColumnHeader = this.ExplorerBrowserControl.ContentOptions.NoColumnHeader;
			this.NoHeaderInAllViews = this.ExplorerBrowserControl.ContentOptions.NoHeaderInAllViews;
			this.NoIcons = this.ExplorerBrowserControl.ContentOptions.NoIcons;
			this.NoSubfolders = this.ExplorerBrowserControl.ContentOptions.NoSubfolders;
			this.SingleClickActivate = this.ExplorerBrowserControl.ContentOptions.SingleClickActivate;
			this.SingleSelection = this.ExplorerBrowserControl.ContentOptions.SingleSelection;
			this.ThumbnailSize = this.ExplorerBrowserControl.ContentOptions.ThumbnailSize;
			this.ViewMode = this.ExplorerBrowserControl.ContentOptions.ViewMode;
			this.AlwaysNavigate = this.ExplorerBrowserControl.NavigationOptions.AlwaysNavigate;
			this.NavigateOnce = this.ExplorerBrowserControl.NavigationOptions.NavigateOnce;
			this.AdvancedQueryPane = this.ExplorerBrowserControl.NavigationOptions.PaneVisibility.AdvancedQuery;
			this.CommandsPane = this.ExplorerBrowserControl.NavigationOptions.PaneVisibility.Commands;
			this.CommandsOrganizePane = this.ExplorerBrowserControl.NavigationOptions.PaneVisibility.CommandsOrganize;
			this.CommandsViewPane = this.ExplorerBrowserControl.NavigationOptions.PaneVisibility.CommandsView;
			this.DetailsPane = this.ExplorerBrowserControl.NavigationOptions.PaneVisibility.Details;
			this.NavigationPane = this.ExplorerBrowserControl.NavigationOptions.PaneVisibility.Navigation;
			this.PreviewPane = this.ExplorerBrowserControl.NavigationOptions.PaneVisibility.Preview;
			this.QueryPane = this.ExplorerBrowserControl.NavigationOptions.PaneVisibility.Query;
			this.NavigationLogIndex = this.ExplorerBrowserControl.NavigationLog.CurrentLocationIndex;
			if (this.itemsChanged.WaitOne(1, false))
			{
				this.items.Clear();
				foreach (object obj in this.ExplorerBrowserControl.Items)
				{
					ShellObject item = (ShellObject)obj;
					this.items.Add(item);
				}
			}
			if (this.selectionChanged.WaitOne(1, false))
			{
				this.selectionChangeWaitCount = 4;
			}
			else if (this.selectionChangeWaitCount > 0)
			{
				this.selectionChangeWaitCount--;
				if (this.selectionChangeWaitCount == 0)
				{
					this.selectedItems.Clear();
					foreach (object obj2 in this.ExplorerBrowserControl.SelectedItems)
					{
						ShellObject item = (ShellObject)obj2;
						this.selectedItems.Add(item);
					}
				}
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000080FC File Offset: 0x000062FC
		private void NavigationLogChanged(object sender, NavigationLogEventArgs args)
		{
			this.navigationLog.Clear();
			foreach (ShellObject item in this.ExplorerBrowserControl.NavigationLog.Locations)
			{
				this.navigationLog.Add(item);
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00008174 File Offset: 0x00006374
		private void SelectionChanged(object sender, EventArgs e)
		{
			this.selectionChanged.Set();
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00008183 File Offset: 0x00006383
		private void ItemsChanged(object sender, EventArgs e)
		{
			this.itemsChanged.Set();
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600018F RID: 399 RVA: 0x00008194 File Offset: 0x00006394
		// (set) Token: 0x06000190 RID: 400 RVA: 0x000081B6 File Offset: 0x000063B6
		public ObservableCollection<ShellObject> Items
		{
			get
			{
				return (ObservableCollection<ShellObject>)base.GetValue(ExplorerBrowser.ItemsProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.ItemsPropertyKey, value);
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000191 RID: 401 RVA: 0x000081C8 File Offset: 0x000063C8
		// (set) Token: 0x06000192 RID: 402 RVA: 0x000081EA File Offset: 0x000063EA
		public ObservableCollection<ShellObject> SelectedItems
		{
			get
			{
				return (ObservableCollection<ShellObject>)base.GetValue(ExplorerBrowser.SelectedItemsProperty);
			}
			internal set
			{
				base.SetValue(ExplorerBrowser.SelectedItemsPropertyKey, value);
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000193 RID: 403 RVA: 0x000081FC File Offset: 0x000063FC
		// (set) Token: 0x06000194 RID: 404 RVA: 0x0000821E File Offset: 0x0000641E
		public ObservableCollection<ShellObject> NavigationLog
		{
			get
			{
				return (ObservableCollection<ShellObject>)base.GetValue(ExplorerBrowser.NavigationLogProperty);
			}
			internal set
			{
				base.SetValue(ExplorerBrowser.NavigationLogPropertyKey, value);
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000195 RID: 405 RVA: 0x00008230 File Offset: 0x00006430
		// (set) Token: 0x06000196 RID: 406 RVA: 0x00008252 File Offset: 0x00006452
		public ShellObject NavigationTarget
		{
			get
			{
				return (ShellObject)base.GetValue(ExplorerBrowser.NavigationTargetProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.NavigationTargetProperty, value);
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00008264 File Offset: 0x00006464
		private static void navigationTargetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl.explorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.Navigate((ShellObject)e.NewValue);
			}
			else
			{
				explorerBrowser.initialNavigationTarget = (ShellObject)e.NewValue;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000198 RID: 408 RVA: 0x000082BC File Offset: 0x000064BC
		// (set) Token: 0x06000199 RID: 409 RVA: 0x000082DE File Offset: 0x000064DE
		public bool AlignLeft
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.AlignLeftProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.AlignLeftProperty, value);
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000082F4 File Offset: 0x000064F4
		private static void OnAlignLeftChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.AlignLeft = (bool)e.NewValue;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00008334 File Offset: 0x00006534
		// (set) Token: 0x0600019C RID: 412 RVA: 0x00008356 File Offset: 0x00006556
		public bool AutoArrange
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.AutoArrangeProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.AutoArrangeProperty, value);
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000836C File Offset: 0x0000656C
		private static void OnAutoArrangeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.AutoArrange = (bool)e.NewValue;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600019E RID: 414 RVA: 0x000083AC File Offset: 0x000065AC
		// (set) Token: 0x0600019F RID: 415 RVA: 0x000083CE File Offset: 0x000065CE
		public bool CheckSelect
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.CheckSelectProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.CheckSelectProperty, value);
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x000083E4 File Offset: 0x000065E4
		private static void OnCheckSelectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.CheckSelect = (bool)e.NewValue;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00008428 File Offset: 0x00006628
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x0000844A File Offset: 0x0000664A
		public bool ExtendedTiles
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.ExtendedTilesProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.ExtendedTilesProperty, value);
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00008460 File Offset: 0x00006660
		private static void OnExtendedTilesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.ExtendedTiles = (bool)e.NewValue;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x000084A0 File Offset: 0x000066A0
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x000084C2 File Offset: 0x000066C2
		public bool FullRowSelect
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.FullRowSelectProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.FullRowSelectProperty, value);
			}
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000084D8 File Offset: 0x000066D8
		private static void OnFullRowSelectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.FullRowSelect = (bool)e.NewValue;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x0000851C File Offset: 0x0000671C
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x0000853E File Offset: 0x0000673E
		public bool HideFileNames
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.HideFileNamesProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.HideFileNamesProperty, value);
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00008554 File Offset: 0x00006754
		private static void OnHideFileNamesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.HideFileNames = (bool)e.NewValue;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00008598 File Offset: 0x00006798
		// (set) Token: 0x060001AB RID: 427 RVA: 0x000085BA File Offset: 0x000067BA
		public bool NoBrowserViewState
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.NoBrowserViewStateProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.NoBrowserViewStateProperty, value);
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000085D0 File Offset: 0x000067D0
		private static void OnNoBrowserViewStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.NoBrowserViewState = (bool)e.NewValue;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001AD RID: 429 RVA: 0x00008614 File Offset: 0x00006814
		// (set) Token: 0x060001AE RID: 430 RVA: 0x00008636 File Offset: 0x00006836
		public bool NoColumnHeader
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.NoColumnHeaderProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.NoColumnHeaderProperty, value);
			}
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000864C File Offset: 0x0000684C
		private static void OnNoColumnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.NoColumnHeader = (bool)e.NewValue;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x0000868C File Offset: 0x0000688C
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x000086AE File Offset: 0x000068AE
		public bool NoHeaderInAllViews
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.NoHeaderInAllViewsProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.NoHeaderInAllViewsProperty, value);
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x000086C4 File Offset: 0x000068C4
		private static void OnNoHeaderInAllViewsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.NoHeaderInAllViews = (bool)e.NewValue;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00008708 File Offset: 0x00006908
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x0000872A File Offset: 0x0000692A
		public bool NoIcons
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.NoIconsProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.NoIconsProperty, value);
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00008740 File Offset: 0x00006940
		private static void OnNoIconsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.NoIcons = (bool)e.NewValue;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x00008784 File Offset: 0x00006984
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x000087A6 File Offset: 0x000069A6
		public bool NoSubfolders
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.NoSubfoldersProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.NoSubfoldersProperty, value);
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000087BC File Offset: 0x000069BC
		private static void OnNoSubfoldersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.NoSubfolders = (bool)e.NewValue;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00008800 File Offset: 0x00006A00
		// (set) Token: 0x060001BA RID: 442 RVA: 0x00008822 File Offset: 0x00006A22
		public bool SingleClickActivate
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.SingleClickActivateProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.SingleClickActivateProperty, value);
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00008838 File Offset: 0x00006A38
		private static void OnSingleClickActivateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.SingleClickActivate = (bool)e.NewValue;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001BC RID: 444 RVA: 0x0000887C File Offset: 0x00006A7C
		// (set) Token: 0x060001BD RID: 445 RVA: 0x0000889E File Offset: 0x00006A9E
		public bool SingleSelection
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.SingleSelectionProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.SingleSelectionProperty, value);
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x000088B4 File Offset: 0x00006AB4
		private static void OnSingleSelectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.SingleSelection = (bool)e.NewValue;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001BF RID: 447 RVA: 0x000088F8 File Offset: 0x00006AF8
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x0000891A File Offset: 0x00006B1A
		public int ThumbnailSize
		{
			get
			{
				return (int)base.GetValue(ExplorerBrowser.ThumbnailSizeProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.ThumbnailSizeProperty, value);
			}
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00008930 File Offset: 0x00006B30
		private static void OnThumbnailSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.ContentOptions.ThumbnailSize = (int)e.NewValue;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x00008974 File Offset: 0x00006B74
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x00008996 File Offset: 0x00006B96
		public ExplorerBrowserViewMode ViewMode
		{
			get
			{
				return (ExplorerBrowserViewMode)base.GetValue(ExplorerBrowser.ViewModeProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.ViewModeProperty, value);
			}
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x000089AC File Offset: 0x00006BAC
		private static void OnViewModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				if (explorerBrowser.ExplorerBrowserControl.explorerBrowserControl == null)
				{
					explorerBrowser.initialViewMode = new ExplorerBrowserViewMode?((ExplorerBrowserViewMode)e.NewValue);
				}
				else
				{
					explorerBrowser.ExplorerBrowserControl.ContentOptions.ViewMode = (ExplorerBrowserViewMode)e.NewValue;
				}
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00008A20 File Offset: 0x00006C20
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x00008A42 File Offset: 0x00006C42
		public bool AlwaysNavigate
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.AlwaysNavigateProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.AlwaysNavigateProperty, value);
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00008A58 File Offset: 0x00006C58
		private static void OnAlwaysNavigateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.NavigationOptions.AlwaysNavigate = (bool)e.NewValue;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00008A9C File Offset: 0x00006C9C
		// (set) Token: 0x060001C9 RID: 457 RVA: 0x00008ABE File Offset: 0x00006CBE
		public bool NavigateOnce
		{
			get
			{
				return (bool)base.GetValue(ExplorerBrowser.NavigateOnceProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.NavigateOnceProperty, value);
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00008AD4 File Offset: 0x00006CD4
		private static void OnNavigateOnceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.NavigationOptions.NavigateOnce = (bool)e.NewValue;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001CB RID: 459 RVA: 0x00008B18 File Offset: 0x00006D18
		// (set) Token: 0x060001CC RID: 460 RVA: 0x00008B3A File Offset: 0x00006D3A
		public PaneVisibilityState AdvancedQueryPane
		{
			get
			{
				return (PaneVisibilityState)base.GetValue(ExplorerBrowser.AdvancedQueryPaneProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.AdvancedQueryPaneProperty, value);
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00008B50 File Offset: 0x00006D50
		private static void OnAdvancedQueryPaneChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.NavigationOptions.PaneVisibility.AdvancedQuery = (PaneVisibilityState)e.NewValue;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001CE RID: 462 RVA: 0x00008B98 File Offset: 0x00006D98
		// (set) Token: 0x060001CF RID: 463 RVA: 0x00008BBA File Offset: 0x00006DBA
		public PaneVisibilityState CommandsPane
		{
			get
			{
				return (PaneVisibilityState)base.GetValue(ExplorerBrowser.CommandsPaneProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.CommandsPaneProperty, value);
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00008BD0 File Offset: 0x00006DD0
		private static void OnCommandsPaneChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.NavigationOptions.PaneVisibility.Commands = (PaneVisibilityState)e.NewValue;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x00008C18 File Offset: 0x00006E18
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x00008C3A File Offset: 0x00006E3A
		public PaneVisibilityState CommandsOrganizePane
		{
			get
			{
				return (PaneVisibilityState)base.GetValue(ExplorerBrowser.CommandsOrganizePaneProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.CommandsOrganizePaneProperty, value);
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00008C50 File Offset: 0x00006E50
		private static void OnCommandsOrganizePaneChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.NavigationOptions.PaneVisibility.CommandsOrganize = (PaneVisibilityState)e.NewValue;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x00008C98 File Offset: 0x00006E98
		// (set) Token: 0x060001D5 RID: 469 RVA: 0x00008CBA File Offset: 0x00006EBA
		public PaneVisibilityState CommandsViewPane
		{
			get
			{
				return (PaneVisibilityState)base.GetValue(ExplorerBrowser.CommandsViewPaneProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.CommandsViewPaneProperty, value);
			}
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00008CD0 File Offset: 0x00006ED0
		private static void OnCommandsViewPaneChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.NavigationOptions.PaneVisibility.CommandsView = (PaneVisibilityState)e.NewValue;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00008D18 File Offset: 0x00006F18
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x00008D3A File Offset: 0x00006F3A
		public PaneVisibilityState DetailsPane
		{
			get
			{
				return (PaneVisibilityState)base.GetValue(ExplorerBrowser.DetailsPaneProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.DetailsPaneProperty, value);
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00008D50 File Offset: 0x00006F50
		private static void OnDetailsPaneChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.NavigationOptions.PaneVisibility.Details = (PaneVisibilityState)e.NewValue;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001DA RID: 474 RVA: 0x00008D98 File Offset: 0x00006F98
		// (set) Token: 0x060001DB RID: 475 RVA: 0x00008DBA File Offset: 0x00006FBA
		public PaneVisibilityState NavigationPane
		{
			get
			{
				return (PaneVisibilityState)base.GetValue(ExplorerBrowser.NavigationPaneProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.NavigationPaneProperty, value);
			}
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00008DD0 File Offset: 0x00006FD0
		private static void OnNavigationPaneChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.NavigationOptions.PaneVisibility.Navigation = (PaneVisibilityState)e.NewValue;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00008E18 File Offset: 0x00007018
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00008E3A File Offset: 0x0000703A
		public PaneVisibilityState PreviewPane
		{
			get
			{
				return (PaneVisibilityState)base.GetValue(ExplorerBrowser.PreviewPaneProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.PreviewPaneProperty, value);
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00008E50 File Offset: 0x00007050
		private static void OnPreviewPaneChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.NavigationOptions.PaneVisibility.Preview = (PaneVisibilityState)e.NewValue;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00008E98 File Offset: 0x00007098
		// (set) Token: 0x060001E1 RID: 481 RVA: 0x00008EBA File Offset: 0x000070BA
		public PaneVisibilityState QueryPane
		{
			get
			{
				return (PaneVisibilityState)base.GetValue(ExplorerBrowser.QueryPaneProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.QueryPaneProperty, value);
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00008ED0 File Offset: 0x000070D0
		private static void OnQueryPaneChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.NavigationOptions.PaneVisibility.Query = (PaneVisibilityState)e.NewValue;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00008F18 File Offset: 0x00007118
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x00008F3A File Offset: 0x0000713A
		public int NavigationLogIndex
		{
			get
			{
				return (int)base.GetValue(ExplorerBrowser.NavigationLogIndexProperty);
			}
			set
			{
				base.SetValue(ExplorerBrowser.NavigationLogIndexProperty, value);
			}
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00008F50 File Offset: 0x00007150
		private static void OnNavigationLogIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ExplorerBrowser explorerBrowser = d as ExplorerBrowser;
			if (explorerBrowser.ExplorerBrowserControl != null)
			{
				explorerBrowser.ExplorerBrowserControl.NavigationLog.NavigateLog((int)e.NewValue);
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00008F8F File Offset: 0x0000718F
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00008FA4 File Offset: 0x000071A4
		protected virtual void Dispose(bool disposed)
		{
			if (disposed)
			{
				if (this.itemsChanged != null)
				{
					this.itemsChanged.Close();
				}
				if (this.selectionChanged != null)
				{
					this.selectionChanged.Close();
				}
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00008FF4 File Offset: 0x000071F4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this._contentLoaded)
			{
				this._contentLoaded = true;
				Uri resourceLocator = new Uri("/Microsoft.WindowsAPICodePack.Shell;component/explorerbrowser/explorerbrowser.wpf.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00009030 File Offset: 0x00007230
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId != 1)
			{
				this._contentLoaded = true;
			}
			else
			{
				this.root = (Grid)target;
			}
		}

		// Token: 0x04000066 RID: 102
		private ObservableCollection<ShellObject> selectedItems;

		// Token: 0x04000067 RID: 103
		private ObservableCollection<ShellObject> items;

		// Token: 0x04000068 RID: 104
		private ObservableCollection<ShellObject> navigationLog;

		// Token: 0x04000069 RID: 105
		private DispatcherTimer dtCLRUpdater = new DispatcherTimer();

		// Token: 0x0400006A RID: 106
		private ShellObject initialNavigationTarget;

		// Token: 0x0400006B RID: 107
		private ExplorerBrowserViewMode? initialViewMode;

		// Token: 0x0400006C RID: 108
		private AutoResetEvent itemsChanged = new AutoResetEvent(false);

		// Token: 0x0400006D RID: 109
		private AutoResetEvent selectionChanged = new AutoResetEvent(false);

		// Token: 0x0400006E RID: 110
		private int selectionChangeWaitCount;

		// Token: 0x0400006F RID: 111
		private static readonly DependencyPropertyKey ItemsPropertyKey = DependencyProperty.RegisterReadOnly("Items", typeof(ObservableCollection<ShellObject>), typeof(ExplorerBrowser), new PropertyMetadata(null));

		// Token: 0x04000070 RID: 112
		public static readonly DependencyProperty ItemsProperty = ExplorerBrowser.ItemsPropertyKey.DependencyProperty;

		// Token: 0x04000071 RID: 113
		private static readonly DependencyPropertyKey SelectedItemsPropertyKey = DependencyProperty.RegisterReadOnly("SelectedItems", typeof(ObservableCollection<ShellObject>), typeof(ExplorerBrowser), new PropertyMetadata(null));

		// Token: 0x04000072 RID: 114
		private static readonly DependencyPropertyKey NavigationLogPropertyKey = DependencyProperty.RegisterReadOnly("NavigationLog", typeof(ObservableCollection<ShellObject>), typeof(ExplorerBrowser), new PropertyMetadata(null));

		// Token: 0x04000073 RID: 115
		public static readonly DependencyProperty NavigationLogProperty = ExplorerBrowser.NavigationLogPropertyKey.DependencyProperty;

		// Token: 0x04000074 RID: 116
		public static readonly DependencyProperty SelectedItemsProperty = ExplorerBrowser.SelectedItemsPropertyKey.DependencyProperty;

		// Token: 0x04000075 RID: 117
		public static readonly DependencyProperty NavigationTargetProperty = DependencyProperty.Register("NavigationTarget", typeof(ShellObject), typeof(ExplorerBrowser), new PropertyMetadata(null, new PropertyChangedCallback(ExplorerBrowser.navigationTargetChanged)));

		// Token: 0x04000076 RID: 118
		internal static DependencyProperty AlignLeftProperty = DependencyProperty.Register("AlignLeft", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnAlignLeftChanged)));

		// Token: 0x04000077 RID: 119
		internal static DependencyProperty AutoArrangeProperty = DependencyProperty.Register("AutoArrange", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnAutoArrangeChanged)));

		// Token: 0x04000078 RID: 120
		internal static DependencyProperty CheckSelectProperty = DependencyProperty.Register("CheckSelect", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnCheckSelectChanged)));

		// Token: 0x04000079 RID: 121
		internal static DependencyProperty ExtendedTilesProperty = DependencyProperty.Register("ExtendedTiles", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnExtendedTilesChanged)));

		// Token: 0x0400007A RID: 122
		internal static DependencyProperty FullRowSelectProperty = DependencyProperty.Register("FullRowSelect", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnFullRowSelectChanged)));

		// Token: 0x0400007B RID: 123
		internal static DependencyProperty HideFileNamesProperty = DependencyProperty.Register("HideFileNames", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnHideFileNamesChanged)));

		// Token: 0x0400007C RID: 124
		internal static DependencyProperty NoBrowserViewStateProperty = DependencyProperty.Register("NoBrowserViewState", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnNoBrowserViewStateChanged)));

		// Token: 0x0400007D RID: 125
		internal static DependencyProperty NoColumnHeaderProperty = DependencyProperty.Register("NoColumnHeader", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnNoColumnHeaderChanged)));

		// Token: 0x0400007E RID: 126
		internal static DependencyProperty NoHeaderInAllViewsProperty = DependencyProperty.Register("NoHeaderInAllViews", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnNoHeaderInAllViewsChanged)));

		// Token: 0x0400007F RID: 127
		internal static DependencyProperty NoIconsProperty = DependencyProperty.Register("NoIcons", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnNoIconsChanged)));

		// Token: 0x04000080 RID: 128
		internal static DependencyProperty NoSubfoldersProperty = DependencyProperty.Register("NoSubfolders", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnNoSubfoldersChanged)));

		// Token: 0x04000081 RID: 129
		internal static DependencyProperty SingleClickActivateProperty = DependencyProperty.Register("SingleClickActivate", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnSingleClickActivateChanged)));

		// Token: 0x04000082 RID: 130
		internal static DependencyProperty SingleSelectionProperty = DependencyProperty.Register("SingleSelection", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnSingleSelectionChanged)));

		// Token: 0x04000083 RID: 131
		internal static DependencyProperty ThumbnailSizeProperty = DependencyProperty.Register("ThumbnailSize", typeof(int), typeof(ExplorerBrowser), new PropertyMetadata(32, new PropertyChangedCallback(ExplorerBrowser.OnThumbnailSizeChanged)));

		// Token: 0x04000084 RID: 132
		internal static DependencyProperty ViewModeProperty = DependencyProperty.Register("ViewMode", typeof(ExplorerBrowserViewMode), typeof(ExplorerBrowser), new PropertyMetadata(ExplorerBrowserViewMode.Auto, new PropertyChangedCallback(ExplorerBrowser.OnViewModeChanged)));

		// Token: 0x04000085 RID: 133
		internal static DependencyProperty AlwaysNavigateProperty = DependencyProperty.Register("AlwaysNavigate", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnAlwaysNavigateChanged)));

		// Token: 0x04000086 RID: 134
		internal static DependencyProperty NavigateOnceProperty = DependencyProperty.Register("NavigateOnce", typeof(bool), typeof(ExplorerBrowser), new PropertyMetadata(false, new PropertyChangedCallback(ExplorerBrowser.OnNavigateOnceChanged)));

		// Token: 0x04000087 RID: 135
		internal static DependencyProperty AdvancedQueryPaneProperty = DependencyProperty.Register("AdvancedQueryPane", typeof(PaneVisibilityState), typeof(ExplorerBrowser), new PropertyMetadata(PaneVisibilityState.DoNotCare, new PropertyChangedCallback(ExplorerBrowser.OnAdvancedQueryPaneChanged)));

		// Token: 0x04000088 RID: 136
		internal static DependencyProperty CommandsPaneProperty = DependencyProperty.Register("CommandsPane", typeof(PaneVisibilityState), typeof(ExplorerBrowser), new PropertyMetadata(PaneVisibilityState.DoNotCare, new PropertyChangedCallback(ExplorerBrowser.OnCommandsPaneChanged)));

		// Token: 0x04000089 RID: 137
		internal static DependencyProperty CommandsOrganizePaneProperty = DependencyProperty.Register("CommandsOrganizePane", typeof(PaneVisibilityState), typeof(ExplorerBrowser), new PropertyMetadata(PaneVisibilityState.DoNotCare, new PropertyChangedCallback(ExplorerBrowser.OnCommandsOrganizePaneChanged)));

		// Token: 0x0400008A RID: 138
		internal static DependencyProperty CommandsViewPaneProperty = DependencyProperty.Register("CommandsViewPane", typeof(PaneVisibilityState), typeof(ExplorerBrowser), new PropertyMetadata(PaneVisibilityState.DoNotCare, new PropertyChangedCallback(ExplorerBrowser.OnCommandsViewPaneChanged)));

		// Token: 0x0400008B RID: 139
		internal static DependencyProperty DetailsPaneProperty = DependencyProperty.Register("DetailsPane", typeof(PaneVisibilityState), typeof(ExplorerBrowser), new PropertyMetadata(PaneVisibilityState.DoNotCare, new PropertyChangedCallback(ExplorerBrowser.OnDetailsPaneChanged)));

		// Token: 0x0400008C RID: 140
		internal static DependencyProperty NavigationPaneProperty = DependencyProperty.Register("NavigationPane", typeof(PaneVisibilityState), typeof(ExplorerBrowser), new PropertyMetadata(PaneVisibilityState.DoNotCare, new PropertyChangedCallback(ExplorerBrowser.OnNavigationPaneChanged)));

		// Token: 0x0400008D RID: 141
		internal static DependencyProperty PreviewPaneProperty = DependencyProperty.Register("PreviewPane", typeof(PaneVisibilityState), typeof(ExplorerBrowser), new PropertyMetadata(PaneVisibilityState.DoNotCare, new PropertyChangedCallback(ExplorerBrowser.OnPreviewPaneChanged)));

		// Token: 0x0400008E RID: 142
		internal static DependencyProperty QueryPaneProperty = DependencyProperty.Register("QueryPane", typeof(PaneVisibilityState), typeof(ExplorerBrowser), new PropertyMetadata(PaneVisibilityState.DoNotCare, new PropertyChangedCallback(ExplorerBrowser.OnQueryPaneChanged)));

		// Token: 0x0400008F RID: 143
		internal static DependencyProperty NavigationLogIndexProperty = DependencyProperty.Register("NavigationLogIndex", typeof(int), typeof(ExplorerBrowser), new PropertyMetadata(0, new PropertyChangedCallback(ExplorerBrowser.OnNavigationLogIndexChanged)));

		// Token: 0x04000090 RID: 144
		internal Grid root;

		// Token: 0x04000091 RID: 145
		private bool _contentLoaded;
	}
}
