using System;

namespace System.Runtime.Serialization
{
	// Token: 0x02000759 RID: 1881
	[Serializable]
	internal class SurrogateKey
	{
		// Token: 0x060052EB RID: 21227 RVA: 0x001239AD File Offset: 0x00121BAD
		internal SurrogateKey(Type type, StreamingContext context)
		{
			this.m_type = type;
			this.m_context = context;
		}

		// Token: 0x060052EC RID: 21228 RVA: 0x001239C3 File Offset: 0x00121BC3
		public override int GetHashCode()
		{
			return this.m_type.GetHashCode();
		}

		// Token: 0x040024C0 RID: 9408
		internal Type m_type;

		// Token: 0x040024C1 RID: 9409
		internal StreamingContext m_context;
	}
}
