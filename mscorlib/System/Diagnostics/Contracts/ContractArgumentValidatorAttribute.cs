using System;

namespace System.Diagnostics.Contracts
{
	// Token: 0x02000411 RID: 1041
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	[Conditional("CONTRACTS_FULL")]
	[__DynamicallyInvokable]
	public sealed class ContractArgumentValidatorAttribute : Attribute
	{
		// Token: 0x060033F4 RID: 13300 RVA: 0x000C6703 File Offset: 0x000C4903
		[__DynamicallyInvokable]
		public ContractArgumentValidatorAttribute()
		{
		}
	}
}
