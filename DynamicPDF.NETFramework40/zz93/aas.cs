using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000404 RID: 1028
	internal class aas : Resource
	{
		// Token: 0x06002B11 RID: 11025 RVA: 0x0018EA90 File Offset: 0x0018DA90
		internal aas(acb A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002B12 RID: 11026 RVA: 0x0018EAB7 File Offset: 0x0018DAB7
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			this.a.a(writer);
			writer.WriteEndObject();
		}

		// Token: 0x06002B13 RID: 11027 RVA: 0x0018EAD8 File Offset: 0x0018DAD8
		internal override int b()
		{
			return this.b;
		}

		// Token: 0x06002B14 RID: 11028 RVA: 0x0018EAF0 File Offset: 0x0018DAF0
		internal override void c(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002B15 RID: 11029 RVA: 0x0018EAFC File Offset: 0x0018DAFC
		internal override bool d()
		{
			return this.d;
		}

		// Token: 0x06002B16 RID: 11030 RVA: 0x0018EB14 File Offset: 0x0018DB14
		internal new StructureElement a()
		{
			return this.c;
		}

		// Token: 0x06002B17 RID: 11031 RVA: 0x0018EB2C File Offset: 0x0018DB2C
		internal new void a(StructureElement A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06002B18 RID: 11032 RVA: 0x0018EB36 File Offset: 0x0018DB36
		internal new void a(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06002B19 RID: 11033 RVA: 0x0018EB40 File Offset: 0x0018DB40
		internal override bool hn()
		{
			return this.a.d();
		}

		// Token: 0x040013CB RID: 5067
		private new acb a;

		// Token: 0x040013CC RID: 5068
		private new int b = -1;

		// Token: 0x040013CD RID: 5069
		private new StructureElement c = null;

		// Token: 0x040013CE RID: 5070
		private new bool d = false;
	}
}
