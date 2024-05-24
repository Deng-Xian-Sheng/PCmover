using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000083 RID: 131
	[CompilerGenerated]
	[Guid("E2F0F27C-CACD-4EB1-991E-13776C95997B")]
	[TypeIdentifier]
	[ComImport]
	public interface IPcmUICallbacks
	{
		// Token: 0x06000436 RID: 1078
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void uiAssignMissingPasswords([MarshalAs(UnmanagedType.Interface)] [In] UnloadVanTask task);

		// Token: 0x06000437 RID: 1079
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool uiWrongMachine([MarshalAs(UnmanagedType.BStr)] [In] string LoadedMachineNetName, [In] bool bUnload);

		// Token: 0x06000438 RID: 1080
		[DispId(4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool uiEarlierVersion([MarshalAs(UnmanagedType.Interface)] [In] UnloadVanTask task);

		// Token: 0x06000439 RID: 1081
		[DispId(5)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool uiCheckDiskSpace([MarshalAs(UnmanagedType.Interface)] [In] DriveSpaceRequiredMap driveSpaceRequired);

		// Token: 0x0600043A RID: 1082
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void uiGetPassword([MarshalAs(UnmanagedType.BStr)] [In] [Out] ref string pPassword);

		// Token: 0x0600043B RID: 1083
		[DispId(7)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void uiConfirmUserMatches([MarshalAs(UnmanagedType.Interface)] [In] UnloadVanTask task, [In] bool bShowUsersOnly);

		// Token: 0x0600043C RID: 1084
		[DispId(8)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void uiDisplayDriveMap([MarshalAs(UnmanagedType.Interface)] [In] UnloadVanTask task);

		// Token: 0x0600043D RID: 1085
		[DispId(9)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void uiDisplayAppSelection([MarshalAs(UnmanagedType.Interface)] [In] UnloadVanTask task);
	}
}
