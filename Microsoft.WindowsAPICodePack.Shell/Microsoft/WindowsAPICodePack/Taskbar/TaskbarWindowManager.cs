using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000189 RID: 393
	internal static class TaskbarWindowManager
	{
		// Token: 0x06000F5A RID: 3930 RVA: 0x00035C08 File Offset: 0x00033E08
		internal static void AddThumbnailButtons(IntPtr userWindowHandle, params ThumbnailToolBarButton[] buttons)
		{
			TaskbarWindow taskbarWindow = TaskbarWindowManager.GetTaskbarWindow(userWindowHandle, TaskbarProxyWindowType.ThumbnailToolbar);
			TaskbarWindow taskbarWindow2 = null;
			try
			{
				TaskbarWindow taskbarWindow3;
				if ((taskbarWindow3 = taskbarWindow) == null)
				{
					taskbarWindow3 = (taskbarWindow2 = new TaskbarWindow(userWindowHandle, buttons));
				}
				TaskbarWindowManager.AddThumbnailButtons(taskbarWindow3, taskbarWindow == null, buttons);
			}
			catch
			{
				if (taskbarWindow2 != null)
				{
					taskbarWindow2.Dispose();
				}
				throw;
			}
		}

		// Token: 0x06000F5B RID: 3931 RVA: 0x00035C64 File Offset: 0x00033E64
		internal static void AddThumbnailButtons(UIElement control, params ThumbnailToolBarButton[] buttons)
		{
			TaskbarWindow taskbarWindow = TaskbarWindowManager.GetTaskbarWindow(control, TaskbarProxyWindowType.ThumbnailToolbar);
			TaskbarWindow taskbarWindow2 = null;
			try
			{
				TaskbarWindow taskbarWindow3;
				if ((taskbarWindow3 = taskbarWindow) == null)
				{
					taskbarWindow3 = (taskbarWindow2 = new TaskbarWindow(control, buttons));
				}
				TaskbarWindowManager.AddThumbnailButtons(taskbarWindow3, taskbarWindow == null, buttons);
			}
			catch
			{
				if (taskbarWindow2 != null)
				{
					taskbarWindow2.Dispose();
				}
				throw;
			}
		}

		// Token: 0x06000F5C RID: 3932 RVA: 0x00035CC0 File Offset: 0x00033EC0
		private static void AddThumbnailButtons(TaskbarWindow taskbarWindow, bool add, params ThumbnailToolBarButton[] buttons)
		{
			if (add)
			{
				TaskbarWindowManager._taskbarWindowList.Add(taskbarWindow);
			}
			else
			{
				if (taskbarWindow.ThumbnailButtons != null)
				{
					throw new InvalidOperationException(LocalizedMessages.TaskbarWindowManagerButtonsAlreadyAdded);
				}
				taskbarWindow.ThumbnailButtons = buttons;
			}
		}

		// Token: 0x06000F5D RID: 3933 RVA: 0x00035D10 File Offset: 0x00033F10
		internal static void AddTabbedThumbnail(TabbedThumbnail preview)
		{
			TaskbarWindow taskbarWindow;
			if (preview.WindowHandle == IntPtr.Zero)
			{
				taskbarWindow = TaskbarWindowManager.GetTaskbarWindow(preview.WindowsControl, TaskbarProxyWindowType.TabbedThumbnail);
			}
			else
			{
				taskbarWindow = TaskbarWindowManager.GetTaskbarWindow(preview.WindowHandle, TaskbarProxyWindowType.TabbedThumbnail);
			}
			if (taskbarWindow == null)
			{
				taskbarWindow = new TaskbarWindow(preview);
				TaskbarWindowManager._taskbarWindowList.Add(taskbarWindow);
			}
			else if (taskbarWindow.TabbedThumbnail == null)
			{
				taskbarWindow.TabbedThumbnail = preview;
			}
			preview.TitleChanged += TaskbarWindowManager.thumbnailPreview_TitleChanged;
			preview.TooltipChanged += TaskbarWindowManager.thumbnailPreview_TooltipChanged;
			IntPtr windowToTellTaskbarAbout = taskbarWindow.WindowToTellTaskbarAbout;
			TaskbarList.Instance.RegisterTab(windowToTellTaskbarAbout, preview.ParentWindowHandle);
			TaskbarList.Instance.SetTabOrder(windowToTellTaskbarAbout, IntPtr.Zero);
			TaskbarList.Instance.SetTabActive(windowToTellTaskbarAbout, preview.ParentWindowHandle, 0U);
			TabbedThumbnailNativeMethods.ChangeWindowMessageFilter(803U, 1U);
			TabbedThumbnailNativeMethods.ChangeWindowMessageFilter(806U, 1U);
			TabbedThumbnailNativeMethods.EnableCustomWindowPreview(windowToTellTaskbarAbout, true);
			TaskbarWindowManager.thumbnailPreview_TitleChanged(preview, EventArgs.Empty);
			TaskbarWindowManager.thumbnailPreview_TooltipChanged(preview, EventArgs.Empty);
			preview.AddedToTaskbar = true;
		}

		// Token: 0x06000F5E RID: 3934 RVA: 0x00035E90 File Offset: 0x00034090
		internal static TaskbarWindow GetTaskbarWindow(UIElement windowsControl, TaskbarProxyWindowType taskbarProxyWindowType)
		{
			if (windowsControl == null)
			{
				throw new ArgumentNullException("windowsControl");
			}
			TaskbarWindow taskbarWindow = TaskbarWindowManager._taskbarWindowList.FirstOrDefault((TaskbarWindow window) => (window.TabbedThumbnail != null && window.TabbedThumbnail.WindowsControl == windowsControl) || (window.ThumbnailToolbarProxyWindow != null && window.ThumbnailToolbarProxyWindow.WindowsControl == windowsControl));
			if (taskbarWindow != null)
			{
				if (taskbarProxyWindowType == TaskbarProxyWindowType.ThumbnailToolbar)
				{
					taskbarWindow.EnableThumbnailToolbars = true;
				}
				else if (taskbarProxyWindowType == TaskbarProxyWindowType.TabbedThumbnail)
				{
					taskbarWindow.EnableTabbedThumbnails = true;
				}
			}
			return taskbarWindow;
		}

		// Token: 0x06000F5F RID: 3935 RVA: 0x00035F48 File Offset: 0x00034148
		internal static TaskbarWindow GetTaskbarWindow(IntPtr userWindowHandle, TaskbarProxyWindowType taskbarProxyWindowType)
		{
			if (userWindowHandle == IntPtr.Zero)
			{
				throw new ArgumentException(LocalizedMessages.CommonFileDialogInvalidHandle, "userWindowHandle");
			}
			TaskbarWindow taskbarWindow = TaskbarWindowManager._taskbarWindowList.FirstOrDefault((TaskbarWindow window) => window.UserWindowHandle == userWindowHandle);
			if (taskbarWindow != null)
			{
				if (taskbarProxyWindowType == TaskbarProxyWindowType.ThumbnailToolbar)
				{
					taskbarWindow.EnableThumbnailToolbars = true;
				}
				else if (taskbarProxyWindowType == TaskbarProxyWindowType.TabbedThumbnail)
				{
					taskbarWindow.EnableTabbedThumbnails = true;
				}
			}
			return taskbarWindow;
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x0003600C File Offset: 0x0003420C
		private static void DispatchTaskbarButtonMessages(ref Message m, TaskbarWindow taskbarWindow)
		{
			if (m.Msg == (int)TaskbarNativeMethods.WmTaskbarButtonCreated)
			{
				TaskbarWindowManager.AddButtons(taskbarWindow);
			}
			else
			{
				if (!TaskbarWindowManager._buttonsAdded)
				{
					TaskbarWindowManager.AddButtons(taskbarWindow);
				}
				if (m.Msg == 273 && CoreNativeMethods.GetHiWord(m.WParam.ToInt64(), 16) == 6144)
				{
					int buttonId = CoreNativeMethods.GetLoWord(m.WParam.ToInt64());
					IEnumerable<ThumbnailToolBarButton> enumerable = from b in taskbarWindow.ThumbnailButtons
					where (ulong)b.Id == (ulong)((long)buttonId)
					select b;
					foreach (ThumbnailToolBarButton thumbnailToolBarButton in enumerable)
					{
						thumbnailToolBarButton.FireClick(taskbarWindow);
					}
				}
			}
		}

		// Token: 0x06000F61 RID: 3937 RVA: 0x0003610C File Offset: 0x0003430C
		private static bool DispatchActivateMessage(ref Message m, TaskbarWindow taskbarWindow)
		{
			bool result;
			if (m.Msg == 6)
			{
				taskbarWindow.TabbedThumbnail.OnTabbedThumbnailActivated();
				TaskbarWindowManager.SetActiveTab(taskbarWindow);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000F62 RID: 3938 RVA: 0x00036148 File Offset: 0x00034348
		private static bool DispatchSendIconThumbnailMessage(ref Message m, TaskbarWindow taskbarWindow)
		{
			bool result;
			if (m.Msg == 803)
			{
				int width = (int)((long)m.LParam >> 16);
				int height = (int)((long)m.LParam & 65535L);
				System.Drawing.Size size = new System.Drawing.Size(width, height);
				taskbarWindow.TabbedThumbnail.OnTabbedThumbnailBitmapRequested();
				IntPtr intPtr = IntPtr.Zero;
				System.Drawing.Size requestedSize = new System.Drawing.Size(200, 200);
				if (taskbarWindow.TabbedThumbnail.WindowHandle != IntPtr.Zero)
				{
					TabbedThumbnailNativeMethods.GetClientSize(taskbarWindow.TabbedThumbnail.WindowHandle, out requestedSize);
				}
				else if (taskbarWindow.TabbedThumbnail.WindowsControl != null)
				{
					requestedSize = new System.Drawing.Size(Convert.ToInt32(taskbarWindow.TabbedThumbnail.WindowsControl.RenderSize.Width), Convert.ToInt32(taskbarWindow.TabbedThumbnail.WindowsControl.RenderSize.Height));
				}
				if (requestedSize.Height == -1 && requestedSize.Width == -1)
				{
					requestedSize.Width = (requestedSize.Height = 199);
				}
				if (taskbarWindow.TabbedThumbnail.ClippingRectangle != null && taskbarWindow.TabbedThumbnail.ClippingRectangle.Value != Rectangle.Empty)
				{
					if (taskbarWindow.TabbedThumbnail.CurrentHBitmap == IntPtr.Zero)
					{
						intPtr = TaskbarWindowManager.GrabBitmap(taskbarWindow, requestedSize);
					}
					else
					{
						intPtr = taskbarWindow.TabbedThumbnail.CurrentHBitmap;
					}
					Bitmap bitmap = Image.FromHbitmap(intPtr);
					Rectangle value = taskbarWindow.TabbedThumbnail.ClippingRectangle.Value;
					if (value.Height > size.Height)
					{
						value.Height = size.Height;
					}
					if (value.Width > size.Width)
					{
						value.Width = size.Width;
					}
					bitmap = bitmap.Clone(value, bitmap.PixelFormat);
					if (intPtr != IntPtr.Zero && taskbarWindow.TabbedThumbnail.CurrentHBitmap == IntPtr.Zero)
					{
						ShellNativeMethods.DeleteObject(intPtr);
					}
					intPtr = bitmap.GetHbitmap();
					bitmap.Dispose();
				}
				else
				{
					intPtr = taskbarWindow.TabbedThumbnail.CurrentHBitmap;
					if (intPtr == IntPtr.Zero)
					{
						intPtr = TaskbarWindowManager.GrabBitmap(taskbarWindow, requestedSize);
					}
				}
				if (intPtr != IntPtr.Zero)
				{
					Bitmap bitmap2 = TabbedThumbnailScreenCapture.ResizeImageWithAspect(intPtr, size.Width, size.Height, true);
					if (taskbarWindow.TabbedThumbnail.CurrentHBitmap == IntPtr.Zero)
					{
						ShellNativeMethods.DeleteObject(intPtr);
					}
					intPtr = bitmap2.GetHbitmap();
					TabbedThumbnailNativeMethods.SetIconicThumbnail(taskbarWindow.WindowToTellTaskbarAbout, intPtr);
					bitmap2.Dispose();
				}
				if (taskbarWindow.TabbedThumbnail.CurrentHBitmap == IntPtr.Zero)
				{
					ShellNativeMethods.DeleteObject(intPtr);
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000F63 RID: 3939 RVA: 0x000364B4 File Offset: 0x000346B4
		private static bool DispatchLivePreviewBitmapMessage(ref Message m, TaskbarWindow taskbarWindow)
		{
			bool result;
			if (m.Msg == 806)
			{
				int num = (int)((long)m.LParam >> 16);
				int num2 = (int)((long)m.LParam & 65535L);
				System.Drawing.Size requestedSize = new System.Drawing.Size(200, 200);
				if (taskbarWindow.TabbedThumbnail.WindowHandle != IntPtr.Zero)
				{
					TabbedThumbnailNativeMethods.GetClientSize(taskbarWindow.TabbedThumbnail.WindowHandle, out requestedSize);
				}
				else if (taskbarWindow.TabbedThumbnail.WindowsControl != null)
				{
					requestedSize = new System.Drawing.Size(Convert.ToInt32(taskbarWindow.TabbedThumbnail.WindowsControl.RenderSize.Width), Convert.ToInt32(taskbarWindow.TabbedThumbnail.WindowsControl.RenderSize.Height));
				}
				if (num <= 0)
				{
					num = requestedSize.Width;
				}
				if (num2 <= 0)
				{
					num2 = requestedSize.Height;
				}
				taskbarWindow.TabbedThumbnail.OnTabbedThumbnailBitmapRequested();
				IntPtr intPtr = (taskbarWindow.TabbedThumbnail.CurrentHBitmap == IntPtr.Zero) ? TaskbarWindowManager.GrabBitmap(taskbarWindow, requestedSize) : taskbarWindow.TabbedThumbnail.CurrentHBitmap;
				if (taskbarWindow.TabbedThumbnail.ParentWindowHandle != IntPtr.Zero && taskbarWindow.TabbedThumbnail.WindowHandle != IntPtr.Zero)
				{
					System.Drawing.Point offset = default(System.Drawing.Point);
					if (taskbarWindow.TabbedThumbnail.PeekOffset == null)
					{
						offset = WindowUtilities.GetParentOffsetOfChild(taskbarWindow.TabbedThumbnail.WindowHandle, taskbarWindow.TabbedThumbnail.ParentWindowHandle);
					}
					else
					{
						offset = new System.Drawing.Point(Convert.ToInt32(taskbarWindow.TabbedThumbnail.PeekOffset.Value.X), Convert.ToInt32(taskbarWindow.TabbedThumbnail.PeekOffset.Value.Y));
					}
					if (intPtr != IntPtr.Zero)
					{
						if (offset.X >= 0 && offset.Y >= 0)
						{
							TabbedThumbnailNativeMethods.SetPeekBitmap(taskbarWindow.WindowToTellTaskbarAbout, intPtr, offset, taskbarWindow.TabbedThumbnail.DisplayFrameAroundBitmap);
						}
					}
					if (taskbarWindow.TabbedThumbnail.CurrentHBitmap == IntPtr.Zero)
					{
						ShellNativeMethods.DeleteObject(intPtr);
					}
					result = true;
				}
				else if (taskbarWindow.TabbedThumbnail.ParentWindowHandle != IntPtr.Zero && taskbarWindow.TabbedThumbnail.WindowsControl != null)
				{
					System.Windows.Point point;
					if (taskbarWindow.TabbedThumbnail.PeekOffset == null)
					{
						GeneralTransform generalTransform = taskbarWindow.TabbedThumbnail.WindowsControl.TransformToVisual(taskbarWindow.TabbedThumbnail.WindowsControlParentWindow);
						point = generalTransform.Transform(new System.Windows.Point(0.0, 0.0));
					}
					else
					{
						point = new System.Windows.Point(taskbarWindow.TabbedThumbnail.PeekOffset.Value.X, taskbarWindow.TabbedThumbnail.PeekOffset.Value.Y);
					}
					if (intPtr != IntPtr.Zero)
					{
						if (point.X >= 0.0 && point.Y >= 0.0)
						{
							TabbedThumbnailNativeMethods.SetPeekBitmap(taskbarWindow.WindowToTellTaskbarAbout, intPtr, new System.Drawing.Point((int)point.X, (int)point.Y), taskbarWindow.TabbedThumbnail.DisplayFrameAroundBitmap);
						}
						else
						{
							TabbedThumbnailNativeMethods.SetPeekBitmap(taskbarWindow.WindowToTellTaskbarAbout, intPtr, taskbarWindow.TabbedThumbnail.DisplayFrameAroundBitmap);
						}
					}
					if (taskbarWindow.TabbedThumbnail.CurrentHBitmap == IntPtr.Zero)
					{
						ShellNativeMethods.DeleteObject(intPtr);
					}
					result = true;
				}
				else
				{
					bool flag = 1 == 0;
					TabbedThumbnailNativeMethods.SetPeekBitmap(taskbarWindow.WindowToTellTaskbarAbout, intPtr, taskbarWindow.TabbedThumbnail.DisplayFrameAroundBitmap);
					if (taskbarWindow.TabbedThumbnail.CurrentHBitmap == IntPtr.Zero)
					{
						ShellNativeMethods.DeleteObject(intPtr);
					}
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000F64 RID: 3940 RVA: 0x00036938 File Offset: 0x00034B38
		private static bool DispatchDestroyMessage(ref Message m, TaskbarWindow taskbarWindow)
		{
			bool result;
			if (m.Msg == 2)
			{
				TaskbarList.Instance.UnregisterTab(taskbarWindow.WindowToTellTaskbarAbout);
				taskbarWindow.TabbedThumbnail.RemovedFromTaskbar = true;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000F65 RID: 3941 RVA: 0x00036980 File Offset: 0x00034B80
		private static bool DispatchNCDestroyMessage(ref Message m, TaskbarWindow taskbarWindow)
		{
			bool result;
			if (m.Msg == 130)
			{
				taskbarWindow.TabbedThumbnail.OnTabbedThumbnailClosed();
				if (TaskbarWindowManager._taskbarWindowList.Contains(taskbarWindow))
				{
					TaskbarWindowManager._taskbarWindowList.Remove(taskbarWindow);
				}
				taskbarWindow.Dispose();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000F66 RID: 3942 RVA: 0x000369E0 File Offset: 0x00034BE0
		private static bool DispatchSystemCommandMessage(ref Message m, TaskbarWindow taskbarWindow)
		{
			bool result;
			if (m.Msg == 274)
			{
				if ((int)m.WParam == 61536)
				{
					if (taskbarWindow.TabbedThumbnail.OnTabbedThumbnailClosed())
					{
						if (TaskbarWindowManager._taskbarWindowList.Contains(taskbarWindow))
						{
							TaskbarWindowManager._taskbarWindowList.Remove(taskbarWindow);
						}
						taskbarWindow.Dispose();
						taskbarWindow = null;
					}
				}
				else if ((int)m.WParam == 61488)
				{
					taskbarWindow.TabbedThumbnail.OnTabbedThumbnailMaximized();
				}
				else if ((int)m.WParam == 61472)
				{
					taskbarWindow.TabbedThumbnail.OnTabbedThumbnailMinimized();
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x00036ABC File Offset: 0x00034CBC
		internal static bool DispatchMessage(ref Message m, TaskbarWindow taskbarWindow)
		{
			if (taskbarWindow.EnableThumbnailToolbars)
			{
				TaskbarWindowManager.DispatchTaskbarButtonMessages(ref m, taskbarWindow);
			}
			if (taskbarWindow.EnableTabbedThumbnails)
			{
				if (taskbarWindow.TabbedThumbnail == null || taskbarWindow.TabbedThumbnail.RemovedFromTaskbar)
				{
					return false;
				}
				if (TaskbarWindowManager.DispatchActivateMessage(ref m, taskbarWindow))
				{
					return true;
				}
				if (TaskbarWindowManager.DispatchSendIconThumbnailMessage(ref m, taskbarWindow))
				{
					return true;
				}
				if (TaskbarWindowManager.DispatchLivePreviewBitmapMessage(ref m, taskbarWindow))
				{
					return true;
				}
				if (TaskbarWindowManager.DispatchDestroyMessage(ref m, taskbarWindow))
				{
					return true;
				}
				if (TaskbarWindowManager.DispatchNCDestroyMessage(ref m, taskbarWindow))
				{
					return true;
				}
				if (TaskbarWindowManager.DispatchSystemCommandMessage(ref m, taskbarWindow))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x00036B90 File Offset: 0x00034D90
		private static IntPtr GrabBitmap(TaskbarWindow taskbarWindow, System.Drawing.Size requestedSize)
		{
			IntPtr result = IntPtr.Zero;
			if (taskbarWindow.TabbedThumbnail.WindowHandle != IntPtr.Zero)
			{
				if (taskbarWindow.TabbedThumbnail.CurrentHBitmap == IntPtr.Zero)
				{
					using (Bitmap bitmap = TabbedThumbnailScreenCapture.GrabWindowBitmap(taskbarWindow.TabbedThumbnail.WindowHandle, requestedSize))
					{
						result = bitmap.GetHbitmap();
					}
				}
				else
				{
					using (Image image = Image.FromHbitmap(taskbarWindow.TabbedThumbnail.CurrentHBitmap))
					{
						using (Bitmap bitmap = new Bitmap(image, requestedSize))
						{
							result = ((bitmap != null) ? bitmap.GetHbitmap() : IntPtr.Zero);
						}
					}
				}
			}
			else if (taskbarWindow.TabbedThumbnail.WindowsControl != null)
			{
				if (taskbarWindow.TabbedThumbnail.CurrentHBitmap == IntPtr.Zero)
				{
					Bitmap bitmap = TabbedThumbnailScreenCapture.GrabWindowBitmap(taskbarWindow.TabbedThumbnail.WindowsControl, 96, 96, requestedSize.Width, requestedSize.Height);
					if (bitmap != null)
					{
						result = bitmap.GetHbitmap();
						bitmap.Dispose();
					}
				}
				else
				{
					using (Image image = Image.FromHbitmap(taskbarWindow.TabbedThumbnail.CurrentHBitmap))
					{
						using (Bitmap bitmap = new Bitmap(image, requestedSize))
						{
							result = ((bitmap != null) ? bitmap.GetHbitmap() : IntPtr.Zero);
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000F69 RID: 3945 RVA: 0x00036D94 File Offset: 0x00034F94
		internal static void SetActiveTab(TaskbarWindow taskbarWindow)
		{
			if (taskbarWindow != null)
			{
				TaskbarList.Instance.SetTabActive(taskbarWindow.WindowToTellTaskbarAbout, taskbarWindow.TabbedThumbnail.ParentWindowHandle, 0U);
			}
		}

		// Token: 0x06000F6A RID: 3946 RVA: 0x00036DCC File Offset: 0x00034FCC
		internal static void UnregisterTab(TaskbarWindow taskbarWindow)
		{
			if (taskbarWindow != null)
			{
				TaskbarList.Instance.UnregisterTab(taskbarWindow.WindowToTellTaskbarAbout);
			}
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x00036DF8 File Offset: 0x00034FF8
		internal static void InvalidatePreview(TaskbarWindow taskbarWindow)
		{
			if (taskbarWindow != null)
			{
				TabbedThumbnailNativeMethods.DwmInvalidateIconicBitmaps(taskbarWindow.WindowToTellTaskbarAbout);
			}
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x00036E34 File Offset: 0x00035034
		private static void AddButtons(TaskbarWindow taskbarWindow)
		{
			ThumbButton[] pButtons = (from thumbButton in taskbarWindow.ThumbnailButtons
			select thumbButton.Win32ThumbButton).ToArray<ThumbButton>();
			HResult result = TaskbarList.Instance.ThumbBarAddButtons(taskbarWindow.WindowToTellTaskbarAbout, (uint)taskbarWindow.ThumbnailButtons.Length, pButtons);
			if (!CoreErrorHelper.Succeeded(result))
			{
				throw new ShellException(result);
			}
			TaskbarWindowManager._buttonsAdded = true;
			foreach (ThumbnailToolBarButton thumbnailToolBarButton in taskbarWindow.ThumbnailButtons)
			{
				thumbnailToolBarButton.AddedToTaskbar = TaskbarWindowManager._buttonsAdded;
			}
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x00036ED8 File Offset: 0x000350D8
		private static void thumbnailPreview_TooltipChanged(object sender, EventArgs e)
		{
			TabbedThumbnail tabbedThumbnail = sender as TabbedThumbnail;
			TaskbarWindow taskbarWindow;
			if (tabbedThumbnail.WindowHandle == IntPtr.Zero)
			{
				taskbarWindow = TaskbarWindowManager.GetTaskbarWindow(tabbedThumbnail.WindowsControl, TaskbarProxyWindowType.TabbedThumbnail);
			}
			else
			{
				taskbarWindow = TaskbarWindowManager.GetTaskbarWindow(tabbedThumbnail.WindowHandle, TaskbarProxyWindowType.TabbedThumbnail);
			}
			if (taskbarWindow != null)
			{
				TaskbarList.Instance.SetThumbnailTooltip(taskbarWindow.WindowToTellTaskbarAbout, tabbedThumbnail.Tooltip);
			}
		}

		// Token: 0x06000F6E RID: 3950 RVA: 0x00036F48 File Offset: 0x00035148
		private static void thumbnailPreview_TitleChanged(object sender, EventArgs e)
		{
			TabbedThumbnail tabbedThumbnail = sender as TabbedThumbnail;
			TaskbarWindow taskbarWindow;
			if (tabbedThumbnail.WindowHandle == IntPtr.Zero)
			{
				taskbarWindow = TaskbarWindowManager.GetTaskbarWindow(tabbedThumbnail.WindowsControl, TaskbarProxyWindowType.TabbedThumbnail);
			}
			else
			{
				taskbarWindow = TaskbarWindowManager.GetTaskbarWindow(tabbedThumbnail.WindowHandle, TaskbarProxyWindowType.TabbedThumbnail);
			}
			if (taskbarWindow != null)
			{
				taskbarWindow.SetTitle(tabbedThumbnail.Title);
			}
		}

		// Token: 0x04000680 RID: 1664
		internal static List<TaskbarWindow> _taskbarWindowList = new List<TaskbarWindow>();

		// Token: 0x04000681 RID: 1665
		private static bool _buttonsAdded;
	}
}
