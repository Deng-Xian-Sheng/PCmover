using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005C5 RID: 1477
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyKeyNameAttribute : Attribute
	{
		// Token: 0x06004476 RID: 17526 RVA: 0x000FC4C3 File Offset: 0x000FA6C3
		[__DynamicallyInvokable]
		public AssemblyKeyNameAttribute(string keyName)
		{
			this.m_keyName = keyName;
		}

		// Token: 0x17000A24 RID: 2596
		// (get) Token: 0x06004477 RID: 17527 RVA: 0x000FC4D2 File Offset: 0x000FA6D2
		[__DynamicallyInvokable]
		public string KeyName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_keyName;
			}
		}

		// Token: 0x04001C0A RID: 7178
		private string m_keyName;
	}
}
