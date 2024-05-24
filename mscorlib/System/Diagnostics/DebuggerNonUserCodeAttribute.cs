using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	// Token: 0x020003E9 RID: 1001
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DebuggerNonUserCodeAttribute : Attribute
	{
		// Token: 0x06003305 RID: 13061 RVA: 0x000C4B58 File Offset: 0x000C2D58
		[__DynamicallyInvokable]
		public DebuggerNonUserCodeAttribute()
		{
		}
	}
}
