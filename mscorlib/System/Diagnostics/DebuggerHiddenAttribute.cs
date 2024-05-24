using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	// Token: 0x020003E8 RID: 1000
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DebuggerHiddenAttribute : Attribute
	{
		// Token: 0x06003304 RID: 13060 RVA: 0x000C4B50 File Offset: 0x000C2D50
		[__DynamicallyInvokable]
		public DebuggerHiddenAttribute()
		{
		}
	}
}
