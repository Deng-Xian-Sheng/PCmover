using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005BE RID: 1470
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyVersionAttribute : Attribute
	{
		// Token: 0x06004462 RID: 17506 RVA: 0x000FC3CF File Offset: 0x000FA5CF
		[__DynamicallyInvokable]
		public AssemblyVersionAttribute(string version)
		{
			this.m_version = version;
		}

		// Token: 0x17000A1A RID: 2586
		// (get) Token: 0x06004463 RID: 17507 RVA: 0x000FC3DE File Offset: 0x000FA5DE
		[__DynamicallyInvokable]
		public string Version
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_version;
			}
		}

		// Token: 0x04001C01 RID: 7169
		private string m_version;
	}
}
