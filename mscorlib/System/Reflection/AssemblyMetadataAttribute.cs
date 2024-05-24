using System;

namespace System.Reflection
{
	// Token: 0x020005C3 RID: 1475
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class AssemblyMetadataAttribute : Attribute
	{
		// Token: 0x06004470 RID: 17520 RVA: 0x000FC477 File Offset: 0x000FA677
		[__DynamicallyInvokable]
		public AssemblyMetadataAttribute(string key, string value)
		{
			this.m_key = key;
			this.m_value = value;
		}

		// Token: 0x17000A20 RID: 2592
		// (get) Token: 0x06004471 RID: 17521 RVA: 0x000FC48D File Offset: 0x000FA68D
		[__DynamicallyInvokable]
		public string Key
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_key;
			}
		}

		// Token: 0x17000A21 RID: 2593
		// (get) Token: 0x06004472 RID: 17522 RVA: 0x000FC495 File Offset: 0x000FA695
		[__DynamicallyInvokable]
		public string Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_value;
			}
		}

		// Token: 0x04001C06 RID: 7174
		private string m_key;

		// Token: 0x04001C07 RID: 7175
		private string m_value;
	}
}
