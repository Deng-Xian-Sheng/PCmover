using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000098 RID: 152
	public class UserMapping
	{
		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x000048B9 File Offset: 0x00002AB9
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x000048C1 File Offset: 0x00002AC1
		public UserDetail Old { get; set; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x000048CA File Offset: 0x00002ACA
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x000048D2 File Offset: 0x00002AD2
		public UserDetail New { get; set; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x000048DB File Offset: 0x00002ADB
		// (set) Token: 0x060003FA RID: 1018 RVA: 0x000048E3 File Offset: 0x00002AE3
		public bool Create { get; set; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x000048EC File Offset: 0x00002AEC
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x000048F4 File Offset: 0x00002AF4
		public bool MoveFiles { get; set; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x000048FD File Offset: 0x00002AFD
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x00004905 File Offset: 0x00002B05
		public IEnumerable<MapiProfileMapping> MapiProfileMappings { get; set; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x0000490E File Offset: 0x00002B0E
		// (set) Token: 0x06000400 RID: 1024 RVA: 0x00004916 File Offset: 0x00002B16
		public IEnumerable<string> AvailableProfiles { get; set; }
	}
}
