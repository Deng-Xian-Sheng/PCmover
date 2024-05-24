using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002D6 RID: 726
	internal abstract class sy : q7
	{
		// Token: 0x060020B5 RID: 8373 RVA: 0x001412C6 File Offset: 0x001402C6
		internal sy()
		{
		}

		// Token: 0x060020B6 RID: 8374 RVA: 0x001412F0 File Offset: 0x001402F0
		internal void a(w5 A_0)
		{
			if (A_0.c() == ',')
			{
				A_0.a(A_0.e() + 1);
				this.b = A_0.l();
				if (A_0.c() == ',')
				{
					A_0.a(A_0.e() + 1);
					this.a = A_0.l();
					if (A_0.c() == ',')
					{
						A_0.a(A_0.e() + 1);
						this.c = A_0.l();
					}
				}
				else
				{
					this.a = A_0.b();
				}
			}
			else
			{
				this.b = A_0.a();
				this.a = A_0.b();
			}
		}

		// Token: 0x060020B7 RID: 8375
		internal abstract s1 fn();

		// Token: 0x060020B8 RID: 8376 RVA: 0x001413B8 File Offset: 0x001403B8
		internal string a()
		{
			return this.a;
		}

		// Token: 0x060020B9 RID: 8377 RVA: 0x001413D0 File Offset: 0x001403D0
		internal string b()
		{
			return this.b;
		}

		// Token: 0x060020BA RID: 8378 RVA: 0x001413E8 File Offset: 0x001403E8
		internal string c()
		{
			return this.c;
		}

		// Token: 0x060020BB RID: 8379 RVA: 0x00141400 File Offset: 0x00140400
		internal bool d()
		{
			return this.d;
		}

		// Token: 0x060020BC RID: 8380 RVA: 0x00141418 File Offset: 0x00140418
		internal void a(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060020BD RID: 8381 RVA: 0x00141424 File Offset: 0x00140424
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return false;
		}

		// Token: 0x060020BE RID: 8382 RVA: 0x00141438 File Offset: 0x00140438
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			return q7.a(this.et(A_0, A_1));
		}

		// Token: 0x060020BF RID: 8383 RVA: 0x00141458 File Offset: 0x00140458
		internal override DateTime eh(LayoutWriter A_0, vi A_1)
		{
			return q7.b(this.et(A_0, A_1));
		}

		// Token: 0x060020C0 RID: 8384 RVA: 0x00141478 File Offset: 0x00140478
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return q7.e(this.et(A_0, A_1));
		}

		// Token: 0x060020C1 RID: 8385 RVA: 0x00141498 File Offset: 0x00140498
		internal override double el(LayoutWriter A_0, vi A_1)
		{
			return q7.d(this.et(A_0, A_1));
		}

		// Token: 0x060020C2 RID: 8386 RVA: 0x001414B8 File Offset: 0x001404B8
		internal override int en(LayoutWriter A_0, vi A_1)
		{
			return q7.c(this.et(A_0, A_1));
		}

		// Token: 0x060020C3 RID: 8387 RVA: 0x001414D8 File Offset: 0x001404D8
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			object result;
			if (string.Compare(this.b, "CurrentPage", true) == 0 || string.Compare(this.b, "PreviousPage", true) == 0)
			{
				result = A_0.e1().a(this).a().c();
			}
			else
			{
				result = A_0.e1().a(this).a().b();
			}
			return result;
		}

		// Token: 0x060020C4 RID: 8388 RVA: 0x00141550 File Offset: 0x00140550
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			return this.et(A_0, A_1).ToString();
		}

		// Token: 0x060020C5 RID: 8389 RVA: 0x0014156F File Offset: 0x0014056F
		internal override bool eq(LayoutWriter A_0)
		{
			throw new ReportWriterException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x060020C6 RID: 8390 RVA: 0x0014157C File Offset: 0x0014057C
		internal override bool ee(LayoutWriter A_0)
		{
			throw new ReportWriterException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x060020C7 RID: 8391 RVA: 0x00141589 File Offset: 0x00140589
		internal override DateTime eg(LayoutWriter A_0)
		{
			throw new ReportWriterException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x060020C8 RID: 8392 RVA: 0x00141596 File Offset: 0x00140596
		internal override decimal ei(LayoutWriter A_0)
		{
			throw new ReportWriterException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x060020C9 RID: 8393 RVA: 0x001415A3 File Offset: 0x001405A3
		internal override double ek(LayoutWriter A_0)
		{
			throw new ReportWriterException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x060020CA RID: 8394 RVA: 0x001415B0 File Offset: 0x001405B0
		internal override int em(LayoutWriter A_0)
		{
			throw new ReportWriterException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x060020CB RID: 8395 RVA: 0x001415BD File Offset: 0x001405BD
		internal override object es(LayoutWriter A_0)
		{
			throw new ReportWriterException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x060020CC RID: 8396 RVA: 0x001415CA File Offset: 0x001405CA
		internal override string eo(LayoutWriter A_0)
		{
			throw new ReportWriterException("An aggregate function cannot be used in this context.");
		}

		// Token: 0x060020CD RID: 8397 RVA: 0x001415D7 File Offset: 0x001405D7
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			A_0.e1().a(this).a().a();
		}

		// Token: 0x04000E5D RID: 3677
		private new string a = null;

		// Token: 0x04000E5E RID: 3678
		private new string b = null;

		// Token: 0x04000E5F RID: 3679
		private new string c = null;

		// Token: 0x04000E60 RID: 3680
		private new bool d = false;
	}
}
