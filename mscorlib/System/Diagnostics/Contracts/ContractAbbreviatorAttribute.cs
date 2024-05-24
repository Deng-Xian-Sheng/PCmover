using System;

namespace System.Diagnostics.Contracts
{
	// Token: 0x02000412 RID: 1042
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	[Conditional("CONTRACTS_FULL")]
	[__DynamicallyInvokable]
	public sealed class ContractAbbreviatorAttribute : Attribute
	{
		// Token: 0x060033F5 RID: 13301 RVA: 0x000C670B File Offset: 0x000C490B
		[__DynamicallyInvokable]
		public ContractAbbreviatorAttribute()
		{
		}
	}
}
