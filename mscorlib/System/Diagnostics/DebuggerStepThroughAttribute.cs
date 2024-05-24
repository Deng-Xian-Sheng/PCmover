using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	// Token: 0x020003E6 RID: 998
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DebuggerStepThroughAttribute : Attribute
	{
		// Token: 0x06003302 RID: 13058 RVA: 0x000C4B40 File Offset: 0x000C2D40
		[__DynamicallyInvokable]
		public DebuggerStepThroughAttribute()
		{
		}
	}
}
