using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000180 RID: 384
	[Guid("E6FDD21A-163F-4975-9C8C-A69F1BA37034")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IFileDialogCustomize
	{
		// Token: 0x06000ECC RID: 3788
		[MethodImpl(MethodImplOptions.InternalCall)]
		void EnableOpenDropDown([In] int dwIDCtl);

		// Token: 0x06000ECD RID: 3789
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddMenu([In] int dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszLabel);

		// Token: 0x06000ECE RID: 3790
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddPushButton([In] int dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszLabel);

		// Token: 0x06000ECF RID: 3791
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddComboBox([In] int dwIDCtl);

		// Token: 0x06000ED0 RID: 3792
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddRadioButtonList([In] int dwIDCtl);

		// Token: 0x06000ED1 RID: 3793
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddCheckButton([In] int dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszLabel, [In] bool bChecked);

		// Token: 0x06000ED2 RID: 3794
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddEditBox([In] int dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszText);

		// Token: 0x06000ED3 RID: 3795
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddSeparator([In] int dwIDCtl);

		// Token: 0x06000ED4 RID: 3796
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddText([In] int dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszText);

		// Token: 0x06000ED5 RID: 3797
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetControlLabel([In] int dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszLabel);

		// Token: 0x06000ED6 RID: 3798
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetControlState([In] int dwIDCtl, out ShellNativeMethods.ControlState pdwState);

		// Token: 0x06000ED7 RID: 3799
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetControlState([In] int dwIDCtl, [In] ShellNativeMethods.ControlState dwState);

		// Token: 0x06000ED8 RID: 3800
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetEditBoxText([In] int dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] out string ppszText);

		// Token: 0x06000ED9 RID: 3801
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetEditBoxText([In] int dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszText);

		// Token: 0x06000EDA RID: 3802
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetCheckButtonState([In] int dwIDCtl, out bool pbChecked);

		// Token: 0x06000EDB RID: 3803
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetCheckButtonState([In] int dwIDCtl, [In] bool bChecked);

		// Token: 0x06000EDC RID: 3804
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddControlItem([In] int dwIDCtl, [In] int dwIDItem, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszLabel);

		// Token: 0x06000EDD RID: 3805
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RemoveControlItem([In] int dwIDCtl, [In] int dwIDItem);

		// Token: 0x06000EDE RID: 3806
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RemoveAllControlItems([In] int dwIDCtl);

		// Token: 0x06000EDF RID: 3807
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetControlItemState([In] int dwIDCtl, [In] int dwIDItem, out ShellNativeMethods.ControlState pdwState);

		// Token: 0x06000EE0 RID: 3808
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetControlItemState([In] int dwIDCtl, [In] int dwIDItem, [In] ShellNativeMethods.ControlState dwState);

		// Token: 0x06000EE1 RID: 3809
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetSelectedControlItem([In] int dwIDCtl, out int pdwIDItem);

		// Token: 0x06000EE2 RID: 3810
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetSelectedControlItem([In] int dwIDCtl, [In] int dwIDItem);

		// Token: 0x06000EE3 RID: 3811
		[MethodImpl(MethodImplOptions.InternalCall)]
		void StartVisualGroup([In] int dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszLabel);

		// Token: 0x06000EE4 RID: 3812
		[MethodImpl(MethodImplOptions.InternalCall)]
		void EndVisualGroup();

		// Token: 0x06000EE5 RID: 3813
		[MethodImpl(MethodImplOptions.InternalCall)]
		void MakeProminent([In] int dwIDCtl);
	}
}
