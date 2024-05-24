using System;

namespace IntelEMA
{
	// Token: 0x02000008 RID: 8
	public class EndpointData
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000021B0 File Offset: 0x000003B0
		// (set) Token: 0x06000015 RID: 21 RVA: 0x000021B8 File Offset: 0x000003B8
		public string EndpointId { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000021C1 File Offset: 0x000003C1
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000021C9 File Offset: 0x000003C9
		public string EndpointGroupId { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000021D2 File Offset: 0x000003D2
		// (set) Token: 0x06000019 RID: 25 RVA: 0x000021DA File Offset: 0x000003DA
		public string EndpointGroupName { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000021E3 File Offset: 0x000003E3
		// (set) Token: 0x0600001B RID: 27 RVA: 0x000021EB File Offset: 0x000003EB
		public string LastUpdate { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000021F4 File Offset: 0x000003F4
		// (set) Token: 0x0600001D RID: 29 RVA: 0x000021FC File Offset: 0x000003FC
		public string MEVersion { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002205 File Offset: 0x00000405
		// (set) Token: 0x0600001F RID: 31 RVA: 0x0000220D File Offset: 0x0000040D
		public string ComputerName { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002216 File Offset: 0x00000416
		// (set) Token: 0x06000021 RID: 33 RVA: 0x0000221E File Offset: 0x0000041E
		public int? PlatformType { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002227 File Offset: 0x00000427
		// (set) Token: 0x06000023 RID: 35 RVA: 0x0000222F File Offset: 0x0000042F
		public int? AgentVersion { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002238 File Offset: 0x00000438
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00002240 File Offset: 0x00000440
		public int? AgentIdentifier { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002249 File Offset: 0x00000449
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00002251 File Offset: 0x00000451
		public int? MEFWBuildNumber { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000028 RID: 40 RVA: 0x0000225A File Offset: 0x0000045A
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00002262 File Offset: 0x00000462
		public int? PowerState { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600002A RID: 42 RVA: 0x0000226B File Offset: 0x0000046B
		// (set) Token: 0x0600002B RID: 43 RVA: 0x00002273 File Offset: 0x00000473
		public string PowerStateUpdate { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002C RID: 44 RVA: 0x0000227C File Offset: 0x0000047C
		// (set) Token: 0x0600002D RID: 45 RVA: 0x00002284 File Offset: 0x00000484
		public bool? IsConnected { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002E RID: 46 RVA: 0x0000228D File Offset: 0x0000048D
		// (set) Token: 0x0600002F RID: 47 RVA: 0x00002295 File Offset: 0x00000495
		public int? NodeIdentity { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000030 RID: 48 RVA: 0x0000229E File Offset: 0x0000049E
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000022A6 File Offset: 0x000004A6
		public bool? IsAmtVersionValid { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000022AF File Offset: 0x000004AF
		// (set) Token: 0x06000033 RID: 51 RVA: 0x000022B7 File Offset: 0x000004B7
		public int? AmtControlMode { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000022C0 File Offset: 0x000004C0
		// (set) Token: 0x06000035 RID: 53 RVA: 0x000022C8 File Offset: 0x000004C8
		public int? AmtProvisioningState { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000036 RID: 54 RVA: 0x000022D1 File Offset: 0x000004D1
		// (set) Token: 0x06000037 RID: 55 RVA: 0x000022D9 File Offset: 0x000004D9
		public int? AmtProvisioningMode { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000038 RID: 56 RVA: 0x000022E2 File Offset: 0x000004E2
		// (set) Token: 0x06000039 RID: 57 RVA: 0x000022EA File Offset: 0x000004EA
		public bool? IsCiraConnected { get; set; }
	}
}
