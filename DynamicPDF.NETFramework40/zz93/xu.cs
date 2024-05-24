using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200038E RID: 910
	internal class xu
	{
		// Token: 0x060026EF RID: 9967 RVA: 0x00168790 File Offset: 0x00167790
		internal xu(LayoutWriter A_0, SubReportHeader A_1)
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

		// Token: 0x060026F0 RID: 9968 RVA: 0x00168810 File Offset: 0x00167810
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
						TagType a_2 = new NamedTagType(A_0.f().Header.c(), TagType.Section);
						this.a(A_1, a_2);
					}
					this.a.a(A_1);
				}
				else
				{
					if (A_1.Document.Tag != null)
					{
						TagType a_2 = new NamedTagType(A_0.f().Header.b().a(a_).d(), TagType.Section);
						this.a(A_1, a_2);
					}
					xi.a(A_1);
				}
			}
			else
			{
				if (A_1.Document.Tag != null)
				{
					TagType a_2 = new NamedTagType(A_0.f().Header.c(), TagType.Section);
					this.a(A_1, a_2);
				}
				this.a.a(A_1);
			}
			if (A_1.Document.Tag != null)
			{
				A_1.a(A_1.k().Parent);
			}
		}

		// Token: 0x060026F1 RID: 9969 RVA: 0x00168968 File Offset: 0x00167968
		private void a(PageWriter A_0, TagType A_1)
		{
			A_0.a(new StructureElement(A_1)
			{
				Parent = A_0.k()
			});
		}

		// Token: 0x040010E9 RID: 4329
		private xh a;

		// Token: 0x040010EA RID: 4330
		private xj b = null;
	}
}
