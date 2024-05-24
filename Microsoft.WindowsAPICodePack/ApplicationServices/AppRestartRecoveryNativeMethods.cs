using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x0200000F RID: 15
	internal static class AppRestartRecoveryNativeMethods
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002870 File Offset: 0x00000A70
		internal static AppRestartRecoveryNativeMethods.InternalRecoveryCallback InternalCallback
		{
			get
			{
				return AppRestartRecoveryNativeMethods.internalCallback;
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002888 File Offset: 0x00000A88
		private static uint InternalRecoveryHandler(IntPtr parameter)
		{
			bool flag = false;
			AppRestartRecoveryNativeMethods.ApplicationRecoveryInProgress(out flag);
			GCHandle gchandle = GCHandle.FromIntPtr(parameter);
			RecoveryData recoveryData = gchandle.Target as RecoveryData;
			recoveryData.Invoke();
			gchandle.Free();
			return 0U;
		}

		// Token: 0x0600003D RID: 61
		[DllImport("kernel32.dll")]
		internal static extern void ApplicationRecoveryFinished([MarshalAs(UnmanagedType.Bool)] bool success);

		// Token: 0x0600003E RID: 62
		[DllImport("kernel32.dll")]
		internal static extern HResult ApplicationRecoveryInProgress([MarshalAs(UnmanagedType.Bool)] out bool canceled);

		// Token: 0x0600003F RID: 63
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		internal static extern HResult RegisterApplicationRecoveryCallback(AppRestartRecoveryNativeMethods.InternalRecoveryCallback callback, IntPtr param, uint pingInterval, uint flags);

		// Token: 0x06000040 RID: 64
		[DllImport("kernel32.dll")]
		internal static extern HResult RegisterApplicationRestart([MarshalAs(UnmanagedType.BStr)] string commandLineArgs, RestartRestrictions flags);

		// Token: 0x06000041 RID: 65
		[DllImport("kernel32.dll")]
		internal static extern HResult UnregisterApplicationRecoveryCallback();

		// Token: 0x06000042 RID: 66
		[DllImport("kernel32.dll")]
		internal static extern HResult UnregisterApplicationRestart();

		// Token: 0x040000E7 RID: 231
		private static AppRestartRecoveryNativeMethods.InternalRecoveryCallback internalCallback = new AppRestartRecoveryNativeMethods.InternalRecoveryCallback(AppRestartRecoveryNativeMethods.InternalRecoveryHandler);

		// Token: 0x02000010 RID: 16
		// (Invoke) Token: 0x06000045 RID: 69
		internal delegate uint InternalRecoveryCallback(IntPtr state);
	}
}
