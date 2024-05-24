using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000388 RID: 904
	internal class xo
	{
		// Token: 0x060026A6 RID: 9894 RVA: 0x00164CF0 File Offset: 0x00163CF0
		internal xo(LayoutWriter A_0, ReportFooter A_1)
		{
			this.a = new xf();
			if (A_1.a() != null)
			{
				A_1.a().a(this.a, A_0);
			}
			if (A_1.b() != null)
			{
				this.b = new xj(A_0, this.a, A_1.b());
			}
		}

		// Token: 0x060026A7 RID: 9895 RVA: 0x00164D5C File Offset: 0x00163D5C
		internal void b(rs A_0, PageWriter A_1)
		{
			if (A_1.Document.Tag != null)
			{
				this.a(A_0, A_1);
			}
			else if (this.b != null && this.b.a() > 0)
			{
				int num = -1;
				xi xi = this.b.a(A_0, A_1, ref num);
				if (xi == null)
				{
					this.a.a(A_1);
				}
				else
				{
					xi.a(A_1);
				}
			}
			else
			{
				this.a.a(A_1);
			}
		}

		// Token: 0x060026A8 RID: 9896 RVA: 0x00164DF4 File Offset: 0x00163DF4
		private void a(rs A_0, PageWriter A_1)
		{
			if (this.b != null && this.b.a() > 0)
			{
				int a_ = -1;
				xi xi = this.b.a(A_0, A_1, ref a_);
				if (xi == null)
				{
					TagType a_2 = new NamedTagType(((xq)A_0).b().c().Footer.c(), TagType.Section);
					this.a(A_1, a_2);
					this.a.a(A_1);
				}
				else
				{
					TagType a_2 = new NamedTagType(((xq)A_0).b().c().Footer.b().a(a_).d(), TagType.Section);
					this.a(A_1, a_2);
					xi.a(A_1);
				}
			}
			else
			{
				TagType a_2 = new NamedTagType(((xq)A_0).b().c().Footer.c(), TagType.Section);
				this.a(A_1, a_2);
				this.a.a(A_1);
			}
			A_1.a(A_1.k().Parent);
		}

		// Token: 0x060026A9 RID: 9897 RVA: 0x00164F18 File Offset: 0x00163F18
		private void a(PageWriter A_0, TagType A_1)
		{
			A_0.a(new StructureElement(A_1)
			{
				Order = 3,
				Parent = A_0.k()
			});
		}

		// Token: 0x040010CD RID: 4301
		private xf a;

		// Token: 0x040010CE RID: 4302
		private xj b;
	}
}
