using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	// Token: 0x02000743 RID: 1859
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public struct StreamingContext
	{
		// Token: 0x06005229 RID: 21033 RVA: 0x00120B7E File Offset: 0x0011ED7E
		public StreamingContext(StreamingContextStates state)
		{
			this = new StreamingContext(state, null);
		}

		// Token: 0x0600522A RID: 21034 RVA: 0x00120B88 File Offset: 0x0011ED88
		public StreamingContext(StreamingContextStates state, object additional)
		{
			this.m_state = state;
			this.m_additionalContext = additional;
		}

		// Token: 0x17000D8F RID: 3471
		// (get) Token: 0x0600522B RID: 21035 RVA: 0x00120B98 File Offset: 0x0011ED98
		public object Context
		{
			get
			{
				return this.m_additionalContext;
			}
		}

		// Token: 0x0600522C RID: 21036 RVA: 0x00120BA0 File Offset: 0x0011EDA0
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return obj is StreamingContext && (((StreamingContext)obj).m_additionalContext == this.m_additionalContext && ((StreamingContext)obj).m_state == this.m_state);
		}

		// Token: 0x0600522D RID: 21037 RVA: 0x00120BD5 File Offset: 0x0011EDD5
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return (int)this.m_state;
		}

		// Token: 0x17000D90 RID: 3472
		// (get) Token: 0x0600522E RID: 21038 RVA: 0x00120BDD File Offset: 0x0011EDDD
		public StreamingContextStates State
		{
			get
			{
				return this.m_state;
			}
		}

		// Token: 0x0400245A RID: 9306
		internal object m_additionalContext;

		// Token: 0x0400245B RID: 9307
		internal StreamingContextStates m_state;
	}
}
