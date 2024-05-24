using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000960 RID: 2400
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class VariantWrapper
	{
		// Token: 0x0600621C RID: 25116 RVA: 0x0014F66E File Offset: 0x0014D86E
		[__DynamicallyInvokable]
		public VariantWrapper(object obj)
		{
			this.m_WrappedObject = obj;
		}

		// Token: 0x17001115 RID: 4373
		// (get) Token: 0x0600621D RID: 25117 RVA: 0x0014F67D File Offset: 0x0014D87D
		[__DynamicallyInvokable]
		public object WrappedObject
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_WrappedObject;
			}
		}

		// Token: 0x04002B89 RID: 11145
		private object m_WrappedObject;
	}
}
