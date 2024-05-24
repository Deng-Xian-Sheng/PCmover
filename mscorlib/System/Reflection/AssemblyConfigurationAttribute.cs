using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005B9 RID: 1465
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyConfigurationAttribute : Attribute
	{
		// Token: 0x06004458 RID: 17496 RVA: 0x000FC34E File Offset: 0x000FA54E
		[__DynamicallyInvokable]
		public AssemblyConfigurationAttribute(string configuration)
		{
			this.m_configuration = configuration;
		}

		// Token: 0x17000A15 RID: 2581
		// (get) Token: 0x06004459 RID: 17497 RVA: 0x000FC35D File Offset: 0x000FA55D
		[__DynamicallyInvokable]
		public string Configuration
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_configuration;
			}
		}

		// Token: 0x04001BFC RID: 7164
		private string m_configuration;
	}
}
