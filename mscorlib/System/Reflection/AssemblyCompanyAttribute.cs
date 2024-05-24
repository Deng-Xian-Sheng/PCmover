using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005B6 RID: 1462
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyCompanyAttribute : Attribute
	{
		// Token: 0x06004452 RID: 17490 RVA: 0x000FC309 File Offset: 0x000FA509
		[__DynamicallyInvokable]
		public AssemblyCompanyAttribute(string company)
		{
			this.m_company = company;
		}

		// Token: 0x17000A12 RID: 2578
		// (get) Token: 0x06004453 RID: 17491 RVA: 0x000FC318 File Offset: 0x000FA518
		[__DynamicallyInvokable]
		public string Company
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_company;
			}
		}

		// Token: 0x04001BF9 RID: 7161
		private string m_company;
	}
}
