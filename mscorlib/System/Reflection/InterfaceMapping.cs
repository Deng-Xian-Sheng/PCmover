using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005ED RID: 1517
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public struct InterfaceMapping
	{
		// Token: 0x04001CC8 RID: 7368
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public Type TargetType;

		// Token: 0x04001CC9 RID: 7369
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public Type InterfaceType;

		// Token: 0x04001CCA RID: 7370
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public MethodInfo[] TargetMethods;

		// Token: 0x04001CCB RID: 7371
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public MethodInfo[] InterfaceMethods;
	}
}
