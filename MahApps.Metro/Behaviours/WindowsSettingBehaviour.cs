using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Interop;
using ControlzEx.Native;
using ControlzEx.Standard;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Behaviours
{
	// Token: 0x020000BD RID: 189
	public class WindowsSettingBehaviour : Behavior<MetroWindow>
	{
		// Token: 0x06000A30 RID: 2608 RVA: 0x00027C06 File Offset: 0x00025E06
		protected override void OnAttached()
		{
			base.OnAttached();
			base.AssociatedObject.SourceInitialized += this.AssociatedObject_SourceInitialized;
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00027C25 File Offset: 0x00025E25
		protected override void OnDetaching()
		{
			this.CleanUp("from OnDetaching");
			base.OnDetaching();
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00027C38 File Offset: 0x00025E38
		private void AssociatedObject_Closed(object sender, EventArgs e)
		{
			this.CleanUp("from AssociatedObject closed event");
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00027C45 File Offset: 0x00025E45
		private void AssociatedObject_Closing(object sender, CancelEventArgs e)
		{
			this.SaveWindowState();
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00027C50 File Offset: 0x00025E50
		private void AssociatedObject_SourceInitialized(object sender, EventArgs e)
		{
			this.LoadWindowState();
			MetroWindow associatedObject = base.AssociatedObject;
			if (associatedObject == null)
			{
				return;
			}
			associatedObject.StateChanged += this.AssociatedObject_StateChanged;
			associatedObject.Closing += this.AssociatedObject_Closing;
			associatedObject.Closed += this.AssociatedObject_Closed;
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x00027CA4 File Offset: 0x00025EA4
		private void AssociatedObject_StateChanged(object sender, EventArgs e)
		{
			MetroWindow associatedObject = base.AssociatedObject;
			if (associatedObject != null && associatedObject.WindowState == WindowState.Minimized)
			{
				this.SaveWindowState();
			}
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x00027CC4 File Offset: 0x00025EC4
		private void CleanUp(string fromWhere)
		{
			MetroWindow associatedObject = base.AssociatedObject;
			if (associatedObject == null)
			{
				return;
			}
			associatedObject.StateChanged -= this.AssociatedObject_StateChanged;
			associatedObject.Closing -= this.AssociatedObject_Closing;
			associatedObject.Closed -= this.AssociatedObject_Closed;
			associatedObject.SourceInitialized -= this.AssociatedObject_SourceInitialized;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x00027D24 File Offset: 0x00025F24
		private void LoadWindowState()
		{
			MetroWindow associatedObject = base.AssociatedObject;
			if (associatedObject == null)
			{
				return;
			}
			IWindowPlacementSettings windowPlacementSettings = associatedObject.GetWindowPlacementSettings();
			if (windowPlacementSettings == null || !associatedObject.SaveWindowPosition)
			{
				return;
			}
			try
			{
				windowPlacementSettings.Reload();
			}
			catch (Exception)
			{
				return;
			}
			if (windowPlacementSettings.Placement == null || windowPlacementSettings.Placement.normalPosition.IsEmpty)
			{
				return;
			}
			try
			{
				WINDOWPLACEMENT placement = windowPlacementSettings.Placement;
				placement.flags = 0;
				placement.showCmd = ((placement.showCmd == SW.SHOWMINIMIZED) ? SW.SHOWNORMAL : placement.showCmd);
				associatedObject.Left = (double)placement.normalPosition.Left;
				associatedObject.Top = (double)placement.normalPosition.Top;
				NativeMethods.SetWindowPlacement(new WindowInteropHelper(associatedObject).Handle, placement);
			}
			catch (Exception innerException)
			{
				throw new MahAppsException("Failed to set the window state from the settings file", innerException);
			}
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00027E04 File Offset: 0x00026004
		private void SaveWindowState()
		{
			MetroWindow associatedObject = base.AssociatedObject;
			if (associatedObject == null)
			{
				return;
			}
			IWindowPlacementSettings windowPlacementSettings = associatedObject.GetWindowPlacementSettings();
			if (windowPlacementSettings == null || !associatedObject.SaveWindowPosition)
			{
				return;
			}
			IntPtr handle = new WindowInteropHelper(associatedObject).Handle;
			WINDOWPLACEMENT windowPlacement = NativeMethods.GetWindowPlacement(handle);
			if (windowPlacement.showCmd != SW.HIDE && windowPlacement.length > 0)
			{
				RECT normalPosition;
				if (windowPlacement.showCmd == SW.SHOWNORMAL && UnsafeNativeMethods.GetWindowRect(handle, out normalPosition))
				{
					windowPlacement.normalPosition = normalPosition;
				}
				if (!windowPlacement.normalPosition.IsEmpty)
				{
					windowPlacementSettings.Placement = windowPlacement;
				}
			}
			try
			{
				windowPlacementSettings.Save();
			}
			catch (Exception)
			{
			}
		}
	}
}
