using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200091E RID: 2334
	[Obsolete("The IDispatchImplAttribute is deprecated.", false)]
	[ComVisible(true)]
	[Serializable]
	public enum IDispatchImplType
	{
		// Token: 0x04002A70 RID: 10864
		SystemDefinedImpl,
		// Token: 0x04002A71 RID: 10865
		InternalImpl,
		// Token: 0x04002A72 RID: 10866
		CompatibleImpl
	}
}
