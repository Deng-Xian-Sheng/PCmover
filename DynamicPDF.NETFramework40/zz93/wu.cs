using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000367 RID: 871
	internal class wu : LayoutWriter
	{
		// Token: 0x0600253B RID: 9531 RVA: 0x0015CE92 File Offset: 0x0015BE92
		internal wu(Document A_0, DocumentLayout A_1, ParameterDictionary A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x0600253C RID: 9532 RVA: 0x0015CED0 File Offset: 0x0015BED0
		internal override void e0()
		{
			RecordSet recordSet;
			if (this.b.a() != null)
			{
				recordSet = this.b.a().e(this);
				this.d.a(recordSet);
			}
			else
			{
				recordSet = null;
			}
			DocumentLayoutPartList layoutParts = this.b.LayoutParts;
			if (layoutParts.a())
			{
				this.f = new tm();
				this.e = new tl(layoutParts);
			}
			if (recordSet != null)
			{
				recordSet.Query.e().a(this);
			}
			for (int i = 0; i < layoutParts.Count; i++)
			{
				layoutParts[i].ew(this);
			}
			for (int i = 0; i < layoutParts.Count; i++)
			{
				sz sz = ((rm)layoutParts[i]).a();
				if (sz != null && sz.b() > 0)
				{
					sz.c(this);
				}
			}
			for (int i = 0; i < layoutParts.Count; i++)
			{
				if (layoutParts[i] is FixedPage)
				{
					FixedPage fixedPage = (FixedPage)layoutParts[i];
					if (fixedPage.h() != null)
					{
						fixedPage.h().a(this, false);
					}
				}
			}
			if (recordSet != null)
			{
				recordSet.eb();
			}
		}

		// Token: 0x0600253D RID: 9533 RVA: 0x0015D054 File Offset: 0x0015C054
		internal override tl e1()
		{
			return this.e;
		}

		// Token: 0x0600253E RID: 9534 RVA: 0x0015D06C File Offset: 0x0015C06C
		internal override tm e2()
		{
			return this.f;
		}

		// Token: 0x0600253F RID: 9535 RVA: 0x0015D084 File Offset: 0x0015C084
		internal DateTime a()
		{
			return this.g;
		}

		// Token: 0x06002540 RID: 9536 RVA: 0x0015D09C File Offset: 0x0015C09C
		public override RecordSetStack get_RecordSets()
		{
			return this.d;
		}

		// Token: 0x06002541 RID: 9537 RVA: 0x0015D0B4 File Offset: 0x0015C0B4
		public override Document get_Document()
		{
			return this.a;
		}

		// Token: 0x06002542 RID: 9538 RVA: 0x0015D0CC File Offset: 0x0015C0CC
		public override ParameterDictionary get_Parameters()
		{
			return this.c;
		}

		// Token: 0x06002543 RID: 9539 RVA: 0x0015D0E4 File Offset: 0x0015C0E4
		public override DocumentLayout get_DocumentLayout()
		{
			return this.b;
		}

		// Token: 0x06002544 RID: 9540 RVA: 0x0015D0FC File Offset: 0x0015C0FC
		internal override AlternateRow e4()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06002545 RID: 9541 RVA: 0x0015D109 File Offset: 0x0015C109
		internal override void e5(AlternateRow A_0)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06002546 RID: 9542 RVA: 0x0015D116 File Offset: 0x0015C116
		internal override void e3()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06002547 RID: 9543 RVA: 0x0015D123 File Offset: 0x0015C123
		internal override float e6()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06002548 RID: 9544 RVA: 0x0015D130 File Offset: 0x0015C130
		internal override xv e7()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06002549 RID: 9545 RVA: 0x0015D140 File Offset: 0x0015C140
		internal override wu ez()
		{
			return this;
		}

		// Token: 0x0600254A RID: 9546 RVA: 0x0015D154 File Offset: 0x0015C154
		internal int b()
		{
			return this.h;
		}

		// Token: 0x0600254B RID: 9547 RVA: 0x0015D16C File Offset: 0x0015C16C
		internal void a(int A_0)
		{
			this.h = A_0;
		}

		// Token: 0x04001052 RID: 4178
		private Document a;

		// Token: 0x04001053 RID: 4179
		private DocumentLayout b;

		// Token: 0x04001054 RID: 4180
		private ParameterDictionary c;

		// Token: 0x04001055 RID: 4181
		private RecordSetStack d = new RecordSetStack();

		// Token: 0x04001056 RID: 4182
		private tl e;

		// Token: 0x04001057 RID: 4183
		private tm f;

		// Token: 0x04001058 RID: 4184
		private DateTime g = DateTime.Now;

		// Token: 0x04001059 RID: 4185
		private int h = -1;
	}
}
