using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000641 RID: 1601
	public abstract class AttributeType
	{
		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06003C1E RID: 15390
		public abstract AttributeOwner Owner { get; }

		// Token: 0x06003C1F RID: 15391 RVA: 0x001FE1A0 File Offset: 0x001FD1A0
		internal virtual void j(DocumentWriter A_0)
		{
			new GeneratorException("The method or operation is not implemented.");
		}

		// Token: 0x06003C20 RID: 15392
		internal abstract int i();
	}
}
