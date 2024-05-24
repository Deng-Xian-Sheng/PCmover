using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005B4 RID: 1460
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyTrademarkAttribute : Attribute
	{
		// Token: 0x0600444E RID: 17486 RVA: 0x000FC2DB File Offset: 0x000FA4DB
		[__DynamicallyInvokable]
		public AssemblyTrademarkAttribute(string trademark)
		{
			this.m_trademark = trademark;
		}

		// Token: 0x17000A10 RID: 2576
		// (get) Token: 0x0600444F RID: 17487 RVA: 0x000FC2EA File Offset: 0x000FA4EA
		[__DynamicallyInvokable]
		public string Trademark
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_trademark;
			}
		}

		// Token: 0x04001BF7 RID: 7159
		private string m_trademark;
	}
}
