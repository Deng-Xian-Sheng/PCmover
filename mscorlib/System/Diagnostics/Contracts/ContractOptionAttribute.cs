using System;

namespace System.Diagnostics.Contracts
{
	// Token: 0x02000413 RID: 1043
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	[Conditional("CONTRACTS_FULL")]
	[__DynamicallyInvokable]
	public sealed class ContractOptionAttribute : Attribute
	{
		// Token: 0x060033F6 RID: 13302 RVA: 0x000C6713 File Offset: 0x000C4913
		[__DynamicallyInvokable]
		public ContractOptionAttribute(string category, string setting, bool enabled)
		{
			this._category = category;
			this._setting = setting;
			this._enabled = enabled;
		}

		// Token: 0x060033F7 RID: 13303 RVA: 0x000C6730 File Offset: 0x000C4930
		[__DynamicallyInvokable]
		public ContractOptionAttribute(string category, string setting, string value)
		{
			this._category = category;
			this._setting = setting;
			this._value = value;
		}

		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x060033F8 RID: 13304 RVA: 0x000C674D File Offset: 0x000C494D
		[__DynamicallyInvokable]
		public string Category
		{
			[__DynamicallyInvokable]
			get
			{
				return this._category;
			}
		}

		// Token: 0x170007A6 RID: 1958
		// (get) Token: 0x060033F9 RID: 13305 RVA: 0x000C6755 File Offset: 0x000C4955
		[__DynamicallyInvokable]
		public string Setting
		{
			[__DynamicallyInvokable]
			get
			{
				return this._setting;
			}
		}

		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x060033FA RID: 13306 RVA: 0x000C675D File Offset: 0x000C495D
		[__DynamicallyInvokable]
		public bool Enabled
		{
			[__DynamicallyInvokable]
			get
			{
				return this._enabled;
			}
		}

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x060033FB RID: 13307 RVA: 0x000C6765 File Offset: 0x000C4965
		[__DynamicallyInvokable]
		public string Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._value;
			}
		}

		// Token: 0x04001704 RID: 5892
		private string _category;

		// Token: 0x04001705 RID: 5893
		private string _setting;

		// Token: 0x04001706 RID: 5894
		private bool _enabled;

		// Token: 0x04001707 RID: 5895
		private string _value;
	}
}
