using System;

namespace System.Diagnostics.Contracts
{
	// Token: 0x0200040B RID: 1035
	[Conditional("CONTRACTS_FULL")]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class ContractClassForAttribute : Attribute
	{
		// Token: 0x060033EB RID: 13291 RVA: 0x000C66A6 File Offset: 0x000C48A6
		[__DynamicallyInvokable]
		public ContractClassForAttribute(Type typeContractsAreFor)
		{
			this._typeIAmAContractFor = typeContractsAreFor;
		}

		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x060033EC RID: 13292 RVA: 0x000C66B5 File Offset: 0x000C48B5
		[__DynamicallyInvokable]
		public Type TypeContractsAreFor
		{
			[__DynamicallyInvokable]
			get
			{
				return this._typeIAmAContractFor;
			}
		}

		// Token: 0x04001701 RID: 5889
		private Type _typeIAmAContractFor;
	}
}
