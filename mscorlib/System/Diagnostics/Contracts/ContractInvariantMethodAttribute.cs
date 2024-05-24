using System;

namespace System.Diagnostics.Contracts
{
	// Token: 0x0200040C RID: 1036
	[Conditional("CONTRACTS_FULL")]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class ContractInvariantMethodAttribute : Attribute
	{
		// Token: 0x060033ED RID: 13293 RVA: 0x000C66BD File Offset: 0x000C48BD
		[__DynamicallyInvokable]
		public ContractInvariantMethodAttribute()
		{
		}
	}
}
