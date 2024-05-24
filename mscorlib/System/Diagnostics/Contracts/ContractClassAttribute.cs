using System;

namespace System.Diagnostics.Contracts
{
	// Token: 0x0200040A RID: 1034
	[Conditional("CONTRACTS_FULL")]
	[Conditional("DEBUG")]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class ContractClassAttribute : Attribute
	{
		// Token: 0x060033E9 RID: 13289 RVA: 0x000C668F File Offset: 0x000C488F
		[__DynamicallyInvokable]
		public ContractClassAttribute(Type typeContainingContracts)
		{
			this._typeWithContracts = typeContainingContracts;
		}

		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x060033EA RID: 13290 RVA: 0x000C669E File Offset: 0x000C489E
		[__DynamicallyInvokable]
		public Type TypeContainingContracts
		{
			[__DynamicallyInvokable]
			get
			{
				return this._typeWithContracts;
			}
		}

		// Token: 0x04001700 RID: 5888
		private Type _typeWithContracts;
	}
}
