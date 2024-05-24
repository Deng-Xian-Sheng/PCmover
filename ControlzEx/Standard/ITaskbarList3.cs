using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000B3 RID: 179
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
	[ComImport]
	internal interface ITaskbarList3 : ITaskbarList2, ITaskbarList
	{
		// Token: 0x060002FE RID: 766
		void HrInit();

		// Token: 0x060002FF RID: 767
		void AddTab(IntPtr hwnd);

		// Token: 0x06000300 RID: 768
		void DeleteTab(IntPtr hwnd);

		// Token: 0x06000301 RID: 769
		void ActivateTab(IntPtr hwnd);

		// Token: 0x06000302 RID: 770
		void SetActiveAlt(IntPtr hwnd);

		// Token: 0x06000303 RID: 771
		void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

		// Token: 0x06000304 RID: 772
		[PreserveSig]
		HRESULT SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);

		// Token: 0x06000305 RID: 773
		[PreserveSig]
		HRESULT SetProgressState(IntPtr hwnd, TBPF tbpFlags);

		// Token: 0x06000306 RID: 774
		[PreserveSig]
		HRESULT RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);

		// Token: 0x06000307 RID: 775
		[PreserveSig]
		HRESULT UnregisterTab(IntPtr hwndTab);

		// Token: 0x06000308 RID: 776
		[PreserveSig]
		HRESULT SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);

		// Token: 0x06000309 RID: 777
		[PreserveSig]
		HRESULT SetTabActive(IntPtr hwndTab, IntPtr hwndMDI, uint dwReserved);

		// Token: 0x0600030A RID: 778
		[PreserveSig]
		HRESULT ThumbBarAddButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

		// Token: 0x0600030B RID: 779
		[PreserveSig]
		HRESULT ThumbBarUpdateButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

		// Token: 0x0600030C RID: 780
		[PreserveSig]
		HRESULT ThumbBarSetImageList(IntPtr hwnd, [MarshalAs(UnmanagedType.IUnknown)] object himl);

		// Token: 0x0600030D RID: 781
		[PreserveSig]
		HRESULT SetOverlayIcon(IntPtr hwnd, IntPtr hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

		// Token: 0x0600030E RID: 782
		[PreserveSig]
		HRESULT SetThumbnailTooltip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);

		// Token: 0x0600030F RID: 783
		[PreserveSig]
		HRESULT SetThumbnailClip(IntPtr hwnd, RefRECT prcClip);
	}
}
