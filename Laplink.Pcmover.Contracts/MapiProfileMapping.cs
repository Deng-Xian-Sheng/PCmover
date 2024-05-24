using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000097 RID: 151
	public class MapiProfileMapping
	{
		// Token: 0x060003ED RID: 1005 RVA: 0x00002050 File Offset: 0x00000250
		public MapiProfileMapping()
		{
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00004870 File Offset: 0x00002A70
		public MapiProfileMapping(string oldProfile, string newProfile)
		{
			this.OldProfile = oldProfile;
			this.NewProfile = newProfile;
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x00004886 File Offset: 0x00002A86
		// (set) Token: 0x060003F0 RID: 1008 RVA: 0x0000488E File Offset: 0x00002A8E
		public string OldProfile { get; set; }

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x00004897 File Offset: 0x00002A97
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x0000489F File Offset: 0x00002A9F
		public string NewProfile { get; set; }

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x000048A8 File Offset: 0x00002AA8
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x000048B0 File Offset: 0x00002AB0
		public bool Transfer { get; set; }
	}
}
