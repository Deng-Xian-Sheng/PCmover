using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005BA RID: 1466
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyDefaultAliasAttribute : Attribute
	{
		// Token: 0x0600445A RID: 17498 RVA: 0x000FC365 File Offset: 0x000FA565
		[__DynamicallyInvokable]
		public AssemblyDefaultAliasAttribute(string defaultAlias)
		{
			this.m_defaultAlias = defaultAlias;
		}

		// Token: 0x17000A16 RID: 2582
		// (get) Token: 0x0600445B RID: 17499 RVA: 0x000FC374 File Offset: 0x000FA574
		[__DynamicallyInvokable]
		public string DefaultAlias
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_defaultAlias;
			}
		}

		// Token: 0x04001BFD RID: 7165
		private string m_defaultAlias;
	}
}
