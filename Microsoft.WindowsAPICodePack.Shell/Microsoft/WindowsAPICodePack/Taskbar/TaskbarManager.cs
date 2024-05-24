using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000187 RID: 391
	public class TaskbarManager
	{
		// Token: 0x06000F29 RID: 3881 RVA: 0x000353C0 File Offset: 0x000335C0
		private TaskbarManager()
		{
			CoreHelpers.ThrowIfNotWin7();
		}

		// Token: 0x17000876 RID: 2166
		// (get) Token: 0x06000F2A RID: 3882 RVA: 0x000353D4 File Offset: 0x000335D4
		public static TaskbarManager Instance
		{
			get
			{
				if (TaskbarManager._instance == null)
				{
					lock (TaskbarManager._syncLock)
					{
						if (TaskbarManager._instance == null)
						{
							TaskbarManager._instance = new TaskbarManager();
						}
					}
				}
				return TaskbarManager._instance;
			}
		}

		// Token: 0x06000F2B RID: 3883 RVA: 0x00035444 File Offset: 0x00033644
		public void SetOverlayIcon(Icon icon, string accessibilityText)
		{
			TaskbarList.Instance.SetOverlayIcon(this.OwnerHandle, (icon != null) ? icon.Handle : IntPtr.Zero, accessibilityText);
		}

		// Token: 0x06000F2C RID: 3884 RVA: 0x0003546A File Offset: 0x0003366A
		public void SetOverlayIcon(IntPtr windowHandle, Icon icon, string accessibilityText)
		{
			TaskbarList.Instance.SetOverlayIcon(windowHandle, (icon != null) ? icon.Handle : IntPtr.Zero, accessibilityText);
		}

		// Token: 0x06000F2D RID: 3885 RVA: 0x0003548B File Offset: 0x0003368B
		public void SetOverlayIcon(Window window, Icon icon, string accessibilityText)
		{
			TaskbarList.Instance.SetOverlayIcon(new WindowInteropHelper(window).Handle, (icon != null) ? icon.Handle : IntPtr.Zero, accessibilityText);
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x000354B6 File Offset: 0x000336B6
		public void SetProgressValue(int currentValue, int maximumValue)
		{
			TaskbarList.Instance.SetProgressValue(this.OwnerHandle, (ulong)Convert.ToUInt32(currentValue), (ulong)Convert.ToUInt32(maximumValue));
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x000354D8 File Offset: 0x000336D8
		public void SetProgressValue(int currentValue, int maximumValue, IntPtr windowHandle)
		{
			TaskbarList.Instance.SetProgressValue(windowHandle, (ulong)Convert.ToUInt32(currentValue), (ulong)Convert.ToUInt32(maximumValue));
		}

		// Token: 0x06000F30 RID: 3888 RVA: 0x000354F5 File Offset: 0x000336F5
		public void SetProgressValue(int currentValue, int maximumValue, Window window)
		{
			TaskbarList.Instance.SetProgressValue(new WindowInteropHelper(window).Handle, (ulong)Convert.ToUInt32(currentValue), (ulong)Convert.ToUInt32(maximumValue));
		}

		// Token: 0x06000F31 RID: 3889 RVA: 0x0003551C File Offset: 0x0003371C
		public void SetProgressState(TaskbarProgressBarState state)
		{
			TaskbarList.Instance.SetProgressState(this.OwnerHandle, (TaskbarProgressBarStatus)state);
		}

		// Token: 0x06000F32 RID: 3890 RVA: 0x00035531 File Offset: 0x00033731
		public void SetProgressState(TaskbarProgressBarState state, IntPtr windowHandle)
		{
			TaskbarList.Instance.SetProgressState(windowHandle, (TaskbarProgressBarStatus)state);
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x00035541 File Offset: 0x00033741
		public void SetProgressState(TaskbarProgressBarState state, Window window)
		{
			TaskbarList.Instance.SetProgressState(new WindowInteropHelper(window).Handle, (TaskbarProgressBarStatus)state);
		}

		// Token: 0x17000877 RID: 2167
		// (get) Token: 0x06000F34 RID: 3892 RVA: 0x0003555C File Offset: 0x0003375C
		public TabbedThumbnailManager TabbedThumbnail
		{
			get
			{
				if (this._tabbedThumbnail == null)
				{
					this._tabbedThumbnail = new TabbedThumbnailManager();
				}
				return this._tabbedThumbnail;
			}
		}

		// Token: 0x17000878 RID: 2168
		// (get) Token: 0x06000F35 RID: 3893 RVA: 0x00035594 File Offset: 0x00033794
		public ThumbnailToolBarManager ThumbnailToolBars
		{
			get
			{
				if (this._thumbnailToolBarManager == null)
				{
					this._thumbnailToolBarManager = new ThumbnailToolBarManager();
				}
				return this._thumbnailToolBarManager;
			}
		}

		// Token: 0x17000879 RID: 2169
		// (get) Token: 0x06000F36 RID: 3894 RVA: 0x000355CC File Offset: 0x000337CC
		// (set) Token: 0x06000F37 RID: 3895 RVA: 0x000355E4 File Offset: 0x000337E4
		public string ApplicationId
		{
			get
			{
				return this.GetCurrentProcessAppId();
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("value");
				}
				this.SetCurrentProcessAppId(value);
				this.ApplicationIdSetProcessWide = true;
			}
		}

		// Token: 0x1700087A RID: 2170
		// (get) Token: 0x06000F38 RID: 3896 RVA: 0x0003561C File Offset: 0x0003381C
		internal IntPtr OwnerHandle
		{
			get
			{
				if (this._ownerHandle == IntPtr.Zero)
				{
					Process currentProcess = Process.GetCurrentProcess();
					if (currentProcess == null || currentProcess.MainWindowHandle == IntPtr.Zero)
					{
						throw new InvalidOperationException(LocalizedMessages.TaskbarManagerValidWindowRequired);
					}
					this._ownerHandle = currentProcess.MainWindowHandle;
				}
				return this._ownerHandle;
			}
		}

		// Token: 0x06000F39 RID: 3897 RVA: 0x00035689 File Offset: 0x00033889
		public void SetApplicationIdForSpecificWindow(IntPtr windowHandle, string appId)
		{
			TaskbarNativeMethods.SetWindowAppId(windowHandle, appId);
		}

		// Token: 0x06000F3A RID: 3898 RVA: 0x00035694 File Offset: 0x00033894
		public void SetApplicationIdForSpecificWindow(Window window, string appId)
		{
			TaskbarNativeMethods.SetWindowAppId(new WindowInteropHelper(window).Handle, appId);
		}

		// Token: 0x06000F3B RID: 3899 RVA: 0x000356A9 File Offset: 0x000338A9
		private void SetCurrentProcessAppId(string appId)
		{
			TaskbarNativeMethods.SetCurrentProcessExplicitAppUserModelID(appId);
		}

		// Token: 0x06000F3C RID: 3900 RVA: 0x000356B4 File Offset: 0x000338B4
		private string GetCurrentProcessAppId()
		{
			string empty = string.Empty;
			TaskbarNativeMethods.GetCurrentProcessExplicitAppUserModelID(out empty);
			return empty;
		}

		// Token: 0x1700087B RID: 2171
		// (get) Token: 0x06000F3D RID: 3901 RVA: 0x000356D8 File Offset: 0x000338D8
		// (set) Token: 0x06000F3E RID: 3902 RVA: 0x000356EF File Offset: 0x000338EF
		internal bool ApplicationIdSetProcessWide { get; private set; }

		// Token: 0x1700087C RID: 2172
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x000356F8 File Offset: 0x000338F8
		public static bool IsPlatformSupported
		{
			get
			{
				return CoreHelpers.RunningOnWin7;
			}
		}

		// Token: 0x04000672 RID: 1650
		private static object _syncLock = new object();

		// Token: 0x04000673 RID: 1651
		private static TaskbarManager _instance;

		// Token: 0x04000674 RID: 1652
		private TabbedThumbnailManager _tabbedThumbnail;

		// Token: 0x04000675 RID: 1653
		private ThumbnailToolBarManager _thumbnailToolBarManager;

		// Token: 0x04000676 RID: 1654
		private IntPtr _ownerHandle;
	}
}
