using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005B7 RID: 1463
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyDescriptionAttribute : Attribute
	{
		// Token: 0x06004454 RID: 17492 RVA: 0x000FC320 File Offset: 0x000FA520
		[__DynamicallyInvokable]
		public AssemblyDescriptionAttribute(string description)
		{
			this.m_description = description;
		}

		// Token: 0x17000A13 RID: 2579
		// (get) Token: 0x06004455 RID: 17493 RVA: 0x000FC32F File Offset: 0x000FA52F
		[__DynamicallyInvokable]
		public string Description
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_description;
			}
		}

		// Token: 0x04001BFA RID: 7162
		private string m_description;
	}
}
