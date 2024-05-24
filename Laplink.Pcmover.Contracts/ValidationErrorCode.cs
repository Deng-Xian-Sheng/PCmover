using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000061 RID: 97
	public enum ValidationErrorCode
	{
		// Token: 0x04000240 RID: 576
		None,
		// Token: 0x04000241 RID: 577
		Generic,
		// Token: 0x04000242 RID: 578
		InvalidParameter,
		// Token: 0x04000243 RID: 579
		Unauthorized,
		// Token: 0x04000244 RID: 580
		Database,
		// Token: 0x04000245 RID: 581
		SerialNum,
		// Token: 0x04000246 RID: 582
		NoLicenses,
		// Token: 0x04000247 RID: 583
		WrongVersion,
		// Token: 0x04000248 RID: 584
		WrongEdition,
		// Token: 0x04000249 RID: 585
		Obsolete,
		// Token: 0x0400024A RID: 586
		LicenseReuse,
		// Token: 0x0400024B RID: 587
		Internet = 999
	}
}
