using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005CC RID: 1484
	internal class am3
	{
		// Token: 0x06003ACD RID: 15053 RVA: 0x001F928C File Offset: 0x001F828C
		internal am3(LayoutWriter A_0, SubReportHeader A_1)
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

		// Token: 0x06003ACE RID: 15054 RVA: 0x001F930C File Offset: 0x001F830C
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
					amm.a(A_1);
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

		// Token: 0x06003ACF RID: 15055 RVA: 0x001F9464 File Offset: 0x001F8464
		private void a(PageWriter A_0, TagType A_1)
		{
			A_0.a(new StructureElement(A_1)
			{
				Parent = A_0.k()
			});
		}

		// Token: 0x04001BC3 RID: 7107
		private aml a;

		// Token: 0x04001BC4 RID: 7108
		private amn b = null;
	}
}
