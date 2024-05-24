using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005BD RID: 1469
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyCultureAttribute : Attribute
	{
		// Token: 0x06004460 RID: 17504 RVA: 0x000FC3B8 File Offset: 0x000FA5B8
		[__DynamicallyInvokable]
		public AssemblyCultureAttribute(string culture)
		{
			this.m_culture = culture;
		}

		// Token: 0x17000A19 RID: 2585
		// (get) Token: 0x06004461 RID: 17505 RVA: 0x000FC3C7 File Offset: 0x000FA5C7
		[__DynamicallyInvokable]
		public string Culture
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_culture;
			}
		}

		// Token: 0x04001C00 RID: 7168
		private string m_culture;
	}
}
