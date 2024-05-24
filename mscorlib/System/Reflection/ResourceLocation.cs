using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005F3 RID: 1523
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum ResourceLocation
	{
		// Token: 0x04001CD5 RID: 7381
		[__DynamicallyInvokable]
		Embedded = 1,
		// Token: 0x04001CD6 RID: 7382
		[__DynamicallyInvokable]
		ContainedInAnotherAssembly = 2,
		// Token: 0x04001CD7 RID: 7383
		[__DynamicallyInvokable]
		ContainedInManifestFile = 4
	}
}
