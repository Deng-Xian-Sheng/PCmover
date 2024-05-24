using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000425 RID: 1061
	internal class abn : Resource
	{
		// Token: 0x06002C33 RID: 11315 RVA: 0x0019611B File Offset: 0x0019511B
		internal abn(abd A_0) : this(A_0, ResourceType.Default)
		{
		}

		// Token: 0x06002C34 RID: 11316 RVA: 0x00196129 File Offset: 0x00195129
		internal abn(abd A_0, ResourceType A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06002C35 RID: 11317 RVA: 0x0019614A File Offset: 0x0019514A
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			this.a.hz(writer);
			writer.WriteEndObject();
		}

		// Token: 0x06002C36 RID: 11318 RVA: 0x00196168 File Offset: 0x00195168
		public override int get_RequiredPdfObjects()
		{
			return 1;
		}

		// Token: 0x06002C37 RID: 11319 RVA: 0x0019617C File Offset: 0x0019517C
		public override ResourceType get_ResourceType()
		{
			return this.b;
		}

		// Token: 0x06002C38 RID: 11320 RVA: 0x00196194 File Offset: 0x00195194
		internal new abd a()
		{
			return this.a;
		}

		// Token: 0x040014D2 RID: 5330
		private new abd a;

		// Token: 0x040014D3 RID: 5331
		private new ResourceType b = ResourceType.Default;
	}
}
