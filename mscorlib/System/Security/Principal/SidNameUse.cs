using System;

namespace System.Security.Principal
{
	// Token: 0x02000338 RID: 824
	internal enum SidNameUse
	{
		// Token: 0x0400109B RID: 4251
		User = 1,
		// Token: 0x0400109C RID: 4252
		Group,
		// Token: 0x0400109D RID: 4253
		Domain,
		// Token: 0x0400109E RID: 4254
		Alias,
		// Token: 0x0400109F RID: 4255
		WellKnownGroup,
		// Token: 0x040010A0 RID: 4256
		DeletedAccount,
		// Token: 0x040010A1 RID: 4257
		Invalid,
		// Token: 0x040010A2 RID: 4258
		Unknown,
		// Token: 0x040010A3 RID: 4259
		Computer
	}
}
