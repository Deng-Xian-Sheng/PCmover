using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200095C RID: 2396
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class CurrencyWrapper
	{
		// Token: 0x06006211 RID: 25105 RVA: 0x0014F57E File Offset: 0x0014D77E
		[__DynamicallyInvokable]
		public CurrencyWrapper(decimal obj)
		{
			this.m_WrappedObject = obj;
		}

		// Token: 0x06006212 RID: 25106 RVA: 0x0014F58D File Offset: 0x0014D78D
		[__DynamicallyInvokable]
		public CurrencyWrapper(object obj)
		{
			if (!(obj is decimal))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeDecimal"), "obj");
			}
			this.m_WrappedObject = (decimal)obj;
		}

		// Token: 0x17001111 RID: 4369
		// (get) Token: 0x06006213 RID: 25107 RVA: 0x0014F5BE File Offset: 0x0014D7BE
		[__DynamicallyInvokable]
		public decimal WrappedObject
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_WrappedObject;
			}
		}

		// Token: 0x04002B85 RID: 11141
		private decimal m_WrappedObject;
	}
}
