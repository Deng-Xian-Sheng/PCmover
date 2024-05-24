using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls.WindowsForms
{
	// Token: 0x0200002A RID: 42
	public sealed class ExplorerBrowser : UserControl, IServiceProvider, IExplorerPaneVisibility, IExplorerBrowserEvents, ICommDlgBrowser3, IMessageFilter
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000149 RID: 329 RVA: 0x000067A8 File Offset: 0x000049A8
		// (set) Token: 0x0600014A RID: 330 RVA: 0x000067BF File Offset: 0x000049BF
		public ExplorerBrowserNavigationOptions NavigationOptions { get; private set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600014B RID: 331 RVA: 0x000067C8 File Offset: 0x000049C8
		// (set) Token: 0x0600014C RID: 332 RVA: 0x000067DF File Offset: 0x000049DF
		public ExplorerBrowserContentOptions ContentOptions { get; private set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600014D RID: 333 RVA: 0x000067E8 File Offset: 0x000049E8
		public ShellObjectCollection Items
		{
			get
			{
				if (this.shellItemsArray != null)
				{
					Marshal.ReleaseComObject(this.shellItemsArray);
				}
				if (this.itemsCollection != null)
				{
					this.itemsCollection.Dispose();
					this.itemsCollection = null;
				}
				this.shellItemsArray = this.GetItemsArray();
				this.itemsCollection = new ShellObjectCollection(this.shellItemsArray, true);
				return this.itemsCollection;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600014E RID: 334 RVA: 0x0000685C File Offset: 0x00004A5C
		public ShellObjectCollection SelectedItems
		{
			get
			{
				if (this.selectedShellItemsArray != null)
				{
					Marshal.ReleaseComObject(this.selectedShellItemsArray);
				}
				if (this.selectedItemsCollection != null)
				{
					this.selectedItemsCollection.Dispose();
					this.selectedItemsCollection = null;
				}
				this.selectedShellItemsArray = this.GetSelectedItemsArray();
				this.selectedItemsCollection = new ShellObjectCollection(this.selectedShellItemsArray, true);
				return this.selectedItemsCollection;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600014F RID: 335 RVA: 0x000068D0 File Offset: 0x00004AD0
		// (set) Token: 0x06000150 RID: 336 RVA: 0x000068E7 File Offset: 0x00004AE7
		public ExplorerBrowserNavigationLog NavigationLog { get; private set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000151 RID: 337 RVA: 0x000068F0 File Offset: 0x00004AF0
		// (set) Token: 0x06000152 RID: 338 RVA: 0x00006908 File Offset: 0x00004B08
		public string PropertyBagName
		{
			get
			{
				return this.propertyBagName;
			}
			set
			{
				this.propertyBagName = value;
				if (this.explorerBrowserControl != null)
				{
					this.explorerBrowserControl.SetPropertyBag(this.propertyBagName);
				}
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00006940 File Offset: 0x00004B40
		public void Navigate(ShellObject shellObject)
		{
			if (shellObject == null)
			{
				throw new ArgumentNullException("shellObject");
			}
			if (this.explorerBrowserControl == null)
			{
				this.antecreationNavigationTarget = shellObject;
			}
			else
			{
				HResult hresult = this.explorerBrowserControl.BrowseToObject(shellObject.NativeShellItem, 0U);
				if (hresult != HResult.Ok)
				{
					if ((hresult != HResult.ResourceInUse && hresult != HResult.Canceled) || this.NavigationFailed == null)
					{
						throw new CommonControlException(LocalizedMessages.ExplorerBrowserBrowseToObjectFailed, hresult);
					}
					NavigationFailedEventArgs navigationFailedEventArgs = new NavigationFailedEventArgs();
					navigationFailedEventArgs.FailedLocation = shellObject;
					this.NavigationFailed(this, navigationFailedEventArgs);
				}
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000069F0 File Offset: 0x00004BF0
		public bool NavigateLogLocation(NavigationLogDirection direction)
		{
			return this.NavigationLog.NavigateLog(direction);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00006A10 File Offset: 0x00004C10
		public bool NavigateLogLocation(int navigationLogIndex)
		{
			return this.NavigationLog.NavigateLog(navigationLogIndex);
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000156 RID: 342 RVA: 0x00006A30 File Offset: 0x00004C30
		// (remove) Token: 0x06000157 RID: 343 RVA: 0x00006A6C File Offset: 0x00004C6C
		public event EventHandler SelectionChanged;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000158 RID: 344 RVA: 0x00006AA8 File Offset: 0x00004CA8
		// (remove) Token: 0x06000159 RID: 345 RVA: 0x00006AE4 File Offset: 0x00004CE4
		public event EventHandler ItemsChanged;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600015A RID: 346 RVA: 0x00006B20 File Offset: 0x00004D20
		// (remove) Token: 0x0600015B RID: 347 RVA: 0x00006B5C File Offset: 0x00004D5C
		public event EventHandler<NavigationPendingEventArgs> NavigationPending;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600015C RID: 348 RVA: 0x00006B98 File Offset: 0x00004D98
		// (remove) Token: 0x0600015D RID: 349 RVA: 0x00006BD4 File Offset: 0x00004DD4
		public event EventHandler<NavigationCompleteEventArgs> NavigationComplete;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600015E RID: 350 RVA: 0x00006C10 File Offset: 0x00004E10
		// (remove) Token: 0x0600015F RID: 351 RVA: 0x00006C4C File Offset: 0x00004E4C
		public event EventHandler<NavigationFailedEventArgs> NavigationFailed;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000160 RID: 352 RVA: 0x00006C88 File Offset: 0x00004E88
		// (remove) Token: 0x06000161 RID: 353 RVA: 0x00006CC4 File Offset: 0x00004EC4
		public event EventHandler ViewEnumerationComplete;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000162 RID: 354 RVA: 0x00006D00 File Offset: 0x00004F00
		// (remove) Token: 0x06000163 RID: 355 RVA: 0x00006D3C File Offset: 0x00004F3C
		public event EventHandler ViewSelectedItemChanged;

		// Token: 0x06000164 RID: 356 RVA: 0x00006D78 File Offset: 0x00004F78
		public ExplorerBrowser()
		{
			this.NavigationOptions = new ExplorerBrowserNavigationOptions(this);
			this.ContentOptions = new ExplorerBrowserContentOptions(this);
			this.NavigationLog = new ExplorerBrowserNavigationLog(this);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00006DCC File Offset: 0x00004FCC
		protected override void OnPaint(PaintEventArgs e)
		{
			if (base.DesignMode && e != null)
			{
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(base.ClientRectangle, Color.Aqua, Color.CadetBlue, LinearGradientMode.ForwardDiagonal))
				{
					e.Graphics.FillRectangle(linearGradientBrush, base.ClientRectangle);
				}
				using (Font font = new Font("Garamond", 30f))
				{
					using (StringFormat stringFormat = new StringFormat())
					{
						stringFormat.Alignment = StringAlignment.Center;
						stringFormat.LineAlignment = StringAlignment.Center;
						e.Graphics.DrawString("ExplorerBrowserControl", font, Brushes.White, base.ClientRectangle, stringFormat);
					}
				}
			}
			base.OnPaint(e);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00006EF0 File Offset: 0x000050F0
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (!base.DesignMode)
			{
				this.explorerBrowserControl = new ExplorerBrowserClass();
				ExplorerBrowserNativeMethods.IUnknown_SetSite(this.explorerBrowserControl, this);
				this.explorerBrowserControl.Advise(Marshal.GetComInterfaceForObject(this, typeof(IExplorerBrowserEvents)), out this.eventsCookie);
				this.viewEvents = new ExplorerBrowserViewEvents(this);
				NativeRect nativeRect = default(NativeRect);
				nativeRect.Top = base.ClientRectangle.Top;
				nativeRect.Left = base.ClientRectangle.Left;
				nativeRect.Right = base.ClientRectangle.Right;
				nativeRect.Bottom = base.ClientRectangle.Bottom;
				this.explorerBrowserControl.Initialize(base.Handle, ref nativeRect, null);
				this.explorerBrowserControl.SetOptions(ExplorerBrowserOptions.ShowFrames);
				this.explorerBrowserControl.SetPropertyBag(this.propertyBagName);
				if (this.antecreationNavigationTarget != null)
				{
					base.BeginInvoke(new MethodInvoker(delegate()
					{
						this.Navigate(this.antecreationNavigationTarget);
						this.antecreationNavigationTarget = null;
					}));
				}
			}
			Application.AddMessageFilter(this);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00007028 File Offset: 0x00005228
		protected override void OnSizeChanged(EventArgs e)
		{
			if (this.explorerBrowserControl != null)
			{
				NativeRect rcBrowser = default(NativeRect);
				rcBrowser.Top = base.ClientRectangle.Top;
				rcBrowser.Left = base.ClientRectangle.Left;
				rcBrowser.Right = base.ClientRectangle.Right;
				rcBrowser.Bottom = base.ClientRectangle.Bottom;
				IntPtr zero = IntPtr.Zero;
				this.explorerBrowserControl.SetRect(ref zero, rcBrowser);
			}
			base.OnSizeChanged(e);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000070C4 File Offset: 0x000052C4
		protected override void OnHandleDestroyed(EventArgs e)
		{
			if (this.explorerBrowserControl != null)
			{
				this.viewEvents.DisconnectFromView();
				this.explorerBrowserControl.Unadvise(this.eventsCookie);
				ExplorerBrowserNativeMethods.IUnknown_SetSite(this.explorerBrowserControl, null);
				this.explorerBrowserControl.Destroy();
				Marshal.ReleaseComObject(this.explorerBrowserControl);
				this.explorerBrowserControl = null;
			}
			base.OnHandleDestroyed(e);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00007134 File Offset: 0x00005334
		HResult IServiceProvider.QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject)
		{
			HResult result;
			if (guidService.CompareTo(new Guid("e07010ec-bc17-44c0-97b0-46c7c95b9edc")) == 0)
			{
				ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IExplorerPaneVisibility));
				result = HResult.Ok;
			}
			else if (guidService.CompareTo(new Guid("000214F1-0000-0000-C000-000000000046")) == 0)
			{
				if (riid.CompareTo(new Guid("000214F1-0000-0000-C000-000000000046")) == 0)
				{
					ppvObject = Marshal.GetComInterfaceForObject(this, typeof(ICommDlgBrowser3));
					result = HResult.Ok;
				}
				else if (riid.CompareTo(new Guid("c8ad25a1-3294-41ee-8165-71174bd01c57")) == 0)
				{
					ppvObject = Marshal.GetComInterfaceForObject(this, typeof(ICommDlgBrowser3));
					result = HResult.Ok;
				}
				else
				{
					ppvObject = IntPtr.Zero;
					result = HResult.NoInterface;
				}
			}
			else
			{
				IntPtr zero = IntPtr.Zero;
				ppvObject = zero;
				result = HResult.NoInterface;
			}
			return result;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00007238 File Offset: 0x00005438
		HResult IExplorerPaneVisibility.GetPaneState(ref Guid explorerPane, out ExplorerPaneState peps)
		{
			string text = explorerPane.ToString();
			switch (text)
			{
			case "b4e9db8b-34ba-4c39-b5cc-16a1bd2c411c":
				peps = ExplorerBrowser.VisibilityToPaneState(this.NavigationOptions.PaneVisibility.AdvancedQuery);
				return HResult.Ok;
			case "d9745868-ca5f-4a76-91cd-f5a129fbb076":
				peps = ExplorerBrowser.VisibilityToPaneState(this.NavigationOptions.PaneVisibility.Commands);
				return HResult.Ok;
			case "72e81700-e3ec-4660-bf24-3c3b7b648806":
				peps = ExplorerBrowser.VisibilityToPaneState(this.NavigationOptions.PaneVisibility.CommandsOrganize);
				return HResult.Ok;
			case "21f7c32d-eeaa-439b-bb51-37b96fd6a943":
				peps = ExplorerBrowser.VisibilityToPaneState(this.NavigationOptions.PaneVisibility.CommandsView);
				return HResult.Ok;
			case "43abf98b-89b8-472d-b9ce-e69b8229f019":
				peps = ExplorerBrowser.VisibilityToPaneState(this.NavigationOptions.PaneVisibility.Details);
				return HResult.Ok;
			case "cb316b22-25f7-42b8-8a09-540d23a43c2f":
				peps = ExplorerBrowser.VisibilityToPaneState(this.NavigationOptions.PaneVisibility.Navigation);
				return HResult.Ok;
			case "893c63d1-45c8-4d17-be19-223be71be365":
				peps = ExplorerBrowser.VisibilityToPaneState(this.NavigationOptions.PaneVisibility.Preview);
				return HResult.Ok;
			case "65bcde4f-4f07-4f27-83a7-1afca4df7ddd":
				peps = ExplorerBrowser.VisibilityToPaneState(this.NavigationOptions.PaneVisibility.Query);
				return HResult.Ok;
			}
			peps = ExplorerBrowser.VisibilityToPaneState(PaneVisibilityState.Show);
			return HResult.Ok;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000073F0 File Offset: 0x000055F0
		private static ExplorerPaneState VisibilityToPaneState(PaneVisibilityState visibility)
		{
			ExplorerPaneState result;
			switch (visibility)
			{
			case PaneVisibilityState.DoNotCare:
				result = ExplorerPaneState.DoNotCare;
				break;
			case PaneVisibilityState.Hide:
				result = (ExplorerPaneState)131074;
				break;
			case PaneVisibilityState.Show:
				result = (ExplorerPaneState)131073;
				break;
			default:
				throw new ArgumentException("unexpected PaneVisibilityState");
			}
			return result;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00007434 File Offset: 0x00005634
		HResult IExplorerBrowserEvents.OnNavigationPending(IntPtr pidlFolder)
		{
			bool flag = false;
			if (this.NavigationPending != null)
			{
				NavigationPendingEventArgs navigationPendingEventArgs = new NavigationPendingEventArgs();
				navigationPendingEventArgs.PendingLocation = ShellObjectFactory.Create(pidlFolder);
				if (navigationPendingEventArgs.PendingLocation != null)
				{
					foreach (Delegate @delegate in this.NavigationPending.GetInvocationList())
					{
						@delegate.DynamicInvoke(new object[]
						{
							this,
							navigationPendingEventArgs
						});
						if (navigationPendingEventArgs.Cancel)
						{
							flag = true;
						}
					}
				}
			}
			return flag ? HResult.Canceled : HResult.Ok;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000074F0 File Offset: 0x000056F0
		HResult IExplorerBrowserEvents.OnViewCreated(object psv)
		{
			this.viewEvents.ConnectToView((IShellView)psv);
			return HResult.Ok;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00007518 File Offset: 0x00005718
		HResult IExplorerBrowserEvents.OnNavigationComplete(IntPtr pidlFolder)
		{
			this.ContentOptions.folderSettings.ViewMode = this.GetCurrentViewMode();
			if (this.NavigationComplete != null)
			{
				NavigationCompleteEventArgs navigationCompleteEventArgs = new NavigationCompleteEventArgs();
				navigationCompleteEventArgs.NewLocation = ShellObjectFactory.Create(pidlFolder);
				this.NavigationComplete(this, navigationCompleteEventArgs);
			}
			return HResult.Ok;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00007574 File Offset: 0x00005774
		HResult IExplorerBrowserEvents.OnNavigationFailed(IntPtr pidlFolder)
		{
			if (this.NavigationFailed != null)
			{
				NavigationFailedEventArgs navigationFailedEventArgs = new NavigationFailedEventArgs();
				navigationFailedEventArgs.FailedLocation = ShellObjectFactory.Create(pidlFolder);
				this.NavigationFailed(this, navigationFailedEventArgs);
			}
			return HResult.Ok;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000075B8 File Offset: 0x000057B8
		HResult ICommDlgBrowser3.OnDefaultCommand(IntPtr ppshv)
		{
			return HResult.False;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000075CC File Offset: 0x000057CC
		HResult ICommDlgBrowser3.OnStateChange(IntPtr ppshv, CommDlgBrowserStateChange uChange)
		{
			if (uChange == CommDlgBrowserStateChange.SelectionChange)
			{
				this.FireSelectionChanged();
			}
			return HResult.Ok;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000075F4 File Offset: 0x000057F4
		HResult ICommDlgBrowser3.IncludeObject(IntPtr ppshv, IntPtr pidl)
		{
			this.FireContentChanged();
			return HResult.Ok;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00007610 File Offset: 0x00005810
		HResult ICommDlgBrowser3.GetDefaultMenuText(IShellView shellView, IntPtr text, int cchMax)
		{
			return HResult.False;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00007624 File Offset: 0x00005824
		HResult ICommDlgBrowser3.GetViewFlags(out uint pdwFlags)
		{
			pdwFlags = 1U;
			return HResult.Ok;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000763C File Offset: 0x0000583C
		HResult ICommDlgBrowser3.Notify(IntPtr pshv, CommDlgBrowserNotifyType notifyType)
		{
			return HResult.Ok;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00007650 File Offset: 0x00005850
		HResult ICommDlgBrowser3.GetCurrentFilter(StringBuilder pszFileSpec, int cchFileSpec)
		{
			return HResult.Ok;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00007664 File Offset: 0x00005864
		HResult ICommDlgBrowser3.OnColumnClicked(IShellView ppshv, int iColumn)
		{
			return HResult.Ok;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00007678 File Offset: 0x00005878
		HResult ICommDlgBrowser3.OnPreViewCreated(IShellView ppshv)
		{
			return HResult.Ok;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000768C File Offset: 0x0000588C
		bool IMessageFilter.PreFilterMessage(ref Message m)
		{
			HResult hresult = HResult.False;
			if (this.explorerBrowserControl != null)
			{
				hresult = ((IInputObject)this.explorerBrowserControl).TranslateAcceleratorIO(ref m);
			}
			return hresult == HResult.Ok;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x000076C8 File Offset: 0x000058C8
		internal FolderViewMode GetCurrentViewMode()
		{
			IFolderView2 folderView = this.GetFolderView2();
			uint result = 0U;
			if (folderView != null)
			{
				try
				{
					HResult currentViewMode = folderView.GetCurrentViewMode(out result);
					if (currentViewMode != HResult.Ok)
					{
						throw new ShellException(currentViewMode);
					}
				}
				finally
				{
					Marshal.ReleaseComObject(folderView);
					folderView = null;
				}
			}
			return (FolderViewMode)result;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000772C File Offset: 0x0000592C
		internal IFolderView2 GetFolderView2()
		{
			Guid guid = new Guid("1af3a467-214f-4298-908e-06b03e0b39f9");
			IntPtr zero = IntPtr.Zero;
			IFolderView2 result;
			if (this.explorerBrowserControl != null)
			{
				HResult currentView = this.explorerBrowserControl.GetCurrentView(ref guid, out zero);
				HResult hresult = currentView;
				if (hresult != HResult.NoInterface && hresult != HResult.Fail)
				{
					if (hresult != HResult.Ok)
					{
						throw new CommonControlException(LocalizedMessages.ExplorerBrowserFailedToGetView, currentView);
					}
					result = (IFolderView2)Marshal.GetObjectForIUnknown(zero);
				}
				else
				{
					result = null;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x000077B4 File Offset: 0x000059B4
		internal IShellItemArray GetSelectedItemsArray()
		{
			IShellItemArray result = null;
			IFolderView2 folderView = this.GetFolderView2();
			if (folderView != null)
			{
				try
				{
					Guid guid = new Guid("B63EA76D-1F85-456F-A19C-48159EFA858B");
					object obj = null;
					HResult hresult = folderView.Items(1U, ref guid, out obj);
					result = (obj as IShellItemArray);
					if (hresult != HResult.Ok && hresult != HResult.ElementNotFound && hresult != HResult.Fail)
					{
						throw new CommonControlException(LocalizedMessages.ExplorerBrowserUnexpectedError, hresult);
					}
				}
				finally
				{
					Marshal.ReleaseComObject(folderView);
					folderView = null;
				}
			}
			return result;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00007854 File Offset: 0x00005A54
		internal int GetItemsCount()
		{
			int result = 0;
			IFolderView2 folderView = this.GetFolderView2();
			if (folderView != null)
			{
				try
				{
					HResult hresult = folderView.ItemCount(2U, out result);
					if (hresult != HResult.Ok && hresult != HResult.ElementNotFound && hresult != HResult.Fail)
					{
						throw new CommonControlException(LocalizedMessages.ExplorerBrowserItemCount, hresult);
					}
				}
				finally
				{
					Marshal.ReleaseComObject(folderView);
					folderView = null;
				}
			}
			return result;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x000078D4 File Offset: 0x00005AD4
		internal int GetSelectedItemsCount()
		{
			int result = 0;
			IFolderView2 folderView = this.GetFolderView2();
			if (folderView != null)
			{
				try
				{
					HResult hresult = folderView.ItemCount(1U, out result);
					if (hresult != HResult.Ok && hresult != HResult.ElementNotFound && hresult != HResult.Fail)
					{
						throw new CommonControlException(LocalizedMessages.ExplorerBrowserSelectedItemCount, hresult);
					}
				}
				finally
				{
					Marshal.ReleaseComObject(folderView);
					folderView = null;
				}
			}
			return result;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00007954 File Offset: 0x00005B54
		internal IShellItemArray GetItemsArray()
		{
			IShellItemArray result = null;
			IFolderView2 folderView = this.GetFolderView2();
			if (folderView != null)
			{
				try
				{
					Guid guid = new Guid("B63EA76D-1F85-456F-A19C-48159EFA858B");
					object obj = null;
					HResult hresult = folderView.Items(2U, ref guid, out obj);
					if (hresult != HResult.Ok && hresult != HResult.Fail && hresult != HResult.ElementNotFound && hresult != HResult.InvalidArguments)
					{
						throw new CommonControlException(LocalizedMessages.ExplorerBrowserViewItems, hresult);
					}
					result = (obj as IShellItemArray);
				}
				finally
				{
					Marshal.ReleaseComObject(folderView);
					folderView = null;
				}
			}
			return result;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00007A00 File Offset: 0x00005C00
		internal void FireSelectionChanged()
		{
			if (this.SelectionChanged != null)
			{
				this.SelectionChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00007A30 File Offset: 0x00005C30
		internal void FireContentChanged()
		{
			if (this.ItemsChanged != null)
			{
				this.ItemsChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00007A60 File Offset: 0x00005C60
		internal void FireContentEnumerationComplete()
		{
			if (this.ViewEnumerationComplete != null)
			{
				this.ViewEnumerationComplete(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00007A90 File Offset: 0x00005C90
		internal void FireSelectedItemChanged()
		{
			if (this.ViewSelectedItemChanged != null)
			{
				this.ViewSelectedItemChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x04000053 RID: 83
		private IShellItemArray shellItemsArray;

		// Token: 0x04000054 RID: 84
		private ShellObjectCollection itemsCollection;

		// Token: 0x04000055 RID: 85
		private IShellItemArray selectedShellItemsArray;

		// Token: 0x04000056 RID: 86
		private ShellObjectCollection selectedItemsCollection;

		// Token: 0x0400005E RID: 94
		internal ExplorerBrowserClass explorerBrowserControl;

		// Token: 0x0400005F RID: 95
		internal uint eventsCookie;

		// Token: 0x04000060 RID: 96
		private string propertyBagName = typeof(ExplorerBrowser).FullName;

		// Token: 0x04000061 RID: 97
		private ShellObject antecreationNavigationTarget;

		// Token: 0x04000062 RID: 98
		private ExplorerBrowserViewEvents viewEvents;
	}
}
