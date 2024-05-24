using System;

namespace System.Diagnostics.Contracts
{
	// Token: 0x02000410 RID: 1040
	[Conditional("CONTRACTS_FULL")]
	[AttributeUsage(AttributeTargets.Field)]
	[__DynamicallyInvokable]
	public sealed class ContractPublicPropertyNameAttribute : Attribute
	{
		// Token: 0x060033F2 RID: 13298 RVA: 0x000C66EC File Offset: 0x000C48EC
		[__DynamicallyInvokable]
		public ContractPublicPropertyNameAttribute(string name)
		{
			this._publicName = name;
		}

		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x060033F3 RID: 13299 RVA: 0x000C66FB File Offset: 0x000C48FB
		[__DynamicallyInvokable]
		public string Name
		{
			[__DynamicallyInvokable]
			get
			{
				return this._publicName;
			}
		}

		// Token: 0x04001703 RID: 5891
		private string _publicName;
	}
}
