using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000033 RID: 51
	[Flags]
	public enum CustomizationAffects
	{
		// Token: 0x04000117 RID: 279
		None = 0,
		// Token: 0x04000118 RID: 280
		ItemsToTransfer = 1,
		// Token: 0x04000119 RID: 281
		MiscSettings = 2,
		// Token: 0x0400011A RID: 282
		Users = 4,
		// Token: 0x0400011B RID: 283
		Applications = 8,
		// Token: 0x0400011C RID: 284
		Drives = 16,
		// Token: 0x0400011D RID: 285
		DiskItems = 32,
		// Token: 0x0400011E RID: 286
		RegistryItems = 64,
		// Token: 0x0400011F RID: 287
		FileFilters = 128,
		// Token: 0x04000120 RID: 288
		RegistryFilters = 256
	}
}
