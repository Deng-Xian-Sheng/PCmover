using System;

namespace System.Diagnostics.Contracts
{
	// Token: 0x0200040E RID: 1038
	[Conditional("CONTRACTS_FULL")]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	[__DynamicallyInvokable]
	public sealed class ContractRuntimeIgnoredAttribute : Attribute
	{
		// Token: 0x060033EF RID: 13295 RVA: 0x000C66CD File Offset: 0x000C48CD
		[__DynamicallyInvokable]
		public ContractRuntimeIgnoredAttribute()
		{
		}
	}
}
