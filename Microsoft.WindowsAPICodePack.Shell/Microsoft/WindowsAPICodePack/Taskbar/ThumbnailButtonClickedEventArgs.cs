using System;
using System.Windows;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x0200018B RID: 395
	public class ThumbnailButtonClickedEventArgs : EventArgs
	{
		// Token: 0x06000F8F RID: 3983 RVA: 0x000375E8 File Offset: 0x000357E8
		public ThumbnailButtonClickedEventArgs(IntPtr windowHandle, ThumbnailToolBarButton button)
		{
			this.ThumbnailButton = button;
			this.WindowHandle = windowHandle;
			this.WindowsControl = null;
		}

		// Token: 0x06000F90 RID: 3984 RVA: 0x0003760B File Offset: 0x0003580B
		public ThumbnailButtonClickedEventArgs(UIElement windowsControl, ThumbnailToolBarButton button)
		{
			this.ThumbnailButton = button;
			this.WindowHandle = IntPtr.Zero;
			this.WindowsControl = windowsControl;
		}

		// Token: 0x17000891 RID: 2193
		// (get) Token: 0x06000F91 RID: 3985 RVA: 0x00037634 File Offset: 0x00035834
		// (set) Token: 0x06000F92 RID: 3986 RVA: 0x0003764B File Offset: 0x0003584B
		public IntPtr WindowHandle { get; private set; }

		// Token: 0x17000892 RID: 2194
		// (get) Token: 0x06000F93 RID: 3987 RVA: 0x00037654 File Offset: 0x00035854
		// (set) Token: 0x06000F94 RID: 3988 RVA: 0x0003766B File Offset: 0x0003586B
		public UIElement WindowsControl { get; private set; }

		// Token: 0x17000893 RID: 2195
		// (get) Token: 0x06000F95 RID: 3989 RVA: 0x00037674 File Offset: 0x00035874
		// (set) Token: 0x06000F96 RID: 3990 RVA: 0x0003768B File Offset: 0x0003588B
		public ThumbnailToolBarButton ThumbnailButton { get; private set; }
	}
}
