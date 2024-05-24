using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005BB RID: 1467
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyInformationalVersionAttribute : Attribute
	{
		// Token: 0x0600445C RID: 17500 RVA: 0x000FC37C File Offset: 0x000FA57C
		[__DynamicallyInvokable]
		public AssemblyInformationalVersionAttribute(string informationalVersion)
		{
			this.m_informationalVersion = informationalVersion;
		}

		// Token: 0x17000A17 RID: 2583
		// (get) Token: 0x0600445D RID: 17501 RVA: 0x000FC38B File Offset: 0x000FA58B
		[__DynamicallyInvokable]
		public string InformationalVersion
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_informationalVersion;
			}
		}

		// Token: 0x04001BFE RID: 7166
		private string m_informationalVersion;
	}
}
