using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005DF RID: 1503
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DefaultMemberAttribute : Attribute
	{
		// Token: 0x060045AD RID: 17837 RVA: 0x00101156 File Offset: 0x000FF356
		[__DynamicallyInvokable]
		public DefaultMemberAttribute(string memberName)
		{
			this.m_memberName = memberName;
		}

		// Token: 0x17000A5D RID: 2653
		// (get) Token: 0x060045AE RID: 17838 RVA: 0x00101165 File Offset: 0x000FF365
		[__DynamicallyInvokable]
		public string MemberName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_memberName;
			}
		}

		// Token: 0x04001C8C RID: 7308
		private string m_memberName;
	}
}
