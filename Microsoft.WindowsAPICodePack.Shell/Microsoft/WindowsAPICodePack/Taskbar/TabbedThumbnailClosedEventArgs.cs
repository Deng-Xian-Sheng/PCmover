using System;
using System.Windows;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000129 RID: 297
	public class TabbedThumbnailClosedEventArgs : TabbedThumbnailEventArgs
	{
		// Token: 0x06000D3A RID: 3386 RVA: 0x000312CC File Offset: 0x0002F4CC
		public TabbedThumbnailClosedEventArgs(IntPtr windowHandle) : base(windowHandle)
		{
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x000312D8 File Offset: 0x0002F4D8
		public TabbedThumbnailClosedEventArgs(UIElement windowsControl) : base(windowsControl)
		{
		}

		// Token: 0x17000832 RID: 2098
		// (get) Token: 0x06000D3C RID: 3388 RVA: 0x000312E4 File Offset: 0x0002F4E4
		// (set) Token: 0x06000D3D RID: 3389 RVA: 0x000312FB File Offset: 0x0002F4FB
		public bool Cancel { get; set; }
	}
}
