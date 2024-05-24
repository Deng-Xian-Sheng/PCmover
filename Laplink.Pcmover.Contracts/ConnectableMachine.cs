using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000030 RID: 48
	public class ConnectableMachine
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00002D7C File Offset: 0x00000F7C
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x00002D84 File Offset: 0x00000F84
		public string FriendlyName { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00002D8D File Offset: 0x00000F8D
		// (set) Token: 0x060000FA RID: 250 RVA: 0x00002D95 File Offset: 0x00000F95
		public string NetName { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00002D9E File Offset: 0x00000F9E
		// (set) Token: 0x060000FC RID: 252 RVA: 0x00002DA6 File Offset: 0x00000FA6
		public string DisplayName { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00002DAF File Offset: 0x00000FAF
		// (set) Token: 0x060000FE RID: 254 RVA: 0x00002DB7 File Offset: 0x00000FB7
		public string ConnectionName { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00002DC0 File Offset: 0x00000FC0
		// (set) Token: 0x06000100 RID: 256 RVA: 0x00002DC8 File Offset: 0x00000FC8
		public TransferMethodType Method { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00002DD1 File Offset: 0x00000FD1
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00002DD9 File Offset: 0x00000FD9
		public int TransferMethodHandle { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00002DE2 File Offset: 0x00000FE2
		// (set) Token: 0x06000104 RID: 260 RVA: 0x00002DEA File Offset: 0x00000FEA
		public DateTime CreationTime { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00002DF3 File Offset: 0x00000FF3
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00002DFB File Offset: 0x00000FFB
		public ulong LinkSpeed { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00002E04 File Offset: 0x00001004
		// (set) Token: 0x06000108 RID: 264 RVA: 0x00002E0C File Offset: 0x0000100C
		public bool IsOld { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00002E15 File Offset: 0x00001015
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00002E1D File Offset: 0x0000101D
		public string SerialNumber { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00002E26 File Offset: 0x00001026
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00002E2E File Offset: 0x0000102E
		public string OperatingSystem { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00002E37 File Offset: 0x00001037
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00002E3F File Offset: 0x0000103F
		public int OSmajor { get; set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00002E48 File Offset: 0x00001048
		// (set) Token: 0x06000110 RID: 272 RVA: 0x00002E50 File Offset: 0x00001050
		public int OSminor { get; set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00002E59 File Offset: 0x00001059
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00002E61 File Offset: 0x00001061
		public int OSbuild { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00002E6A File Offset: 0x0000106A
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00002E72 File Offset: 0x00001072
		public string Cpu { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00002E7B File Offset: 0x0000107B
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00002E83 File Offset: 0x00001083
		public bool HasValidSerialNumber { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00002E8C File Offset: 0x0000108C
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00002E94 File Offset: 0x00001094
		public bool XPVersion { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00002E9D File Offset: 0x0000109D
		// (set) Token: 0x0600011A RID: 282 RVA: 0x00002EA5 File Offset: 0x000010A5
		public string CertificateName { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00002EAE File Offset: 0x000010AE
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00002EB6 File Offset: 0x000010B6
		public string UniqueId { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00002EBF File Offset: 0x000010BF
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00002EC7 File Offset: 0x000010C7
		public DiscoveredMachineStatus Status { get; set; }
	}
}
