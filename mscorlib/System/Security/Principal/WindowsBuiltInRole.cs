using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	// Token: 0x02000331 RID: 817
	[ComVisible(true)]
	[Serializable]
	public enum WindowsBuiltInRole
	{
		// Token: 0x0400107C RID: 4220
		Administrator = 544,
		// Token: 0x0400107D RID: 4221
		User,
		// Token: 0x0400107E RID: 4222
		Guest,
		// Token: 0x0400107F RID: 4223
		PowerUser,
		// Token: 0x04001080 RID: 4224
		AccountOperator,
		// Token: 0x04001081 RID: 4225
		SystemOperator,
		// Token: 0x04001082 RID: 4226
		PrintOperator,
		// Token: 0x04001083 RID: 4227
		BackupOperator,
		// Token: 0x04001084 RID: 4228
		Replicator
	}
}
