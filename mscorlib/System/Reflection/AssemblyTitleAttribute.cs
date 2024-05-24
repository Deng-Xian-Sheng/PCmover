using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005B8 RID: 1464
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyTitleAttribute : Attribute
	{
		// Token: 0x06004456 RID: 17494 RVA: 0x000FC337 File Offset: 0x000FA537
		[__DynamicallyInvokable]
		public AssemblyTitleAttribute(string title)
		{
			this.m_title = title;
		}

		// Token: 0x17000A14 RID: 2580
		// (get) Token: 0x06004457 RID: 17495 RVA: 0x000FC346 File Offset: 0x000FA546
		[__DynamicallyInvokable]
		public string Title
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_title;
			}
		}

		// Token: 0x04001BFB RID: 7163
		private string m_title;
	}
}
