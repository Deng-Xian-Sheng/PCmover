using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005CE RID: 1486
	internal class am5
	{
		// Token: 0x06003AD9 RID: 15065 RVA: 0x001F9614 File Offset: 0x001F8614
		internal am5(LayoutWriter A_0, ang A_1)
		{
			this.a = A_1;
			this.b = new amj();
			if (A_1.a() != null)
			{
				A_1.a().a(this.b, A_0);
			}
			if (A_1.b() != null)
			{
				this.c = new amn(A_0, this.b, A_1.b());
			}
		}

		// Token: 0x06003ADA RID: 15066 RVA: 0x001F968C File Offset: 0x001F868C
		internal void b(amp A_0, PageWriter A_1)
		{
			if (A_1.Document.Tag != null)
			{
				this.a(A_0, A_1);
			}
			else if (this.c != null && this.c.a() > 0)
			{
				int num = -1;
				amm amm = this.c.a(A_0, A_1, ref num);
				if (amm == null)
				{
					this.b.a(A_1);
				}
				else
				{
					amm.a(A_1);
				}
			}
			else
			{
				this.b.a(A_1);
			}
		}

		// Token: 0x06003ADB RID: 15067 RVA: 0x001F9724 File Offset: 0x001F8724
		private void a(amp A_0, PageWriter A_1)
		{
			if (this.c != null && this.c.a() > 0)
			{
				int a_ = -1;
				amm amm = this.c.a(A_0, A_1, ref a_);
				if (amm == null)
				{
					TagType a_2 = new NamedTagType(this.a.c(), TagType.Section);
					A_1.k().a(a_2);
					this.b.a(A_1);
				}
				else
				{
					TagType a_2 = new NamedTagType(this.a.b().a(a_).d(), TagType.Section);
					A_1.k().a(a_2);
					amm.a(A_1);
				}
			}
			else
			{
				TagType a_2 = new NamedTagType(this.a.c(), TagType.Section);
				A_1.k().a(a_2);
				this.b.a(A_1);
			}
		}

		// Token: 0x06003ADC RID: 15068 RVA: 0x001F9818 File Offset: 0x001F8818
		internal ang a()
		{
			return this.a;
		}

		// Token: 0x06003ADD RID: 15069 RVA: 0x001F9830 File Offset: 0x001F8830
		internal amn b()
		{
			return this.c;
		}

		// Token: 0x04001BC7 RID: 7111
		private ang a;

		// Token: 0x04001BC8 RID: 7112
		private amj b;

		// Token: 0x04001BC9 RID: 7113
		private amn c = null;
	}
}
