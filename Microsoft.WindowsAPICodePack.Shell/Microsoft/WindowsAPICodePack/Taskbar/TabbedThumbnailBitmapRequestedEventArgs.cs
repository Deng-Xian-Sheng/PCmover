using System;
using System.Windows;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x0200012C RID: 300
	public class TabbedThumbnailBitmapRequestedEventArgs : TabbedThumbnailEventArgs
	{
		// Token: 0x06000D56 RID: 3414 RVA: 0x00031F98 File Offset: 0x00030198
		public TabbedThumbnailBitmapRequestedEventArgs(IntPtr windowHandle) : base(windowHandle)
		{
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x00031FA4 File Offset: 0x000301A4
		public TabbedThumbnailBitmapRequestedEventArgs(UIElement windowsControl) : base(windowsControl)
		{
		}

		// Token: 0x17000833 RID: 2099
		// (get) Token: 0x06000D58 RID: 3416 RVA: 0x00031FB0 File Offset: 0x000301B0
		// (set) Token: 0x06000D59 RID: 3417 RVA: 0x00031FC7 File Offset: 0x000301C7
		public bool Handled { get; set; }
	}
}
