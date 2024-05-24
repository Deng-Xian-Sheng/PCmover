using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000845 RID: 2117
	[ComVisible(true)]
	[Serializable]
	public enum ServerProcessing
	{
		// Token: 0x040028F1 RID: 10481
		Complete,
		// Token: 0x040028F2 RID: 10482
		OneWay,
		// Token: 0x040028F3 RID: 10483
		Async
	}
}
