using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000936 RID: 2358
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
	[ComVisible(true)]
	public sealed class ComAliasNameAttribute : Attribute
	{
		// Token: 0x06006043 RID: 24643 RVA: 0x0014BDA5 File Offset: 0x00149FA5
		public ComAliasNameAttribute(string alias)
		{
			this._val = alias;
		}

		// Token: 0x170010E5 RID: 4325
		// (get) Token: 0x06006044 RID: 24644 RVA: 0x0014BDB4 File Offset: 0x00149FB4
		public string Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002B1A RID: 11034
		internal string _val;
	}
}
