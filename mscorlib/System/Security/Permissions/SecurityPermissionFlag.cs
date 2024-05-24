using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x02000305 RID: 773
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum SecurityPermissionFlag
	{
		// Token: 0x04000F1D RID: 3869
		NoFlags = 0,
		// Token: 0x04000F1E RID: 3870
		Assertion = 1,
		// Token: 0x04000F1F RID: 3871
		UnmanagedCode = 2,
		// Token: 0x04000F20 RID: 3872
		SkipVerification = 4,
		// Token: 0x04000F21 RID: 3873
		Execution = 8,
		// Token: 0x04000F22 RID: 3874
		ControlThread = 16,
		// Token: 0x04000F23 RID: 3875
		ControlEvidence = 32,
		// Token: 0x04000F24 RID: 3876
		ControlPolicy = 64,
		// Token: 0x04000F25 RID: 3877
		SerializationFormatter = 128,
		// Token: 0x04000F26 RID: 3878
		ControlDomainPolicy = 256,
		// Token: 0x04000F27 RID: 3879
		ControlPrincipal = 512,
		// Token: 0x04000F28 RID: 3880
		ControlAppDomain = 1024,
		// Token: 0x04000F29 RID: 3881
		RemotingConfiguration = 2048,
		// Token: 0x04000F2A RID: 3882
		Infrastructure = 4096,
		// Token: 0x04000F2B RID: 3883
		BindingRedirects = 8192,
		// Token: 0x04000F2C RID: 3884
		AllFlags = 16383
	}
}
