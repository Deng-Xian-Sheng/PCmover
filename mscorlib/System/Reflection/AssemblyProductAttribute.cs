using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005B5 RID: 1461
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyProductAttribute : Attribute
	{
		// Token: 0x06004450 RID: 17488 RVA: 0x000FC2F2 File Offset: 0x000FA4F2
		[__DynamicallyInvokable]
		public AssemblyProductAttribute(string product)
		{
			this.m_product = product;
		}

		// Token: 0x17000A11 RID: 2577
		// (get) Token: 0x06004451 RID: 17489 RVA: 0x000FC301 File Offset: 0x000FA501
		[__DynamicallyInvokable]
		public string Product
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_product;
			}
		}

		// Token: 0x04001BF8 RID: 7160
		private string m_product;
	}
}
