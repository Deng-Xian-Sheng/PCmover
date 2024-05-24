using System;

namespace System.Diagnostics.Contracts
{
	// Token: 0x0200040F RID: 1039
	[Conditional("CONTRACTS_FULL")]
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property)]
	[__DynamicallyInvokable]
	public sealed class ContractVerificationAttribute : Attribute
	{
		// Token: 0x060033F0 RID: 13296 RVA: 0x000C66D5 File Offset: 0x000C48D5
		[__DynamicallyInvokable]
		public ContractVerificationAttribute(bool value)
		{
			this._value = value;
		}

		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x060033F1 RID: 13297 RVA: 0x000C66E4 File Offset: 0x000C48E4
		[__DynamicallyInvokable]
		public bool Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._value;
			}
		}

		// Token: 0x04001702 RID: 5890
		private bool _value;
	}
}
