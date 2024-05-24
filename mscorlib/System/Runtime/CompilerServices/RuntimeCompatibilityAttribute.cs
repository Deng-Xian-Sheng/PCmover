using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008E2 RID: 2274
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class RuntimeCompatibilityAttribute : Attribute
	{
		// Token: 0x06005DDB RID: 24027 RVA: 0x0014995D File Offset: 0x00147B5D
		[__DynamicallyInvokable]
		public RuntimeCompatibilityAttribute()
		{
		}

		// Token: 0x17001020 RID: 4128
		// (get) Token: 0x06005DDC RID: 24028 RVA: 0x00149965 File Offset: 0x00147B65
		// (set) Token: 0x06005DDD RID: 24029 RVA: 0x0014996D File Offset: 0x00147B6D
		[__DynamicallyInvokable]
		public bool WrapNonExceptionThrows
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_wrapNonExceptionThrows;
			}
			[__DynamicallyInvokable]
			set
			{
				this.m_wrapNonExceptionThrows = value;
			}
		}

		// Token: 0x04002A35 RID: 10805
		private bool m_wrapNonExceptionThrows;
	}
}
