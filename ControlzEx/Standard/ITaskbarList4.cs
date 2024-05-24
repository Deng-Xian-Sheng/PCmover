using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000B4 RID: 180
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
	[ComImport]
	internal interface ITaskbarList4 : ITaskbarList3, ITaskbarList2, ITaskbarList
	{
		// Token: 0x06000310 RID: 784
		void HrInit();

		// Token: 0x06000311 RID: 785
		void AddTab(IntPtr hwnd);

		// Token: 0x06000312 RID: 786
		void DeleteTab(IntPtr hwnd);

		// Token: 0x06000313 RID: 787
		void ActivateTab(IntPtr hwnd);

		// Token: 0x06000314 RID: 788
		void SetActiveAlt(IntPtr hwnd);

		// Token: 0x06000315 RID: 789
		void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

		// Token: 0x06000316 RID: 790
		[PreserveSig]
		HRESULT SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);

		// Token: 0x06000317 RID: 791
		[PreserveSig]
		HRESULT SetProgressState(IntPtr hwnd, TBPF tbpFlags);

		// Token: 0x06000318 RID: 792
		[PreserveSig]
		HRESULT RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);

		// Token: 0x06000319 RID: 793
		[PreserveSig]
		HRESULT UnregisterTab(IntPtr hwndTab);

		// Token: 0x0600031A RID: 794
		[PreserveSig]
		HRESULT SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);

		// Token: 0x0600031B RID: 795
		[PreserveSig]
		HRESULT SetTabActive(IntPtr hwndTab, IntPtr hwndMDI, uint dwReserved);

		// Token: 0x0600031C RID: 796
		[PreserveSig]
		HRESULT ThumbBarAddButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

		// Token: 0x0600031D RID: 797
		[PreserveSig]
		HRESULT ThumbBarUpdateButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

		// Token: 0x0600031E RID: 798
		[PreserveSig]
		HRESULT ThumbBarSetImageList(IntPtr hwnd, [MarshalAs(UnmanagedType.IUnknown)] object himl);

		// Token: 0x0600031F RID: 799
		[PreserveSig]
		HRESULT SetOverlayIcon(IntPtr hwnd, IntPtr hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

		// Token: 0x06000320 RID: 800
		[PreserveSig]
		HRESULT SetThumbnailTooltip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);

		// Token: 0x06000321 RID: 801
		[PreserveSig]
		HRESULT SetThumbnailClip(IntPtr hwnd, RefRECT prcClip);

		// Token: 0x06000322 RID: 802
		void SetTabProperties(IntPtr hwndTab, STPF stpFlags);
	}
}
