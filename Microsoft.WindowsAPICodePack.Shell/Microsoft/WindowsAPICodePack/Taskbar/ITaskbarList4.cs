using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x020000AA RID: 170
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("c43dc798-95d1-4bea-9030-bb99e2983a1a")]
	[ComImport]
	internal interface ITaskbarList4
	{
		// Token: 0x06000574 RID: 1396
		[PreserveSig]
		void HrInit();

		// Token: 0x06000575 RID: 1397
		[PreserveSig]
		void AddTab(IntPtr hwnd);

		// Token: 0x06000576 RID: 1398
		[PreserveSig]
		void DeleteTab(IntPtr hwnd);

		// Token: 0x06000577 RID: 1399
		[PreserveSig]
		void ActivateTab(IntPtr hwnd);

		// Token: 0x06000578 RID: 1400
		[PreserveSig]
		void SetActiveAlt(IntPtr hwnd);

		// Token: 0x06000579 RID: 1401
		[PreserveSig]
		void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

		// Token: 0x0600057A RID: 1402
		[PreserveSig]
		void SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);

		// Token: 0x0600057B RID: 1403
		[PreserveSig]
		void SetProgressState(IntPtr hwnd, TaskbarProgressBarStatus tbpFlags);

		// Token: 0x0600057C RID: 1404
		[PreserveSig]
		void RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);

		// Token: 0x0600057D RID: 1405
		[PreserveSig]
		void UnregisterTab(IntPtr hwndTab);

		// Token: 0x0600057E RID: 1406
		[PreserveSig]
		void SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);

		// Token: 0x0600057F RID: 1407
		[PreserveSig]
		void SetTabActive(IntPtr hwndTab, IntPtr hwndInsertBefore, uint dwReserved);

		// Token: 0x06000580 RID: 1408
		[PreserveSig]
		HResult ThumbBarAddButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray)] ThumbButton[] pButtons);

		// Token: 0x06000581 RID: 1409
		[PreserveSig]
		HResult ThumbBarUpdateButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray)] ThumbButton[] pButtons);

		// Token: 0x06000582 RID: 1410
		[PreserveSig]
		void ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);

		// Token: 0x06000583 RID: 1411
		[PreserveSig]
		void SetOverlayIcon(IntPtr hwnd, IntPtr hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

		// Token: 0x06000584 RID: 1412
		[PreserveSig]
		void SetThumbnailTooltip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);

		// Token: 0x06000585 RID: 1413
		[PreserveSig]
		void SetThumbnailClip(IntPtr hwnd, IntPtr prcClip);

		// Token: 0x06000586 RID: 1414
		void SetTabProperties(IntPtr hwndTab, SetTabPropertiesOption stpFlags);
	}
}
