using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002AE RID: 686
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum X509KeyStorageFlags
	{
		// Token: 0x04000D8F RID: 3471
		DefaultKeySet = 0,
		// Token: 0x04000D90 RID: 3472
		UserKeySet = 1,
		// Token: 0x04000D91 RID: 3473
		MachineKeySet = 2,
		// Token: 0x04000D92 RID: 3474
		Exportable = 4,
		// Token: 0x04000D93 RID: 3475
		UserProtected = 8,
		// Token: 0x04000D94 RID: 3476
		PersistKeySet = 16,
		// Token: 0x04000D95 RID: 3477
		EphemeralKeySet = 32
	}
}
