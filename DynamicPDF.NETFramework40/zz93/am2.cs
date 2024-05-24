using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005CB RID: 1483
	internal class am2
	{
		// Token: 0x06003ACA RID: 15050 RVA: 0x001F9088 File Offset: 0x001F8088
		internal am2(LayoutWriter A_0, SubReportFooter A_1)
		{
			this.a = new aml(x5.a(A_1.Height));
			if (A_1.a() != null)
			{
				A_1.a().a(this.a, A_0);
			}
			if (A_1.b() != null)
			{
				this.b = new amn(A_0, this.a, A_1.b());
			}
		}

		// Token: 0x06003ACB RID: 15051 RVA: 0x001F9108 File Offset: 0x001F8108
		internal void a(am1 A_0, PageWriter A_1)
		{
			if (this.b != null && this.b.a() > 0)
			{
				int a_ = -1;
				amm amm = this.b.a(A_0, A_1, ref a_);
				if (amm == null)
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
					amm.a(A_1);
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

		// Token: 0x06003ACC RID: 15052 RVA: 0x001F9260 File Offset: 0x001F8260
		private void a(PageWriter A_0, TagType A_1)
		{
			A_0.a(new StructureElement(A_1)
			{
				Parent = A_0.k()
			});
		}

		// Token: 0x04001BC1 RID: 7105
		private aml a;

		// Token: 0x04001BC2 RID: 7106
		private amn b = null;
	}
}
