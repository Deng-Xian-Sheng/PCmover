using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005BF RID: 1471
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyKeyFileAttribute : Attribute
	{
		// Token: 0x06004464 RID: 17508 RVA: 0x000FC3E6 File Offset: 0x000FA5E6
		[__DynamicallyInvokable]
		public AssemblyKeyFileAttribute(string keyFile)
		{
			this.m_keyFile = keyFile;
		}

		// Token: 0x17000A1B RID: 2587
		// (get) Token: 0x06004465 RID: 17509 RVA: 0x000FC3F5 File Offset: 0x000FA5F5
		[__DynamicallyInvokable]
		public string KeyFile
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_keyFile;
			}
		}

		// Token: 0x04001C02 RID: 7170
		private string m_keyFile;
	}
}
