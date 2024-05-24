using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Activation
{
	// Token: 0x02000899 RID: 2201
	[ComVisible(true)]
	[Serializable]
	public enum ActivatorLevel
	{
		// Token: 0x040029EF RID: 10735
		Construction = 4,
		// Token: 0x040029F0 RID: 10736
		Context = 8,
		// Token: 0x040029F1 RID: 10737
		AppDomain = 12,
		// Token: 0x040029F2 RID: 10738
		Process = 16,
		// Token: 0x040029F3 RID: 10739
		Machine = 20
	}
}
