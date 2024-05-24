using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005C0 RID: 1472
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyDelaySignAttribute : Attribute
	{
		// Token: 0x06004466 RID: 17510 RVA: 0x000FC3FD File Offset: 0x000FA5FD
		[__DynamicallyInvokable]
		public AssemblyDelaySignAttribute(bool delaySign)
		{
			this.m_delaySign = delaySign;
		}

		// Token: 0x17000A1C RID: 2588
		// (get) Token: 0x06004467 RID: 17511 RVA: 0x000FC40C File Offset: 0x000FA60C
		[__DynamicallyInvokable]
		public bool DelaySign
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_delaySign;
			}
		}

		// Token: 0x04001C03 RID: 7171
		private bool m_delaySign;
	}
}
