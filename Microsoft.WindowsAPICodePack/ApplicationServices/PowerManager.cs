using System;
using System.ComponentModel;
using System.Security.Permissions;
using Microsoft.WindowsAPICodePack.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x02000043 RID: 67
	public static class PowerManager
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000121 RID: 289 RVA: 0x00004E19 File Offset: 0x00003019
		// (remove) Token: 0x06000122 RID: 290 RVA: 0x00004E28 File Offset: 0x00003028
		public static event EventHandler PowerPersonalityChanged
		{
			add
			{
				MessageManager.RegisterPowerEvent(EventManager.PowerPersonalityChange, value);
			}
			remove
			{
				CoreHelpers.ThrowIfNotVista();
				MessageManager.UnregisterPowerEvent(EventManager.PowerPersonalityChange, value);
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000123 RID: 291 RVA: 0x00004E3D File Offset: 0x0000303D
		// (remove) Token: 0x06000124 RID: 292 RVA: 0x00004E52 File Offset: 0x00003052
		public static event EventHandler PowerSourceChanged
		{
			add
			{
				CoreHelpers.ThrowIfNotVista();
				MessageManager.RegisterPowerEvent(EventManager.PowerSourceChange, value);
			}
			remove
			{
				CoreHelpers.ThrowIfNotVista();
				MessageManager.UnregisterPowerEvent(EventManager.PowerSourceChange, value);
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000125 RID: 293 RVA: 0x00004E67 File Offset: 0x00003067
		// (remove) Token: 0x06000126 RID: 294 RVA: 0x00004E7C File Offset: 0x0000307C
		public static event EventHandler BatteryLifePercentChanged
		{
			add
			{
				CoreHelpers.ThrowIfNotVista();
				MessageManager.RegisterPowerEvent(EventManager.BatteryCapacityChange, value);
			}
			remove
			{
				CoreHelpers.ThrowIfNotVista();
				MessageManager.UnregisterPowerEvent(EventManager.BatteryCapacityChange, value);
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000127 RID: 295 RVA: 0x00004E91 File Offset: 0x00003091
		// (remove) Token: 0x06000128 RID: 296 RVA: 0x00004EA6 File Offset: 0x000030A6
		public static event EventHandler IsMonitorOnChanged
		{
			add
			{
				CoreHelpers.ThrowIfNotVista();
				MessageManager.RegisterPowerEvent(EventManager.MonitorPowerStatus, value);
			}
			remove
			{
				CoreHelpers.ThrowIfNotVista();
				MessageManager.UnregisterPowerEvent(EventManager.MonitorPowerStatus, value);
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000129 RID: 297 RVA: 0x00004EBB File Offset: 0x000030BB
		// (remove) Token: 0x0600012A RID: 298 RVA: 0x00004ED0 File Offset: 0x000030D0
		public static event EventHandler SystemBusyChanged
		{
			add
			{
				CoreHelpers.ThrowIfNotVista();
				MessageManager.RegisterPowerEvent(EventManager.BackgroundTaskNotification, value);
			}
			remove
			{
				CoreHelpers.ThrowIfNotVista();
				MessageManager.UnregisterPowerEvent(EventManager.BackgroundTaskNotification, value);
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00004EE8 File Offset: 0x000030E8
		public static BatteryState GetCurrentBatteryState()
		{
			CoreHelpers.ThrowIfNotXP();
			return new BatteryState();
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00004F08 File Offset: 0x00003108
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00004F28 File Offset: 0x00003128
		public static bool MonitorRequired
		{
			get
			{
				CoreHelpers.ThrowIfNotXP();
				return PowerManager.monitorRequired;
			}
			[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
			set
			{
				CoreHelpers.ThrowIfNotXP();
				if (value)
				{
					PowerManager.SetThreadExecutionState(ExecutionStates.DisplayRequired | ExecutionStates.Continuous);
				}
				else
				{
					PowerManager.SetThreadExecutionState(ExecutionStates.Continuous);
				}
				PowerManager.monitorRequired = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00004F68 File Offset: 0x00003168
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00004F88 File Offset: 0x00003188
		public static bool RequestBlockSleep
		{
			get
			{
				CoreHelpers.ThrowIfNotXP();
				return PowerManager.requestBlockSleep;
			}
			[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
			set
			{
				CoreHelpers.ThrowIfNotXP();
				if (value)
				{
					PowerManager.SetThreadExecutionState(ExecutionStates.SystemRequired | ExecutionStates.Continuous);
				}
				else
				{
					PowerManager.SetThreadExecutionState(ExecutionStates.Continuous);
				}
				PowerManager.requestBlockSleep = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00004FC4 File Offset: 0x000031C4
		public static bool IsBatteryPresent
		{
			get
			{
				CoreHelpers.ThrowIfNotXP();
				return Power.GetSystemBatteryState().BatteryPresent;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00004FE8 File Offset: 0x000031E8
		public static bool IsBatteryShortTerm
		{
			get
			{
				CoreHelpers.ThrowIfNotXP();
				return Power.GetSystemPowerCapabilities().BatteriesAreShortTerm;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000132 RID: 306 RVA: 0x0000500C File Offset: 0x0000320C
		public static bool IsUpsPresent
		{
			get
			{
				CoreHelpers.ThrowIfNotXP();
				PowerManagementNativeMethods.SystemPowerCapabilities systemPowerCapabilities = Power.GetSystemPowerCapabilities();
				return systemPowerCapabilities.BatteriesAreShortTerm && systemPowerCapabilities.SystemBatteriesPresent;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00005040 File Offset: 0x00003240
		public static PowerPersonality PowerPersonality
		{
			get
			{
				Guid guid;
				PowerManagementNativeMethods.PowerGetActiveScheme(IntPtr.Zero, out guid);
				PowerPersonality result;
				try
				{
					result = PowerPersonalityGuids.GuidToEnum(guid);
				}
				finally
				{
					CoreNativeMethods.LocalFree(ref guid);
				}
				return result;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00005084 File Offset: 0x00003284
		public static int BatteryLifePercent
		{
			get
			{
				CoreHelpers.ThrowIfNotVista();
				if (!Power.GetSystemBatteryState().BatteryPresent)
				{
					throw new InvalidOperationException(LocalizedMessages.PowerManagerBatteryNotPresent);
				}
				PowerManagementNativeMethods.SystemBatteryState systemBatteryState = Power.GetSystemBatteryState();
				return (int)Math.Round(systemBatteryState.RemainingCapacity / systemBatteryState.MaxCapacity * 100.0, 0);
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000135 RID: 309 RVA: 0x000050E4 File Offset: 0x000032E4
		// (set) Token: 0x06000136 RID: 310 RVA: 0x00005174 File Offset: 0x00003374
		public static bool IsMonitorOn
		{
			get
			{
				CoreHelpers.ThrowIfNotVista();
				lock (PowerManager.monitoronlock)
				{
					if (PowerManager.isMonitorOn == null)
					{
						EventHandler value = delegate(object sender, EventArgs args)
						{
						};
						PowerManager.IsMonitorOnChanged += value;
						EventManager.monitorOnReset.WaitOne();
					}
				}
				return PowerManager.isMonitorOn.Value;
			}
			internal set
			{
				PowerManager.isMonitorOn = new bool?(value);
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00005184 File Offset: 0x00003384
		public static PowerSource PowerSource
		{
			get
			{
				CoreHelpers.ThrowIfNotVista();
				PowerSource result;
				if (PowerManager.IsUpsPresent)
				{
					result = PowerSource.Ups;
				}
				else if (!PowerManager.IsBatteryPresent || PowerManager.GetCurrentBatteryState().ACOnline)
				{
					result = PowerSource.AC;
				}
				else
				{
					result = PowerSource.Battery;
				}
				return result;
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000051D0 File Offset: 0x000033D0
		public static void SetThreadExecutionState(ExecutionStates executionStateOptions)
		{
			ExecutionStates executionStates = PowerManagementNativeMethods.SetThreadExecutionState(executionStateOptions);
			if (executionStates == ExecutionStates.None)
			{
				throw new Win32Exception(LocalizedMessages.PowerExecutionStateFailed);
			}
		}

		// Token: 0x0400023D RID: 573
		private static bool? isMonitorOn;

		// Token: 0x0400023E RID: 574
		private static bool monitorRequired;

		// Token: 0x0400023F RID: 575
		private static bool requestBlockSleep;

		// Token: 0x04000240 RID: 576
		private static readonly object monitoronlock = new object();
	}
}
