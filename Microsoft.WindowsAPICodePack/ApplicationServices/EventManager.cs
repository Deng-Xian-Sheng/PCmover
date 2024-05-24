using System;
using System.Threading;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x0200003D RID: 61
	internal static class EventManager
	{
		// Token: 0x06000111 RID: 273 RVA: 0x000046F0 File Offset: 0x000028F0
		internal static bool IsMessageCaught(Guid eventGuid)
		{
			bool result = false;
			if (eventGuid == EventManager.BatteryCapacityChange)
			{
				if (!EventManager.batteryLifeCaught)
				{
					EventManager.batteryLifeCaught = true;
					result = true;
				}
			}
			else if (eventGuid == EventManager.MonitorPowerStatus)
			{
				if (!EventManager.monitorOnCaught)
				{
					EventManager.monitorOnCaught = true;
					result = true;
				}
			}
			else if (eventGuid == EventManager.PowerPersonalityChange)
			{
				if (!EventManager.personalityCaught)
				{
					EventManager.personalityCaught = true;
					result = true;
				}
			}
			else if (eventGuid == EventManager.PowerSourceChange)
			{
				if (!EventManager.powerSrcCaught)
				{
					EventManager.powerSrcCaught = true;
					result = true;
				}
			}
			return result;
		}

		// Token: 0x04000225 RID: 549
		internal static AutoResetEvent monitorOnReset = new AutoResetEvent(false);

		// Token: 0x04000226 RID: 550
		internal static readonly Guid PowerPersonalityChange = new Guid(610108737, 14659, 17442, 176, 37, 19, 167, 132, 246, 121, 183);

		// Token: 0x04000227 RID: 551
		internal static readonly Guid PowerSourceChange = new Guid(1564383833U, 59861, 19200, 166, 189, byte.MaxValue, 52, byte.MaxValue, 81, 101, 72);

		// Token: 0x04000228 RID: 552
		internal static readonly Guid BatteryCapacityChange = new Guid(2813165633U, 46170, 19630, 135, 163, 238, 203, 180, 104, 169, 225);

		// Token: 0x04000229 RID: 553
		internal static readonly Guid BackgroundTaskNotification = new Guid(1364996568U, 63284, 5693, 160, 253, 17, 160, 140, 145, 232, 241);

		// Token: 0x0400022A RID: 554
		internal static readonly Guid MonitorPowerStatus = new Guid(41095189, 17680, 17702, 153, 230, 229, 161, 126, 189, 26, 234);

		// Token: 0x0400022B RID: 555
		private static bool personalityCaught;

		// Token: 0x0400022C RID: 556
		private static bool powerSrcCaught;

		// Token: 0x0400022D RID: 557
		private static bool batteryLifeCaught;

		// Token: 0x0400022E RID: 558
		private static bool monitorOnCaught;
	}
}
