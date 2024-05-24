using System;
using System.Windows;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x0200018C RID: 396
	public class ThumbnailToolBarManager
	{
		// Token: 0x06000F97 RID: 3991 RVA: 0x00037694 File Offset: 0x00035894
		internal ThumbnailToolBarManager()
		{
		}

		// Token: 0x06000F98 RID: 3992 RVA: 0x000376A0 File Offset: 0x000358A0
		public void AddButtons(IntPtr windowHandle, params ThumbnailToolBarButton[] buttons)
		{
			if (windowHandle == IntPtr.Zero)
			{
				throw new ArgumentException(LocalizedMessages.ThumbnailManagerInvalidHandle, "windowHandle");
			}
			ThumbnailToolBarManager.VerifyButtons(buttons);
			TaskbarWindowManager.AddThumbnailButtons(windowHandle, buttons);
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x000376E0 File Offset: 0x000358E0
		public void AddButtons(UIElement control, params ThumbnailToolBarButton[] buttons)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			ThumbnailToolBarManager.VerifyButtons(buttons);
			TaskbarWindowManager.AddThumbnailButtons(control, buttons);
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x00037714 File Offset: 0x00035914
		private static void VerifyButtons(params ThumbnailToolBarButton[] buttons)
		{
			if (buttons != null && buttons.Length == 0)
			{
				throw new ArgumentException(LocalizedMessages.ThumbnailToolbarManagerNullEmptyArray, "buttons");
			}
			if (buttons.Length > 7)
			{
				throw new ArgumentException(LocalizedMessages.ThumbnailToolbarManagerMaxButtons, "buttons");
			}
		}
	}
}
