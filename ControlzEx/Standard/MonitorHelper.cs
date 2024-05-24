using System;

namespace ControlzEx.Standard
{
	// Token: 0x0200001F RID: 31
	internal static class MonitorHelper
	{
		// Token: 0x0600016D RID: 365 RVA: 0x00008480 File Offset: 0x00006680
		public static MONITORINFO GetMonitorInfoFromPoint()
		{
			IntPtr intPtr = NativeMethods.MonitorFromPoint(NativeMethods.GetCursorPos(), MonitorOptions.MONITOR_DEFAULTTONEAREST);
			if (intPtr != IntPtr.Zero)
			{
				return NativeMethods.GetMonitorInfo(intPtr);
			}
			return new MONITORINFO();
		}
	}
}
