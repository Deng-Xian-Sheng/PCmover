using System;

namespace System.Runtime.ConstrainedExecution
{
	// Token: 0x02000729 RID: 1833
	[Serializable]
	public enum Consistency
	{
		// Token: 0x04002429 RID: 9257
		MayCorruptProcess,
		// Token: 0x0400242A RID: 9258
		MayCorruptAppDomain,
		// Token: 0x0400242B RID: 9259
		MayCorruptInstance,
		// Token: 0x0400242C RID: 9260
		WillNotCorruptState
	}
}
