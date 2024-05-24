using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interop;
using ControlzEx.Native;
using ControlzEx.Standard;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200009F RID: 159
	[Obsolete("This class is obsolete and will be deleted at the next major release.")]
	public class WindowSettings
	{
		// Token: 0x06000898 RID: 2200 RVA: 0x0002291B File Offset: 0x00020B1B
		public static void SetSave(DependencyObject dependencyObject, IWindowPlacementSettings windowPlacementSettings)
		{
			WindowSettings.SetWindowPlacementSettings(dependencyObject, windowPlacementSettings);
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x00022924 File Offset: 0x00020B24
		public static void SetWindowPlacementSettings(DependencyObject dependencyObject, IWindowPlacementSettings windowPlacementSettings)
		{
			dependencyObject.SetValue(WindowSettings.WindowPlacementSettingsProperty, windowPlacementSettings);
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x00022934 File Offset: 0x00020B34
		private static void OnWindowPlacementSettingsInvalidated(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			Window window = dependencyObject as Window;
			if (window == null || !(e.NewValue is IWindowPlacementSettings))
			{
				return;
			}
			new WindowSettings(window, (IWindowPlacementSettings)e.NewValue).Attach();
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x00022971 File Offset: 0x00020B71
		public WindowSettings(Window window, IWindowPlacementSettings windowPlacementSettings)
		{
			this._window = window;
			this._settings = windowPlacementSettings;
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x00022988 File Offset: 0x00020B88
		protected virtual void LoadWindowState()
		{
			if (this._settings == null)
			{
				return;
			}
			this._settings.Reload();
			if (this._settings.Placement == null || this._settings.Placement.normalPosition.IsEmpty)
			{
				return;
			}
			try
			{
				WINDOWPLACEMENT placement = this._settings.Placement;
				placement.flags = 0;
				placement.showCmd = ((placement.showCmd == SW.SHOWMINIMIZED) ? SW.SHOWNORMAL : placement.showCmd);
				NativeMethods.SetWindowPlacement(new WindowInteropHelper(this._window).Handle, placement);
			}
			catch (Exception innerException)
			{
				throw new MahAppsException("Failed to set the window state from the settings file", innerException);
			}
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x00022A30 File Offset: 0x00020C30
		protected virtual void SaveWindowState()
		{
			if (this._settings == null)
			{
				return;
			}
			IntPtr handle = new WindowInteropHelper(this._window).Handle;
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
					this._settings.Placement = windowPlacement;
				}
			}
			this._settings.Save();
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x00022AAD File Offset: 0x00020CAD
		private void Attach()
		{
			if (this._window != null)
			{
				this._window.SourceInitialized += this.WindowSourceInitialized;
				this._window.Closed += this.WindowClosed;
			}
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x00022AE5 File Offset: 0x00020CE5
		private void WindowSourceInitialized(object sender, EventArgs e)
		{
			this.LoadWindowState();
			this._window.StateChanged += this.WindowStateChanged;
			this._window.Closing += this.WindowClosing;
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x00022B1B File Offset: 0x00020D1B
		private void WindowStateChanged(object sender, EventArgs e)
		{
			if (this._window.WindowState == WindowState.Minimized)
			{
				this.SaveWindowState();
			}
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x00022B31 File Offset: 0x00020D31
		private void WindowClosing(object sender, CancelEventArgs e)
		{
			this.SaveWindowState();
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x00022B3C File Offset: 0x00020D3C
		private void WindowClosed(object sender, EventArgs e)
		{
			this.SaveWindowState();
			this._window.StateChanged -= this.WindowStateChanged;
			this._window.Closing -= this.WindowClosing;
			this._window.Closed -= this.WindowClosed;
			this._window.SourceInitialized -= this.WindowSourceInitialized;
			this._window = null;
			this._settings = null;
		}

		// Token: 0x040003E5 RID: 997
		public static readonly DependencyProperty WindowPlacementSettingsProperty = DependencyProperty.RegisterAttached("WindowPlacementSettings", typeof(IWindowPlacementSettings), typeof(WindowSettings), new FrameworkPropertyMetadata(new PropertyChangedCallback(WindowSettings.OnWindowPlacementSettingsInvalidated)));

		// Token: 0x040003E6 RID: 998
		private Window _window;

		// Token: 0x040003E7 RID: 999
		private IWindowPlacementSettings _settings;
	}
}
