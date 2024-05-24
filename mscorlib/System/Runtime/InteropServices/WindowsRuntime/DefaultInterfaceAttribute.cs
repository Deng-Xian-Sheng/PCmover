using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009C5 RID: 2501
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class DefaultInterfaceAttribute : Attribute
	{
		// Token: 0x060063B9 RID: 25529 RVA: 0x001547C9 File Offset: 0x001529C9
		[__DynamicallyInvokable]
		public DefaultInterfaceAttribute(Type defaultInterface)
		{
			this.m_defaultInterface = defaultInterface;
		}

		// Token: 0x17001139 RID: 4409
		// (get) Token: 0x060063BA RID: 25530 RVA: 0x001547D8 File Offset: 0x001529D8
		[__DynamicallyInvokable]
		public Type DefaultInterface
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_defaultInterface;
			}
		}

		// Token: 0x04002CD3 RID: 11475
		private Type m_defaultInterface;
	}
}
