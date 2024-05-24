using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002E9 RID: 745
	[ComVisible(true)]
	[Serializable]
	public enum IsolatedStorageContainment
	{
		// Token: 0x04000EBD RID: 3773
		None,
		// Token: 0x04000EBE RID: 3774
		DomainIsolationByUser = 16,
		// Token: 0x04000EBF RID: 3775
		ApplicationIsolationByUser = 21,
		// Token: 0x04000EC0 RID: 3776
		AssemblyIsolationByUser = 32,
		// Token: 0x04000EC1 RID: 3777
		DomainIsolationByMachine = 48,
		// Token: 0x04000EC2 RID: 3778
		AssemblyIsolationByMachine = 64,
		// Token: 0x04000EC3 RID: 3779
		ApplicationIsolationByMachine = 69,
		// Token: 0x04000EC4 RID: 3780
		DomainIsolationByRoamingUser = 80,
		// Token: 0x04000EC5 RID: 3781
		AssemblyIsolationByRoamingUser = 96,
		// Token: 0x04000EC6 RID: 3782
		ApplicationIsolationByRoamingUser = 101,
		// Token: 0x04000EC7 RID: 3783
		AdministerIsolatedStorageByUser = 112,
		// Token: 0x04000EC8 RID: 3784
		UnrestrictedIsolatedStorage = 240
	}
}
