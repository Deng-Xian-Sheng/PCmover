using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x0200001C RID: 28
	internal static class PowerManagementNativeMethods
	{
		// Token: 0x0600008E RID: 142
		[DllImport("powrprof.dll")]
		internal static extern uint CallNtPowerInformation(PowerManagementNativeMethods.PowerInformationLevel informationLevel, IntPtr inputBuffer, uint inputBufferSize, out PowerManagementNativeMethods.SystemPowerCapabilities outputBuffer, uint outputBufferSize);

		// Token: 0x0600008F RID: 143
		[DllImport("powrprof.dll")]
		internal static extern uint CallNtPowerInformation(PowerManagementNativeMethods.PowerInformationLevel informationLevel, IntPtr inputBuffer, uint inputBufferSize, out PowerManagementNativeMethods.SystemBatteryState outputBuffer, uint outputBufferSize);

		// Token: 0x06000090 RID: 144
		[DllImport("powrprof.dll")]
		internal static extern void PowerGetActiveScheme(IntPtr rootPowerKey, [MarshalAs(UnmanagedType.LPStruct)] out Guid activePolicy);

		// Token: 0x06000091 RID: 145
		[DllImport("User32", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
		internal static extern int RegisterPowerSettingNotification(IntPtr hRecipient, ref Guid PowerSettingGuid, int Flags);

		// Token: 0x06000092 RID: 146
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern ExecutionStates SetThreadExecutionState(ExecutionStates esFlags);

		// Token: 0x0400010D RID: 269
		internal const uint PowerBroadcastMessage = 536U;

		// Token: 0x0400010E RID: 270
		internal const uint PowerSettingChangeMessage = 32787U;

		// Token: 0x0400010F RID: 271
		internal const uint ScreenSaverSetActive = 17U;

		// Token: 0x04000110 RID: 272
		internal const uint UpdateInFile = 1U;

		// Token: 0x04000111 RID: 273
		internal const uint SendChange = 2U;

		// Token: 0x0200001D RID: 29
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct PowerBroadcastSetting
		{
			// Token: 0x04000112 RID: 274
			public Guid PowerSetting;

			// Token: 0x04000113 RID: 275
			public int DataLength;
		}

		// Token: 0x0200001E RID: 30
		public struct SystemPowerCapabilities
		{
			// Token: 0x04000114 RID: 276
			[MarshalAs(UnmanagedType.I1)]
			public bool PowerButtonPresent;

			// Token: 0x04000115 RID: 277
			[MarshalAs(UnmanagedType.I1)]
			public bool SleepButtonPresent;

			// Token: 0x04000116 RID: 278
			[MarshalAs(UnmanagedType.I1)]
			public bool LidPresent;

			// Token: 0x04000117 RID: 279
			[MarshalAs(UnmanagedType.I1)]
			public bool SystemS1;

			// Token: 0x04000118 RID: 280
			[MarshalAs(UnmanagedType.I1)]
			public bool SystemS2;

			// Token: 0x04000119 RID: 281
			[MarshalAs(UnmanagedType.I1)]
			public bool SystemS3;

			// Token: 0x0400011A RID: 282
			[MarshalAs(UnmanagedType.I1)]
			public bool SystemS4;

			// Token: 0x0400011B RID: 283
			[MarshalAs(UnmanagedType.I1)]
			public bool SystemS5;

			// Token: 0x0400011C RID: 284
			[MarshalAs(UnmanagedType.I1)]
			public bool HiberFilePresent;

			// Token: 0x0400011D RID: 285
			[MarshalAs(UnmanagedType.I1)]
			public bool FullWake;

			// Token: 0x0400011E RID: 286
			[MarshalAs(UnmanagedType.I1)]
			public bool VideoDimPresent;

			// Token: 0x0400011F RID: 287
			[MarshalAs(UnmanagedType.I1)]
			public bool ApmPresent;

			// Token: 0x04000120 RID: 288
			[MarshalAs(UnmanagedType.I1)]
			public bool UpsPresent;

			// Token: 0x04000121 RID: 289
			[MarshalAs(UnmanagedType.I1)]
			public bool ThermalControl;

			// Token: 0x04000122 RID: 290
			[MarshalAs(UnmanagedType.I1)]
			public bool ProcessorThrottle;

			// Token: 0x04000123 RID: 291
			public byte ProcessorMinimumThrottle;

			// Token: 0x04000124 RID: 292
			public byte ProcessorMaximumThrottle;

			// Token: 0x04000125 RID: 293
			[MarshalAs(UnmanagedType.I1)]
			public bool FastSystemS4;

			// Token: 0x04000126 RID: 294
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			public byte[] spare2;

			// Token: 0x04000127 RID: 295
			[MarshalAs(UnmanagedType.I1)]
			public bool DiskSpinDown;

			// Token: 0x04000128 RID: 296
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
			public byte[] spare3;

			// Token: 0x04000129 RID: 297
			[MarshalAs(UnmanagedType.I1)]
			public bool SystemBatteriesPresent;

			// Token: 0x0400012A RID: 298
			[MarshalAs(UnmanagedType.I1)]
			public bool BatteriesAreShortTerm;

			// Token: 0x0400012B RID: 299
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			public PowerManagementNativeMethods.BatteryReportingScale[] BatteryScale;

			// Token: 0x0400012C RID: 300
			public PowerManagementNativeMethods.SystemPowerState AcOnlineWake;

			// Token: 0x0400012D RID: 301
			public PowerManagementNativeMethods.SystemPowerState SoftLidWake;

			// Token: 0x0400012E RID: 302
			public PowerManagementNativeMethods.SystemPowerState RtcWake;

			// Token: 0x0400012F RID: 303
			public PowerManagementNativeMethods.SystemPowerState MinimumDeviceWakeState;

			// Token: 0x04000130 RID: 304
			public PowerManagementNativeMethods.SystemPowerState DefaultLowLatencyWake;
		}

		// Token: 0x0200001F RID: 31
		public enum PowerInformationLevel
		{
			// Token: 0x04000132 RID: 306
			SystemPowerPolicyAc,
			// Token: 0x04000133 RID: 307
			SystemPowerPolicyDc,
			// Token: 0x04000134 RID: 308
			VerifySystemPolicyAc,
			// Token: 0x04000135 RID: 309
			VerifySystemPolicyDc,
			// Token: 0x04000136 RID: 310
			SystemPowerCapabilities,
			// Token: 0x04000137 RID: 311
			SystemBatteryState,
			// Token: 0x04000138 RID: 312
			SystemPowerStateHandler,
			// Token: 0x04000139 RID: 313
			ProcessorStateHandler,
			// Token: 0x0400013A RID: 314
			SystemPowerPolicyCurrent,
			// Token: 0x0400013B RID: 315
			AdministratorPowerPolicy,
			// Token: 0x0400013C RID: 316
			SystemReserveHiberFile,
			// Token: 0x0400013D RID: 317
			ProcessorInformation,
			// Token: 0x0400013E RID: 318
			SystemPowerInformation,
			// Token: 0x0400013F RID: 319
			ProcessorStateHandler2,
			// Token: 0x04000140 RID: 320
			LastWakeTime,
			// Token: 0x04000141 RID: 321
			LastSleepTime,
			// Token: 0x04000142 RID: 322
			SystemExecutionState,
			// Token: 0x04000143 RID: 323
			SystemPowerStateNotifyHandler,
			// Token: 0x04000144 RID: 324
			ProcessorPowerPolicyAc,
			// Token: 0x04000145 RID: 325
			ProcessorPowerPolicyDc,
			// Token: 0x04000146 RID: 326
			VerifyProcessorPowerPolicyAc,
			// Token: 0x04000147 RID: 327
			VerifyProcessorPowerPolicyDc,
			// Token: 0x04000148 RID: 328
			ProcessorPowerPolicyCurrent,
			// Token: 0x04000149 RID: 329
			SystemPowerStateLogging,
			// Token: 0x0400014A RID: 330
			SystemPowerLoggingEntry,
			// Token: 0x0400014B RID: 331
			SetPowerSettingValue,
			// Token: 0x0400014C RID: 332
			NotifyUserPowerSetting,
			// Token: 0x0400014D RID: 333
			PowerInformationLevelUnused0,
			// Token: 0x0400014E RID: 334
			PowerInformationLevelUnused1,
			// Token: 0x0400014F RID: 335
			SystemVideoState,
			// Token: 0x04000150 RID: 336
			TraceApplicationPowerMessage,
			// Token: 0x04000151 RID: 337
			TraceApplicationPowerMessageEnd,
			// Token: 0x04000152 RID: 338
			ProcessorPerfStates,
			// Token: 0x04000153 RID: 339
			ProcessorIdleStates,
			// Token: 0x04000154 RID: 340
			ProcessorCap,
			// Token: 0x04000155 RID: 341
			SystemWakeSource,
			// Token: 0x04000156 RID: 342
			SystemHiberFileInformation,
			// Token: 0x04000157 RID: 343
			TraceServicePowerMessage,
			// Token: 0x04000158 RID: 344
			ProcessorLoad,
			// Token: 0x04000159 RID: 345
			PowerShutdownNotification,
			// Token: 0x0400015A RID: 346
			MonitorCapabilities,
			// Token: 0x0400015B RID: 347
			SessionPowerInit,
			// Token: 0x0400015C RID: 348
			SessionDisplayState,
			// Token: 0x0400015D RID: 349
			PowerRequestCreate,
			// Token: 0x0400015E RID: 350
			PowerRequestAction,
			// Token: 0x0400015F RID: 351
			GetPowerRequestList,
			// Token: 0x04000160 RID: 352
			ProcessorInformationEx,
			// Token: 0x04000161 RID: 353
			NotifyUserModeLegacyPowerEvent,
			// Token: 0x04000162 RID: 354
			GroupPark,
			// Token: 0x04000163 RID: 355
			ProcessorIdleDomains,
			// Token: 0x04000164 RID: 356
			WakeTimerList,
			// Token: 0x04000165 RID: 357
			SystemHiberFileSize,
			// Token: 0x04000166 RID: 358
			PowerInformationLevelMaximum
		}

		// Token: 0x02000020 RID: 32
		public struct BatteryReportingScale
		{
			// Token: 0x04000167 RID: 359
			public uint Granularity;

			// Token: 0x04000168 RID: 360
			public uint Capacity;
		}

		// Token: 0x02000021 RID: 33
		public enum SystemPowerState
		{
			// Token: 0x0400016A RID: 362
			Unspecified,
			// Token: 0x0400016B RID: 363
			Working,
			// Token: 0x0400016C RID: 364
			Sleeping1,
			// Token: 0x0400016D RID: 365
			Sleeping2,
			// Token: 0x0400016E RID: 366
			Sleeping3,
			// Token: 0x0400016F RID: 367
			Hibernate,
			// Token: 0x04000170 RID: 368
			Shutdown,
			// Token: 0x04000171 RID: 369
			Maximum
		}

		// Token: 0x02000022 RID: 34
		public struct SystemBatteryState
		{
			// Token: 0x04000172 RID: 370
			[MarshalAs(UnmanagedType.I1)]
			public bool AcOnLine;

			// Token: 0x04000173 RID: 371
			[MarshalAs(UnmanagedType.I1)]
			public bool BatteryPresent;

			// Token: 0x04000174 RID: 372
			[MarshalAs(UnmanagedType.I1)]
			public bool Charging;

			// Token: 0x04000175 RID: 373
			[MarshalAs(UnmanagedType.I1)]
			public bool Discharging;

			// Token: 0x04000176 RID: 374
			public byte Spare1;

			// Token: 0x04000177 RID: 375
			public byte Spare2;

			// Token: 0x04000178 RID: 376
			public byte Spare3;

			// Token: 0x04000179 RID: 377
			public byte Spare4;

			// Token: 0x0400017A RID: 378
			public uint MaxCapacity;

			// Token: 0x0400017B RID: 379
			public uint RemainingCapacity;

			// Token: 0x0400017C RID: 380
			public uint Rate;

			// Token: 0x0400017D RID: 381
			public uint EstimatedTime;

			// Token: 0x0400017E RID: 382
			public uint DefaultAlert1;

			// Token: 0x0400017F RID: 383
			public uint DefaultAlert2;
		}
	}
}
