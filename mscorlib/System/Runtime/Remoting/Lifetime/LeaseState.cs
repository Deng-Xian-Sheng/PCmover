using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Lifetime
{
	// Token: 0x02000822 RID: 2082
	[ComVisible(true)]
	[Serializable]
	public enum LeaseState
	{
		// Token: 0x040028AA RID: 10410
		Null,
		// Token: 0x040028AB RID: 10411
		Initial,
		// Token: 0x040028AC RID: 10412
		Active,
		// Token: 0x040028AD RID: 10413
		Renewing,
		// Token: 0x040028AE RID: 10414
		Expired
	}
}
