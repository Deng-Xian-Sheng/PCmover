using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005C7 RID: 1479
	internal class amy
	{
		// Token: 0x06003A89 RID: 14985 RVA: 0x001F5D70 File Offset: 0x001F4D70
		internal amy(LayoutWriter A_0, ReportHeader A_1)
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

		// Token: 0x06003A8A RID: 14986 RVA: 0x001F5DDC File Offset: 0x001F4DDC
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

		// Token: 0x06003A8B RID: 14987 RVA: 0x001F5E74 File Offset: 0x001F4E74
		private void a(amp A_0, PageWriter A_1)
		{
			if (this.b != null && this.b.a() > 0)
			{
				int a_ = -1;
				amm amm = this.b.a(A_0, A_1, ref a_);
				if (amm == null)
				{
					TagType a_2 = new NamedTagType(((amz)A_0).b().c().Header.c(), TagType.Section);
					this.a(A_1, a_2);
					this.a.a(A_1);
				}
				else
				{
					TagType a_2 = new NamedTagType(((amz)A_0).b().c().Header.b().a(a_).d(), TagType.Section);
					this.a(A_1, a_2);
					amm.a(A_1);
				}
			}
			else
			{
				TagType a_2 = new NamedTagType(((amz)A_0).b().c().Header.c(), TagType.Section);
				this.a(A_1, a_2);
				this.a.a(A_1);
			}
			A_1.a(A_1.k().Parent);
		}

		// Token: 0x06003A8C RID: 14988 RVA: 0x001F5F98 File Offset: 0x001F4F98
		private void a(PageWriter A_0, TagType A_1)
		{
			A_0.a(new StructureElement(A_1)
			{
				Order = 1,
				Parent = A_0.k()
			});
		}

		// Token: 0x04001BA8 RID: 7080
		private amj a;

		// Token: 0x04001BA9 RID: 7081
		private amn b;
	}
}
