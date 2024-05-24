using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x0200012D RID: 301
	public class TabbedThumbnail : IDisposable
	{
		// Token: 0x17000834 RID: 2100
		// (get) Token: 0x06000D5A RID: 3418 RVA: 0x00031FD0 File Offset: 0x000301D0
		// (set) Token: 0x06000D5B RID: 3419 RVA: 0x00031FE7 File Offset: 0x000301E7
		internal IntPtr WindowHandle { get; set; }

		// Token: 0x17000835 RID: 2101
		// (get) Token: 0x06000D5C RID: 3420 RVA: 0x00031FF0 File Offset: 0x000301F0
		// (set) Token: 0x06000D5D RID: 3421 RVA: 0x00032007 File Offset: 0x00030207
		internal IntPtr ParentWindowHandle { get; set; }

		// Token: 0x17000836 RID: 2102
		// (get) Token: 0x06000D5E RID: 3422 RVA: 0x00032010 File Offset: 0x00030210
		// (set) Token: 0x06000D5F RID: 3423 RVA: 0x00032027 File Offset: 0x00030227
		internal UIElement WindowsControl { get; set; }

		// Token: 0x17000837 RID: 2103
		// (get) Token: 0x06000D60 RID: 3424 RVA: 0x00032030 File Offset: 0x00030230
		// (set) Token: 0x06000D61 RID: 3425 RVA: 0x00032047 File Offset: 0x00030247
		internal Window WindowsControlParentWindow { get; set; }

		// Token: 0x17000838 RID: 2104
		// (get) Token: 0x06000D62 RID: 3426 RVA: 0x00032050 File Offset: 0x00030250
		// (set) Token: 0x06000D63 RID: 3427 RVA: 0x00032068 File Offset: 0x00030268
		internal TaskbarWindow TaskbarWindow
		{
			get
			{
				return this._taskbarWindow;
			}
			set
			{
				this._taskbarWindow = value;
				if (this._taskbarWindow != null && this._taskbarWindow.TabbedThumbnailProxyWindow != null)
				{
					this._taskbarWindow.TabbedThumbnailProxyWindow.Icon = this.Icon;
				}
			}
		}

		// Token: 0x17000839 RID: 2105
		// (get) Token: 0x06000D64 RID: 3428 RVA: 0x000320B4 File Offset: 0x000302B4
		// (set) Token: 0x06000D65 RID: 3429 RVA: 0x000320CC File Offset: 0x000302CC
		internal bool AddedToTaskbar
		{
			get
			{
				return this._addedToTaskbar;
			}
			set
			{
				this._addedToTaskbar = value;
				if (this.ClippingRectangle != null)
				{
					TaskbarWindowManager.InvalidatePreview(this.TaskbarWindow);
				}
			}
		}

		// Token: 0x1700083A RID: 2106
		// (get) Token: 0x06000D66 RID: 3430 RVA: 0x00032104 File Offset: 0x00030304
		// (set) Token: 0x06000D67 RID: 3431 RVA: 0x0003211B File Offset: 0x0003031B
		internal bool RemovedFromTaskbar { get; set; }

		// Token: 0x06000D68 RID: 3432 RVA: 0x00032124 File Offset: 0x00030324
		public TabbedThumbnail(IntPtr parentWindowHandle, IntPtr windowHandle)
		{
			if (parentWindowHandle == IntPtr.Zero)
			{
				throw new ArgumentException(LocalizedMessages.TabbedThumbnailZeroParentHandle, "parentWindowHandle");
			}
			if (windowHandle == IntPtr.Zero)
			{
				throw new ArgumentException(LocalizedMessages.TabbedThumbnailZeroChildHandle, "windowHandle");
			}
			this.WindowHandle = windowHandle;
			this.ParentWindowHandle = parentWindowHandle;
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x000321A8 File Offset: 0x000303A8
		public TabbedThumbnail(IntPtr parentWindowHandle, Control control)
		{
			if (parentWindowHandle == IntPtr.Zero)
			{
				throw new ArgumentException(LocalizedMessages.TabbedThumbnailZeroParentHandle, "parentWindowHandle");
			}
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			this.WindowHandle = control.Handle;
			this.ParentWindowHandle = parentWindowHandle;
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x00032224 File Offset: 0x00030424
		public TabbedThumbnail(Window parentWindow, UIElement windowsControl, Vector peekOffset)
		{
			if (windowsControl == null)
			{
				throw new ArgumentNullException("windowsControl");
			}
			if (parentWindow == null)
			{
				throw new ArgumentNullException("parentWindow");
			}
			this.WindowHandle = IntPtr.Zero;
			this.WindowsControl = windowsControl;
			this.WindowsControlParentWindow = parentWindow;
			this.ParentWindowHandle = new WindowInteropHelper(parentWindow).Handle;
			this.PeekOffset = new Vector?(peekOffset);
		}

		// Token: 0x1700083B RID: 2107
		// (get) Token: 0x06000D6B RID: 3435 RVA: 0x000322BC File Offset: 0x000304BC
		// (set) Token: 0x06000D6C RID: 3436 RVA: 0x000322D4 File Offset: 0x000304D4
		public string Title
		{
			get
			{
				return this._title;
			}
			set
			{
				if (this._title != value)
				{
					this._title = value;
					if (this.TitleChanged != null)
					{
						this.TitleChanged(this, EventArgs.Empty);
					}
				}
			}
		}

		// Token: 0x1700083C RID: 2108
		// (get) Token: 0x06000D6D RID: 3437 RVA: 0x00032320 File Offset: 0x00030520
		// (set) Token: 0x06000D6E RID: 3438 RVA: 0x00032338 File Offset: 0x00030538
		public string Tooltip
		{
			get
			{
				return this._tooltip;
			}
			set
			{
				if (this._tooltip != value)
				{
					this._tooltip = value;
					if (this.TooltipChanged != null)
					{
						this.TooltipChanged(this, EventArgs.Empty);
					}
				}
			}
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x00032384 File Offset: 0x00030584
		public void SetWindowIcon(Icon icon)
		{
			this.Icon = icon;
			if (this.TaskbarWindow != null && this.TaskbarWindow.TabbedThumbnailProxyWindow != null)
			{
				this.TaskbarWindow.TabbedThumbnailProxyWindow.Icon = this.Icon;
			}
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x000323D4 File Offset: 0x000305D4
		public void SetWindowIcon(IntPtr iconHandle)
		{
			this.Icon = ((iconHandle != IntPtr.Zero) ? Icon.FromHandle(iconHandle) : null);
			if (this.TaskbarWindow != null && this.TaskbarWindow.TabbedThumbnailProxyWindow != null)
			{
				this.TaskbarWindow.TabbedThumbnailProxyWindow.Icon = this.Icon;
			}
		}

		// Token: 0x1700083D RID: 2109
		// (get) Token: 0x06000D71 RID: 3441 RVA: 0x00032438 File Offset: 0x00030638
		// (set) Token: 0x06000D72 RID: 3442 RVA: 0x00032450 File Offset: 0x00030650
		public Rectangle? ClippingRectangle
		{
			get
			{
				return this._clippingRectangle;
			}
			set
			{
				this._clippingRectangle = value;
				TaskbarWindowManager.InvalidatePreview(this.TaskbarWindow);
			}
		}

		// Token: 0x1700083E RID: 2110
		// (get) Token: 0x06000D73 RID: 3443 RVA: 0x00032468 File Offset: 0x00030668
		// (set) Token: 0x06000D74 RID: 3444 RVA: 0x0003247F File Offset: 0x0003067F
		internal IntPtr CurrentHBitmap { get; set; }

		// Token: 0x1700083F RID: 2111
		// (get) Token: 0x06000D75 RID: 3445 RVA: 0x00032488 File Offset: 0x00030688
		// (set) Token: 0x06000D76 RID: 3446 RVA: 0x0003249F File Offset: 0x0003069F
		internal Icon Icon { get; private set; }

		// Token: 0x06000D77 RID: 3447 RVA: 0x000324A8 File Offset: 0x000306A8
		public void SetImage(Bitmap bitmap)
		{
			if (bitmap != null)
			{
				this.SetImage(bitmap.GetHbitmap());
			}
			else
			{
				this.SetImage(IntPtr.Zero);
			}
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x000324E0 File Offset: 0x000306E0
		public void SetImage(BitmapSource bitmapSource)
		{
			if (bitmapSource == null)
			{
				this.SetImage(IntPtr.Zero);
			}
			else
			{
				BmpBitmapEncoder bmpBitmapEncoder = new BmpBitmapEncoder();
				bmpBitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapSource));
				using (MemoryStream memoryStream = new MemoryStream())
				{
					bmpBitmapEncoder.Save(memoryStream);
					memoryStream.Position = 0L;
					using (Bitmap bitmap = new Bitmap(memoryStream))
					{
						this.SetImage(bitmap.GetHbitmap());
					}
				}
			}
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x00032594 File Offset: 0x00030794
		internal void SetImage(IntPtr hBitmap)
		{
			if (this.CurrentHBitmap != IntPtr.Zero)
			{
				ShellNativeMethods.DeleteObject(this.CurrentHBitmap);
			}
			this.CurrentHBitmap = hBitmap;
			TaskbarWindowManager.InvalidatePreview(this.TaskbarWindow);
		}

		// Token: 0x17000840 RID: 2112
		// (get) Token: 0x06000D7A RID: 3450 RVA: 0x000325DC File Offset: 0x000307DC
		// (set) Token: 0x06000D7B RID: 3451 RVA: 0x000325F3 File Offset: 0x000307F3
		public bool DisplayFrameAroundBitmap { get; set; }

		// Token: 0x06000D7C RID: 3452 RVA: 0x000325FC File Offset: 0x000307FC
		public void InvalidatePreview()
		{
			this.SetImage(IntPtr.Zero);
		}

		// Token: 0x17000841 RID: 2113
		// (get) Token: 0x06000D7D RID: 3453 RVA: 0x0003260C File Offset: 0x0003080C
		// (set) Token: 0x06000D7E RID: 3454 RVA: 0x00032623 File Offset: 0x00030823
		public Vector? PeekOffset { get; set; }

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x06000D7F RID: 3455 RVA: 0x0003262C File Offset: 0x0003082C
		// (remove) Token: 0x06000D80 RID: 3456 RVA: 0x00032668 File Offset: 0x00030868
		public event EventHandler TitleChanged;

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x06000D81 RID: 3457 RVA: 0x000326A4 File Offset: 0x000308A4
		// (remove) Token: 0x06000D82 RID: 3458 RVA: 0x000326E0 File Offset: 0x000308E0
		public event EventHandler TooltipChanged;

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x06000D83 RID: 3459 RVA: 0x0003271C File Offset: 0x0003091C
		// (remove) Token: 0x06000D84 RID: 3460 RVA: 0x00032758 File Offset: 0x00030958
		public event EventHandler<TabbedThumbnailClosedEventArgs> TabbedThumbnailClosed;

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x06000D85 RID: 3461 RVA: 0x00032794 File Offset: 0x00030994
		// (remove) Token: 0x06000D86 RID: 3462 RVA: 0x000327D0 File Offset: 0x000309D0
		public event EventHandler<TabbedThumbnailEventArgs> TabbedThumbnailMaximized;

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x06000D87 RID: 3463 RVA: 0x0003280C File Offset: 0x00030A0C
		// (remove) Token: 0x06000D88 RID: 3464 RVA: 0x00032848 File Offset: 0x00030A48
		public event EventHandler<TabbedThumbnailEventArgs> TabbedThumbnailMinimized;

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x06000D89 RID: 3465 RVA: 0x00032884 File Offset: 0x00030A84
		// (remove) Token: 0x06000D8A RID: 3466 RVA: 0x000328C0 File Offset: 0x00030AC0
		public event EventHandler<TabbedThumbnailEventArgs> TabbedThumbnailActivated;

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x06000D8B RID: 3467 RVA: 0x000328FC File Offset: 0x00030AFC
		// (remove) Token: 0x06000D8C RID: 3468 RVA: 0x00032938 File Offset: 0x00030B38
		public event EventHandler<TabbedThumbnailBitmapRequestedEventArgs> TabbedThumbnailBitmapRequested;

		// Token: 0x06000D8D RID: 3469 RVA: 0x00032974 File Offset: 0x00030B74
		internal void OnTabbedThumbnailMaximized()
		{
			if (this.TabbedThumbnailMaximized != null)
			{
				this.TabbedThumbnailMaximized(this, this.GetTabbedThumbnailEventArgs());
			}
			else
			{
				CoreNativeMethods.SendMessage(this.ParentWindowHandle, WindowMessage.SystemCommand, new IntPtr(61488), IntPtr.Zero);
			}
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x000329C8 File Offset: 0x00030BC8
		internal void OnTabbedThumbnailMinimized()
		{
			if (this.TabbedThumbnailMinimized != null)
			{
				this.TabbedThumbnailMinimized(this, this.GetTabbedThumbnailEventArgs());
			}
			else
			{
				CoreNativeMethods.SendMessage(this.ParentWindowHandle, WindowMessage.SystemCommand, new IntPtr(61472), IntPtr.Zero);
			}
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x00032A1C File Offset: 0x00030C1C
		internal bool OnTabbedThumbnailClosed()
		{
			EventHandler<TabbedThumbnailClosedEventArgs> tabbedThumbnailClosed = this.TabbedThumbnailClosed;
			if (tabbedThumbnailClosed != null)
			{
				TabbedThumbnailClosedEventArgs tabbedThumbnailClosingEventArgs = this.GetTabbedThumbnailClosingEventArgs();
				tabbedThumbnailClosed(this, tabbedThumbnailClosingEventArgs);
				if (tabbedThumbnailClosingEventArgs.Cancel)
				{
					return false;
				}
			}
			else
			{
				CoreNativeMethods.SendMessage(this.ParentWindowHandle, WindowMessage.NCDestroy, IntPtr.Zero, IntPtr.Zero);
			}
			TaskbarManager.Instance.TabbedThumbnail.RemoveThumbnailPreview(this);
			return true;
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x00032A94 File Offset: 0x00030C94
		internal void OnTabbedThumbnailActivated()
		{
			if (this.TabbedThumbnailActivated != null)
			{
				this.TabbedThumbnailActivated(this, this.GetTabbedThumbnailEventArgs());
			}
			else
			{
				CoreNativeMethods.SendMessage(this.ParentWindowHandle, WindowMessage.ActivateApplication, new IntPtr(1), new IntPtr(Thread.CurrentThread.GetHashCode()));
			}
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x00032AEC File Offset: 0x00030CEC
		internal void OnTabbedThumbnailBitmapRequested()
		{
			if (this.TabbedThumbnailBitmapRequested != null)
			{
				TabbedThumbnailBitmapRequestedEventArgs e = null;
				if (this.WindowHandle != IntPtr.Zero)
				{
					e = new TabbedThumbnailBitmapRequestedEventArgs(this.WindowHandle);
				}
				else if (this.WindowsControl != null)
				{
					e = new TabbedThumbnailBitmapRequestedEventArgs(this.WindowsControl);
				}
				this.TabbedThumbnailBitmapRequested(this, e);
			}
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x00032B5C File Offset: 0x00030D5C
		private TabbedThumbnailClosedEventArgs GetTabbedThumbnailClosingEventArgs()
		{
			TabbedThumbnailClosedEventArgs result = null;
			if (this.WindowHandle != IntPtr.Zero)
			{
				result = new TabbedThumbnailClosedEventArgs(this.WindowHandle);
			}
			else if (this.WindowsControl != null)
			{
				result = new TabbedThumbnailClosedEventArgs(this.WindowsControl);
			}
			return result;
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x00032BB4 File Offset: 0x00030DB4
		private TabbedThumbnailEventArgs GetTabbedThumbnailEventArgs()
		{
			TabbedThumbnailEventArgs result = null;
			if (this.WindowHandle != IntPtr.Zero)
			{
				result = new TabbedThumbnailEventArgs(this.WindowHandle);
			}
			else if (this.WindowsControl != null)
			{
				result = new TabbedThumbnailEventArgs(this.WindowsControl);
			}
			return result;
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x00032C0C File Offset: 0x00030E0C
		~TabbedThumbnail()
		{
			this.Dispose(false);
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x00032C40 File Offset: 0x00030E40
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x00032C54 File Offset: 0x00030E54
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._taskbarWindow = null;
				if (this.Icon != null)
				{
					this.Icon.Dispose();
				}
				this.Icon = null;
				this._title = null;
				this._tooltip = null;
				this.WindowsControl = null;
			}
			if (this.CurrentHBitmap != IntPtr.Zero)
			{
				ShellNativeMethods.DeleteObject(this.CurrentHBitmap);
				this.CurrentHBitmap = IntPtr.Zero;
			}
		}

		// Token: 0x04000508 RID: 1288
		private TaskbarWindow _taskbarWindow;

		// Token: 0x04000509 RID: 1289
		private bool _addedToTaskbar;

		// Token: 0x0400050A RID: 1290
		private string _title = string.Empty;

		// Token: 0x0400050B RID: 1291
		private string _tooltip = string.Empty;

		// Token: 0x0400050C RID: 1292
		private Rectangle? _clippingRectangle;
	}
}
