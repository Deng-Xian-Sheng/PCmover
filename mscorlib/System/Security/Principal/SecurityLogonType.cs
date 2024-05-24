using System;

namespace System.Security.Principal
{
	// Token: 0x0200032D RID: 813
	[Serializable]
	internal enum SecurityLogonType
	{
		// Token: 0x04001047 RID: 4167
		Interactive = 2,
		// Token: 0x04001048 RID: 4168
		Network,
		// Token: 0x04001049 RID: 4169
		Batch,
		// Token: 0x0400104A RID: 4170
		Service,
		// Token: 0x0400104B RID: 4171
		Proxy,
		// Token: 0x0400104C RID: 4172
		Unlock
	}
}
