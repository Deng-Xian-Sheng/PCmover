using System;
using System.Collections.Generic;
using Microsoft.WindowsAPICodePack.Controls.WindowsForms;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x02000031 RID: 49
	public class ExplorerBrowserNavigationLog
	{
		// Token: 0x06000224 RID: 548 RVA: 0x00009E74 File Offset: 0x00008074
		public void ClearLog()
		{
			if (this._locations.Count != 0)
			{
				bool canNavigateBackward = this.CanNavigateBackward;
				bool canNavigateForward = this.CanNavigateForward;
				this._locations.Clear();
				this.currentLocationIndex = -1;
				NavigationLogEventArgs navigationLogEventArgs = new NavigationLogEventArgs();
				navigationLogEventArgs.LocationsChanged = true;
				navigationLogEventArgs.CanNavigateBackwardChanged = (canNavigateBackward != this.CanNavigateBackward);
				navigationLogEventArgs.CanNavigateForwardChanged = (canNavigateForward != this.CanNavigateForward);
				if (this.NavigationLogChanged != null)
				{
					this.NavigationLogChanged(this, navigationLogEventArgs);
				}
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000225 RID: 549 RVA: 0x00009F0C File Offset: 0x0000810C
		public bool CanNavigateForward
		{
			get
			{
				return this.CurrentLocationIndex < this._locations.Count - 1;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000226 RID: 550 RVA: 0x00009F34 File Offset: 0x00008134
		public bool CanNavigateBackward
		{
			get
			{
				return this.CurrentLocationIndex > 0;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000227 RID: 551 RVA: 0x0000A138 File Offset: 0x00008338
		public IEnumerable<ShellObject> Locations
		{
			get
			{
				foreach (ShellObject obj in this._locations)
				{
					yield return obj;
				}
				yield break;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000228 RID: 552 RVA: 0x0000A15C File Offset: 0x0000835C
		public int CurrentLocationIndex
		{
			get
			{
				return this.currentLocationIndex;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000229 RID: 553 RVA: 0x0000A174 File Offset: 0x00008374
		public ShellObject CurrentLocation
		{
			get
			{
				ShellObject result;
				if (this.currentLocationIndex < 0)
				{
					result = null;
				}
				else
				{
					result = this._locations[this.currentLocationIndex];
				}
				return result;
			}
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600022A RID: 554 RVA: 0x0000A1AC File Offset: 0x000083AC
		// (remove) Token: 0x0600022B RID: 555 RVA: 0x0000A1E8 File Offset: 0x000083E8
		public event EventHandler<NavigationLogEventArgs> NavigationLogChanged;

		// Token: 0x0600022C RID: 556 RVA: 0x0000A224 File Offset: 0x00008424
		internal ExplorerBrowserNavigationLog(ExplorerBrowser parent)
		{
			if (parent == null)
			{
				throw new ArgumentException(LocalizedMessages.NavigationLogNullParent, "parent");
			}
			this.parent = parent;
			this.parent.NavigationComplete += this.OnNavigationComplete;
			this.parent.NavigationFailed += this.OnNavigationFailed;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000A2A6 File Offset: 0x000084A6
		private void OnNavigationFailed(object sender, NavigationFailedEventArgs args)
		{
			this.pendingNavigation = null;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000A2B0 File Offset: 0x000084B0
		private void OnNavigationComplete(object sender, NavigationCompleteEventArgs args)
		{
			NavigationLogEventArgs navigationLogEventArgs = new NavigationLogEventArgs();
			bool canNavigateBackward = this.CanNavigateBackward;
			bool canNavigateForward = this.CanNavigateForward;
			if (this.pendingNavigation != null)
			{
				int num = 0;
				this.pendingNavigation.Location.NativeShellItem.Compare(args.NewLocation.NativeShellItem, SICHINTF.SICHINT_ALLFIELDS, out num);
				if (num != 0)
				{
					if (this.currentLocationIndex < this._locations.Count - 1)
					{
						this._locations.RemoveRange(this.currentLocationIndex + 1, this._locations.Count - (this.currentLocationIndex + 1));
					}
					this._locations.Add(args.NewLocation);
					this.currentLocationIndex = this._locations.Count - 1;
					navigationLogEventArgs.LocationsChanged = true;
				}
				else
				{
					this.currentLocationIndex = this.pendingNavigation.Index;
					navigationLogEventArgs.LocationsChanged = false;
				}
				this.pendingNavigation = null;
			}
			else
			{
				if (this.currentLocationIndex < this._locations.Count - 1)
				{
					this._locations.RemoveRange(this.currentLocationIndex + 1, this._locations.Count - (this.currentLocationIndex + 1));
				}
				this._locations.Add(args.NewLocation);
				this.currentLocationIndex = this._locations.Count - 1;
				navigationLogEventArgs.LocationsChanged = true;
			}
			navigationLogEventArgs.CanNavigateBackwardChanged = (canNavigateBackward != this.CanNavigateBackward);
			navigationLogEventArgs.CanNavigateForwardChanged = (canNavigateForward != this.CanNavigateForward);
			if (this.NavigationLogChanged != null)
			{
				this.NavigationLogChanged(this, navigationLogEventArgs);
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000A478 File Offset: 0x00008678
		internal bool NavigateLog(NavigationLogDirection direction)
		{
			int index;
			if (direction == NavigationLogDirection.Backward && this.CanNavigateBackward)
			{
				index = this.currentLocationIndex - 1;
			}
			else
			{
				if (direction != NavigationLogDirection.Forward || !this.CanNavigateForward)
				{
					return false;
				}
				index = this.currentLocationIndex + 1;
			}
			ShellObject shellObject = this._locations[index];
			this.pendingNavigation = new PendingNavigation(shellObject, index);
			this.parent.Navigate(shellObject);
			return true;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000A4FC File Offset: 0x000086FC
		internal bool NavigateLog(int index)
		{
			bool result;
			if (index >= this._locations.Count || index < 0)
			{
				result = false;
			}
			else if (index == this.currentLocationIndex)
			{
				result = false;
			}
			else
			{
				ShellObject shellObject = this._locations[index];
				this.pendingNavigation = new PendingNavigation(shellObject, index);
				this.parent.Navigate(shellObject);
				result = true;
			}
			return result;
		}

		// Token: 0x0400009F RID: 159
		private List<ShellObject> _locations = new List<ShellObject>();

		// Token: 0x040000A1 RID: 161
		private ExplorerBrowser parent = null;

		// Token: 0x040000A2 RID: 162
		private PendingNavigation pendingNavigation;

		// Token: 0x040000A3 RID: 163
		private int currentLocationIndex = -1;
	}
}
