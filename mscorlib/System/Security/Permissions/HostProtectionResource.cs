using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002E3 RID: 739
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum HostProtectionResource
	{
		// Token: 0x04000E8B RID: 3723
		None = 0,
		// Token: 0x04000E8C RID: 3724
		Synchronization = 1,
		// Token: 0x04000E8D RID: 3725
		SharedState = 2,
		// Token: 0x04000E8E RID: 3726
		ExternalProcessMgmt = 4,
		// Token: 0x04000E8F RID: 3727
		SelfAffectingProcessMgmt = 8,
		// Token: 0x04000E90 RID: 3728
		ExternalThreading = 16,
		// Token: 0x04000E91 RID: 3729
		SelfAffectingThreading = 32,
		// Token: 0x04000E92 RID: 3730
		SecurityInfrastructure = 64,
		// Token: 0x04000E93 RID: 3731
		UI = 128,
		// Token: 0x04000E94 RID: 3732
		MayLeakOnAbort = 256,
		// Token: 0x04000E95 RID: 3733
		All = 511
	}
}
