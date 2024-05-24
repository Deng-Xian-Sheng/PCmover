using System;

namespace System.Diagnostics.Contracts
{
	// Token: 0x02000409 RID: 1033
	[Conditional("CONTRACTS_FULL")]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = false, Inherited = true)]
	[__DynamicallyInvokable]
	public sealed class PureAttribute : Attribute
	{
		// Token: 0x060033E8 RID: 13288 RVA: 0x000C6687 File Offset: 0x000C4887
		[__DynamicallyInvokable]
		public PureAttribute()
		{
		}
	}
}
