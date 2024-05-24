using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Resources;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x02000042 RID: 66
	internal static class Power
	{
		// Token: 0x0600011E RID: 286 RVA: 0x00004D64 File Offset: 0x00002F64
		internal static PowerManagementNativeMethods.SystemPowerCapabilities GetSystemPowerCapabilities()
		{
			PowerManagementNativeMethods.SystemPowerCapabilities result;
			uint num = PowerManagementNativeMethods.CallNtPowerInformation(PowerManagementNativeMethods.PowerInformationLevel.SystemPowerCapabilities, IntPtr.Zero, 0U, out result, (uint)Marshal.SizeOf(typeof(PowerManagementNativeMethods.SystemPowerCapabilities)));
			if (num == 3221225506U)
			{
				throw new UnauthorizedAccessException(LocalizedMessages.PowerInsufficientAccessCapabilities);
			}
			return result;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00004DB0 File Offset: 0x00002FB0
		internal static PowerManagementNativeMethods.SystemBatteryState GetSystemBatteryState()
		{
			PowerManagementNativeMethods.SystemBatteryState result;
			uint num = PowerManagementNativeMethods.CallNtPowerInformation(PowerManagementNativeMethods.PowerInformationLevel.SystemBatteryState, IntPtr.Zero, 0U, out result, (uint)Marshal.SizeOf(typeof(PowerManagementNativeMethods.SystemBatteryState)));
			if (num == 3221225506U)
			{
				throw new UnauthorizedAccessException(LocalizedMessages.PowerInsufficientAccessBatteryState);
			}
			return result;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00004DFC File Offset: 0x00002FFC
		internal static int RegisterPowerSettingNotification(IntPtr handle, Guid powerSetting)
		{
			return PowerManagementNativeMethods.RegisterPowerSettingNotification(handle, ref powerSetting, 0);
		}
	}
}
