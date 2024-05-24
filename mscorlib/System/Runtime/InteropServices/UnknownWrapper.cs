using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200095F RID: 2399
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class UnknownWrapper
	{
		// Token: 0x0600621A RID: 25114 RVA: 0x0014F657 File Offset: 0x0014D857
		[__DynamicallyInvokable]
		public UnknownWrapper(object obj)
		{
			this.m_WrappedObject = obj;
		}

		// Token: 0x17001114 RID: 4372
		// (get) Token: 0x0600621B RID: 25115 RVA: 0x0014F666 File Offset: 0x0014D866
		[__DynamicallyInvokable]
		public object WrappedObject
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_WrappedObject;
			}
		}

		// Token: 0x04002B88 RID: 11144
		private object m_WrappedObject;
	}
}
