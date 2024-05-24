using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005C6 RID: 1478
	internal class amx
	{
		// Token: 0x06003A85 RID: 14981 RVA: 0x001F5B14 File Offset: 0x001F4B14
		internal amx(LayoutWriter A_0, ReportFooter A_1)
		{
			this.a = new amj();
			if (A_1.a() != null)
			{
				A_1.a().a(this.a, A_0);
			}
			if (A_1.b() != null)
			{
				this.b = new amn(A_0, this.a, A_1.b());
			}
		}

		// Token: 0x06003A86 RID: 14982 RVA: 0x001F5B80 File Offset: 0x001F4B80
		internal void b(amp A_0, PageWriter A_1)
		{
			if (A_1.Document.Tag != null)
			{
				this.a(A_0, A_1);
			}
			else if (this.b != null && this.b.a() > 0)
			{
				int num = -1;
				amm amm = this.b.a(A_0, A_1, ref num);
				if (amm == null)
				{
					this.a.a(A_1);
				}
				else
				{
					amm.a(A_1);
				}
			}
			else
			{
				this.a.a(A_1);
			}
		}

		// Token: 0x06003A87 RID: 14983 RVA: 0x001F5C18 File Offset: 0x001F4C18
		private void a(amp A_0, PageWriter A_1)
		{
			if (this.b != null && this.b.a() > 0)
			{
				int a_ = -1;
				amm amm = this.b.a(A_0, A_1, ref a_);
				if (amm == null)
				{
					TagType a_2 = new NamedTagType(((amz)A_0).b().c().Footer.c(), TagType.Section);
					this.a(A_1, a_2);
					this.a.a(A_1);
				}
				else
				{
					TagType a_2 = new NamedTagType(((amz)A_0).b().c().Footer.b().a(a_).d(), TagType.Section);
					this.a(A_1, a_2);
					amm.a(A_1);
				}
			}
			else
			{
				TagType a_2 = new NamedTagType(((amz)A_0).b().c().Footer.c(), TagType.Section);
				this.a(A_1, a_2);
				this.a.a(A_1);
			}
			A_1.a(A_1.k().Parent);
		}

		// Token: 0x06003A88 RID: 14984 RVA: 0x001F5D3C File Offset: 0x001F4D3C
		private void a(PageWriter A_0, TagType A_1)
		{
			A_0.a(new StructureElement(A_1)
			{
				Order = 3,
				Parent = A_0.k()
			});
		}

		// Token: 0x04001BA6 RID: 7078
		private amj a;

		// Token: 0x04001BA7 RID: 7079
		private amn b;
	}
}
