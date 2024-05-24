using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000389 RID: 905
	internal class xp
	{
		// Token: 0x060026AA RID: 9898 RVA: 0x00164F4C File Offset: 0x00163F4C
		internal xp(LayoutWriter A_0, ReportHeader A_1)
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

		// Token: 0x060026AB RID: 9899 RVA: 0x00164FB8 File Offset: 0x00163FB8
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

		// Token: 0x060026AC RID: 9900 RVA: 0x00165050 File Offset: 0x00164050
		private void a(rs A_0, PageWriter A_1)
		{
			if (this.b != null && this.b.a() > 0)
			{
				int a_ = -1;
				xi xi = this.b.a(A_0, A_1, ref a_);
				if (xi == null)
				{
					TagType a_2 = new NamedTagType(((xq)A_0).b().c().Header.c(), TagType.Section);
					this.a(A_1, a_2);
					this.a.a(A_1);
				}
				else
				{
					TagType a_2 = new NamedTagType(((xq)A_0).b().c().Header.b().a(a_).d(), TagType.Section);
					this.a(A_1, a_2);
					xi.a(A_1);
				}
			}
			else
			{
				TagType a_2 = new NamedTagType(((xq)A_0).b().c().Header.c(), TagType.Section);
				this.a(A_1, a_2);
				this.a.a(A_1);
			}
			A_1.a(A_1.k().Parent);
		}

		// Token: 0x060026AD RID: 9901 RVA: 0x00165174 File Offset: 0x00164174
		private void a(PageWriter A_0, TagType A_1)
		{
			A_0.a(new StructureElement(A_1)
			{
				Order = 1,
				Parent = A_0.k()
			});
		}

		// Token: 0x040010CF RID: 4303
		private xf a;

		// Token: 0x040010D0 RID: 4304
		private xj b;
	}
}
