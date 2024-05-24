using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200038D RID: 909
	internal class xt
	{
		// Token: 0x060026EC RID: 9964 RVA: 0x0016858C File Offset: 0x0016758C
		internal xt(LayoutWriter A_0, SubReportFooter A_1)
		{
			this.a = new xh(x5.a(A_1.Height));
			if (A_1.a() != null)
			{
				A_1.a().a(this.a, A_0);
			}
			if (A_1.b() != null)
			{
				this.b = new xj(A_0, this.a, A_1.b());
			}
		}

		// Token: 0x060026ED RID: 9965 RVA: 0x0016860C File Offset: 0x0016760C
		internal void a(xs A_0, PageWriter A_1)
		{
			if (this.b != null && this.b.a() > 0)
			{
				int a_ = -1;
				xi xi = this.b.a(A_0, A_1, ref a_);
				if (xi == null)
				{
					if (A_1.Document.Tag != null)
					{
						TagType a_2 = new NamedTagType(A_0.f().Footer.c(), TagType.Section);
						this.a(A_1, a_2);
					}
					this.a.a(A_1);
				}
				else
				{
					if (A_1.Document.Tag != null)
					{
						TagType a_2 = new NamedTagType(A_0.f().Footer.b().a(a_).d(), TagType.Section);
						this.a(A_1, a_2);
					}
					xi.a(A_1);
				}
			}
			else
			{
				if (A_1.Document.Tag != null)
				{
					TagType a_2 = new NamedTagType(A_0.f().Footer.c(), TagType.Section);
					this.a(A_1, a_2);
				}
				this.a.a(A_1);
			}
			if (A_1.Document.Tag != null)
			{
				A_1.a(A_1.k().Parent);
			}
		}

		// Token: 0x060026EE RID: 9966 RVA: 0x00168764 File Offset: 0x00167764
		private void a(PageWriter A_0, TagType A_1)
		{
			A_0.a(new StructureElement(A_1)
			{
				Parent = A_0.k()
			});
		}

		// Token: 0x040010E7 RID: 4327
		private xh a;

		// Token: 0x040010E8 RID: 4328
		private xj b = null;
	}
}
