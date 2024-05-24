using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x0200012B RID: 299
	public class TabbedThumbnailManager
	{
		// Token: 0x06000D41 RID: 3393 RVA: 0x000316F0 File Offset: 0x0002F8F0
		internal TabbedThumbnailManager()
		{
			this._tabbedThumbnailCache = new Dictionary<IntPtr, TabbedThumbnail>();
			this._tabbedThumbnailCacheWPF = new Dictionary<UIElement, TabbedThumbnail>();
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x00031714 File Offset: 0x0002F914
		public void AddThumbnailPreview(TabbedThumbnail preview)
		{
			if (preview == null)
			{
				throw new ArgumentNullException("preview");
			}
			if (preview.WindowHandle == IntPtr.Zero)
			{
				if (this._tabbedThumbnailCacheWPF.ContainsKey(preview.WindowsControl))
				{
					throw new ArgumentException(LocalizedMessages.ThumbnailManagerPreviewAdded, "preview");
				}
				this._tabbedThumbnailCacheWPF.Add(preview.WindowsControl, preview);
			}
			else
			{
				if (this._tabbedThumbnailCache.ContainsKey(preview.WindowHandle))
				{
					throw new ArgumentException(LocalizedMessages.ThumbnailManagerPreviewAdded, "preview");
				}
				this._tabbedThumbnailCache.Add(preview.WindowHandle, preview);
			}
			TaskbarWindowManager.AddTabbedThumbnail(preview);
			preview.InvalidatePreview();
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x000317DC File Offset: 0x0002F9DC
		public TabbedThumbnail GetThumbnailPreview(IntPtr windowHandle)
		{
			if (windowHandle == IntPtr.Zero)
			{
				throw new ArgumentException(LocalizedMessages.ThumbnailManagerInvalidHandle, "windowHandle");
			}
			TabbedThumbnail tabbedThumbnail;
			return this._tabbedThumbnailCache.TryGetValue(windowHandle, out tabbedThumbnail) ? tabbedThumbnail : null;
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x00031828 File Offset: 0x0002FA28
		public TabbedThumbnail GetThumbnailPreview(Control control)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			return this.GetThumbnailPreview(control.Handle);
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x00031860 File Offset: 0x0002FA60
		public TabbedThumbnail GetThumbnailPreview(UIElement windowsControl)
		{
			if (windowsControl == null)
			{
				throw new ArgumentNullException("windowsControl");
			}
			TabbedThumbnail tabbedThumbnail;
			return this._tabbedThumbnailCacheWPF.TryGetValue(windowsControl, out tabbedThumbnail) ? tabbedThumbnail : null;
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x000318A0 File Offset: 0x0002FAA0
		public void RemoveThumbnailPreview(TabbedThumbnail preview)
		{
			if (preview == null)
			{
				throw new ArgumentNullException("preview");
			}
			if (this._tabbedThumbnailCache.ContainsKey(preview.WindowHandle))
			{
				this.RemoveThumbnailPreview(preview.WindowHandle);
			}
			else if (this._tabbedThumbnailCacheWPF.ContainsKey(preview.WindowsControl))
			{
				this.RemoveThumbnailPreview(preview.WindowsControl);
			}
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x00031918 File Offset: 0x0002FB18
		public void RemoveThumbnailPreview(IntPtr windowHandle)
		{
			if (!this._tabbedThumbnailCache.ContainsKey(windowHandle))
			{
				throw new ArgumentException(LocalizedMessages.ThumbnailManagerControlNotAdded, "windowHandle");
			}
			TaskbarWindowManager.UnregisterTab(this._tabbedThumbnailCache[windowHandle].TaskbarWindow);
			this._tabbedThumbnailCache.Remove(windowHandle);
			TaskbarWindow taskbarWindow = TaskbarWindowManager.GetTaskbarWindow(windowHandle, TaskbarProxyWindowType.TabbedThumbnail);
			if (taskbarWindow != null)
			{
				if (TaskbarWindowManager._taskbarWindowList.Contains(taskbarWindow))
				{
					TaskbarWindowManager._taskbarWindowList.Remove(taskbarWindow);
				}
				taskbarWindow.Dispose();
			}
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x000319A4 File Offset: 0x0002FBA4
		public void RemoveThumbnailPreview(Control control)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			IntPtr handle = control.Handle;
			this.RemoveThumbnailPreview(handle);
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x000319D8 File Offset: 0x0002FBD8
		public void RemoveThumbnailPreview(UIElement windowsControl)
		{
			if (windowsControl == null)
			{
				throw new ArgumentNullException("windowsControl");
			}
			if (!this._tabbedThumbnailCacheWPF.ContainsKey(windowsControl))
			{
				throw new ArgumentException(LocalizedMessages.ThumbnailManagerControlNotAdded, "windowsControl");
			}
			TaskbarWindowManager.UnregisterTab(this._tabbedThumbnailCacheWPF[windowsControl].TaskbarWindow);
			this._tabbedThumbnailCacheWPF.Remove(windowsControl);
			TaskbarWindow taskbarWindow = TaskbarWindowManager.GetTaskbarWindow(windowsControl, TaskbarProxyWindowType.TabbedThumbnail);
			if (taskbarWindow != null)
			{
				if (TaskbarWindowManager._taskbarWindowList.Contains(taskbarWindow))
				{
					TaskbarWindowManager._taskbarWindowList.Remove(taskbarWindow);
				}
				taskbarWindow.Dispose();
			}
		}

		// Token: 0x06000D4A RID: 3402 RVA: 0x00031A80 File Offset: 0x0002FC80
		public void SetActiveTab(TabbedThumbnail preview)
		{
			if (preview == null)
			{
				throw new ArgumentNullException("preview");
			}
			if (preview.WindowHandle != IntPtr.Zero)
			{
				if (!this._tabbedThumbnailCache.ContainsKey(preview.WindowHandle))
				{
					throw new ArgumentException(LocalizedMessages.ThumbnailManagerPreviewNotAdded, "preview");
				}
				TaskbarWindowManager.SetActiveTab(this._tabbedThumbnailCache[preview.WindowHandle].TaskbarWindow);
			}
			else if (preview.WindowsControl != null)
			{
				if (!this._tabbedThumbnailCacheWPF.ContainsKey(preview.WindowsControl))
				{
					throw new ArgumentException(LocalizedMessages.ThumbnailManagerPreviewNotAdded, "preview");
				}
				TaskbarWindowManager.SetActiveTab(this._tabbedThumbnailCacheWPF[preview.WindowsControl].TaskbarWindow);
			}
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x00031B54 File Offset: 0x0002FD54
		public void SetActiveTab(IntPtr windowHandle)
		{
			if (!this._tabbedThumbnailCache.ContainsKey(windowHandle))
			{
				throw new ArgumentException(LocalizedMessages.ThumbnailManagerPreviewNotAdded, "windowHandle");
			}
			TaskbarWindowManager.SetActiveTab(this._tabbedThumbnailCache[windowHandle].TaskbarWindow);
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x00031B9C File Offset: 0x0002FD9C
		public void SetActiveTab(Control control)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			this.SetActiveTab(control.Handle);
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x00031BD0 File Offset: 0x0002FDD0
		public void SetActiveTab(UIElement windowsControl)
		{
			if (windowsControl == null)
			{
				throw new ArgumentNullException("windowsControl");
			}
			if (!this._tabbedThumbnailCacheWPF.ContainsKey(windowsControl))
			{
				throw new ArgumentException(LocalizedMessages.ThumbnailManagerPreviewNotAdded, "windowsControl");
			}
			TaskbarWindowManager.SetActiveTab(this._tabbedThumbnailCacheWPF[windowsControl].TaskbarWindow);
		}

		// Token: 0x06000D4E RID: 3406 RVA: 0x00031C30 File Offset: 0x0002FE30
		public bool IsThumbnailPreviewAdded(TabbedThumbnail preview)
		{
			if (preview == null)
			{
				throw new ArgumentNullException("preview");
			}
			return (preview.WindowHandle != IntPtr.Zero && this._tabbedThumbnailCache.ContainsKey(preview.WindowHandle)) || (preview.WindowsControl != null && this._tabbedThumbnailCacheWPF.ContainsKey(preview.WindowsControl));
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x00031CB8 File Offset: 0x0002FEB8
		public bool IsThumbnailPreviewAdded(IntPtr windowHandle)
		{
			if (windowHandle == IntPtr.Zero)
			{
				throw new ArgumentException(LocalizedMessages.ThumbnailManagerInvalidHandle, "windowHandle");
			}
			return this._tabbedThumbnailCache.ContainsKey(windowHandle);
		}

		// Token: 0x06000D50 RID: 3408 RVA: 0x00031CFC File Offset: 0x0002FEFC
		public bool IsThumbnailPreviewAdded(Control control)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			return this._tabbedThumbnailCache.ContainsKey(control.Handle);
		}

		// Token: 0x06000D51 RID: 3409 RVA: 0x00031D38 File Offset: 0x0002FF38
		public bool IsThumbnailPreviewAdded(UIElement control)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			return this._tabbedThumbnailCacheWPF.ContainsKey(control);
		}

		// Token: 0x06000D52 RID: 3410 RVA: 0x00031D70 File Offset: 0x0002FF70
		public void InvalidateThumbnails()
		{
			foreach (TabbedThumbnail tabbedThumbnail in this._tabbedThumbnailCache.Values)
			{
				TaskbarWindowManager.InvalidatePreview(tabbedThumbnail.TaskbarWindow);
				tabbedThumbnail.SetImage(IntPtr.Zero);
			}
			foreach (TabbedThumbnail tabbedThumbnail in this._tabbedThumbnailCacheWPF.Values)
			{
				TaskbarWindowManager.InvalidatePreview(tabbedThumbnail.TaskbarWindow);
				tabbedThumbnail.SetImage(IntPtr.Zero);
			}
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x00031E40 File Offset: 0x00030040
		public static void ClearThumbnailClip(IntPtr windowHandle)
		{
			TaskbarList.Instance.SetThumbnailClip(windowHandle, IntPtr.Zero);
		}

		// Token: 0x06000D54 RID: 3412 RVA: 0x00031E54 File Offset: 0x00030054
		public void SetThumbnailClip(IntPtr windowHandle, Rectangle? clippingRectangle)
		{
			if (clippingRectangle == null)
			{
				TabbedThumbnailManager.ClearThumbnailClip(windowHandle);
			}
			else
			{
				NativeRect nativeRect = new NativeRect
				{
					Left = clippingRectangle.Value.Left,
					Top = clippingRectangle.Value.Top,
					Right = clippingRectangle.Value.Right,
					Bottom = clippingRectangle.Value.Bottom
				};
				IntPtr intPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(nativeRect));
				try
				{
					Marshal.StructureToPtr(nativeRect, intPtr, true);
					TaskbarList.Instance.SetThumbnailClip(windowHandle, intPtr);
				}
				finally
				{
					Marshal.FreeCoTaskMem(intPtr);
				}
			}
		}

		// Token: 0x06000D55 RID: 3413 RVA: 0x00031F2C File Offset: 0x0003012C
		public static void SetTabOrder(TabbedThumbnail previewToChange, TabbedThumbnail insertBeforePreview)
		{
			if (previewToChange == null)
			{
				throw new ArgumentNullException("previewToChange");
			}
			IntPtr windowToTellTaskbarAbout = previewToChange.TaskbarWindow.WindowToTellTaskbarAbout;
			if (insertBeforePreview == null)
			{
				TaskbarList.Instance.SetTabOrder(windowToTellTaskbarAbout, IntPtr.Zero);
			}
			else
			{
				IntPtr windowToTellTaskbarAbout2 = insertBeforePreview.TaskbarWindow.WindowToTellTaskbarAbout;
				TaskbarList.Instance.SetTabOrder(windowToTellTaskbarAbout, windowToTellTaskbarAbout2);
			}
		}

		// Token: 0x04000505 RID: 1285
		private Dictionary<IntPtr, TabbedThumbnail> _tabbedThumbnailCache;

		// Token: 0x04000506 RID: 1286
		private Dictionary<UIElement, TabbedThumbnail> _tabbedThumbnailCacheWPF;
	}
}
