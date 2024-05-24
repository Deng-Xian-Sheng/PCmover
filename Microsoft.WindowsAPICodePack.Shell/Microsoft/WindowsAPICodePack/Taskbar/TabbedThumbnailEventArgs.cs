using System;
using System.Windows;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000128 RID: 296
	public class TabbedThumbnailEventArgs : EventArgs
	{
		// Token: 0x06000D34 RID: 3380 RVA: 0x00031250 File Offset: 0x0002F450
		public TabbedThumbnailEventArgs(IntPtr windowHandle)
		{
			this.WindowHandle = windowHandle;
			this.WindowsControl = null;
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x0003126B File Offset: 0x0002F46B
		public TabbedThumbnailEventArgs(UIElement windowsControl)
		{
			this.WindowHandle = IntPtr.Zero;
			this.WindowsControl = windowsControl;
		}

		// Token: 0x17000830 RID: 2096
		// (get) Token: 0x06000D36 RID: 3382 RVA: 0x0003128C File Offset: 0x0002F48C
		// (set) Token: 0x06000D37 RID: 3383 RVA: 0x000312A3 File Offset: 0x0002F4A3
		public IntPtr WindowHandle { get; private set; }

		// Token: 0x17000831 RID: 2097
		// (get) Token: 0x06000D38 RID: 3384 RVA: 0x000312AC File Offset: 0x0002F4AC
		// (set) Token: 0x06000D39 RID: 3385 RVA: 0x000312C3 File Offset: 0x0002F4C3
		public UIElement WindowsControl { get; private set; }
	}
}
