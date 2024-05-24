using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200038F RID: 911
	internal class xv
	{
		// Token: 0x060026F2 RID: 9970 RVA: 0x00168994 File Offset: 0x00167994
		internal xv(LayoutWriter A_0, x3 A_1)
		{
			this.a = A_1;
			this.b = new xf();
			if (A_1.a() != null)
			{
				A_1.a().a(this.b, A_0);
			}
			if (A_1.b() != null)
			{
				this.c = new xj(A_0, this.b, A_1.b());
			}
		}

		// Token: 0x060026F3 RID: 9971 RVA: 0x00168A0C File Offset: 0x00167A0C
		internal void b(rs A_0, PageWriter A_1)
		{
			if (A_1.Document.Tag != null)
			{
				this.a(A_0, A_1);
			}
			else if (this.c != null && this.c.a() > 0)
			{
				int num = -1;
				xi xi = this.c.a(A_0, A_1, ref num);
				if (xi == null)
				{
					this.b.a(A_1);
				}
				else
				{
					xi.a(A_1);
				}
			}
			else
			{
				this.b.a(A_1);
			}
		}

		// Token: 0x060026F4 RID: 9972 RVA: 0x00168AA4 File Offset: 0x00167AA4
		private void a(rs A_0, PageWriter A_1)
		{
			if (this.c != null && this.c.a() > 0)
			{
				int a_ = -1;
				xi xi = this.c.a(A_0, A_1, ref a_);
				if (xi == null)
				{
					TagType a_2 = new NamedTagType(this.a.c(), TagType.Section);
					A_1.k().a(a_2);
					this.b.a(A_1);
				}
				else
				{
					TagType a_2 = new NamedTagType(this.a.b().a(a_).d(), TagType.Section);
					A_1.k().a(a_2);
					xi.a(A_1);
				}
			}
			else
			{
				TagType a_2 = new NamedTagType(this.a.c(), TagType.Section);
				A_1.k().a(a_2);
				this.b.a(A_1);
			}
		}

		// Token: 0x060026F5 RID: 9973 RVA: 0x00168B98 File Offset: 0x00167B98
		internal x3 a()
		{
			return this.a;
		}

		// Token: 0x060026F6 RID: 9974 RVA: 0x00168BB0 File Offset: 0x00167BB0
		internal xj b()
		{
			return this.c;
		}

		// Token: 0x040010EB RID: 4331
		private x3 a;

		// Token: 0x040010EC RID: 4332
		private xf b;

		// Token: 0x040010ED RID: 4333
		private xj c = null;
	}
}
