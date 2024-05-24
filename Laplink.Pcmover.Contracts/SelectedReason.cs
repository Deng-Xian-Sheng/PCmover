using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000010 RID: 16
	public enum SelectedReason
	{
		// Token: 0x0400005E RID: 94
		Unknown,
		// Token: 0x0400005F RID: 95
		Default,
		// Token: 0x04000060 RID: 96
		User,
		// Token: 0x04000061 RID: 97
		Parent,
		// Token: 0x04000062 RID: 98
		AppProfileFile,
		// Token: 0x04000063 RID: 99
		DifferentVersion,
		// Token: 0x04000064 RID: 100
		UserNotTransferred,
		// Token: 0x04000065 RID: 101
		IncompatibleOs,
		// Token: 0x04000066 RID: 102
		SxsBroken,
		// Token: 0x04000067 RID: 103
		Component,
		// Token: 0x04000068 RID: 104
		Bitness32To64,
		// Token: 0x04000069 RID: 105
		SameBitness,
		// Token: 0x0400006A RID: 106
		DifferentVersionTrial,
		// Token: 0x0400006B RID: 107
		Unavailable
	}
}
