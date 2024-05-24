using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002A4 RID: 676
	internal class rs : Page
	{
		// Token: 0x06001E15 RID: 7701 RVA: 0x00130C90 File Offset: 0x0012FC90
		internal rs(PageDimensions A_0) : base(A_0)
		{
		}

		// Token: 0x06001E16 RID: 7702 RVA: 0x00130C9C File Offset: 0x0012FC9C
		internal void b(LayoutWriter A_0)
		{
			this.a = A_0.e7();
		}

		// Token: 0x06001E17 RID: 7703 RVA: 0x00130CAC File Offset: 0x0012FCAC
		internal override void e9(PageWriter A_0)
		{
			if (A_0.Document.Tag != null)
			{
				this.a(A_0);
			}
			else
			{
				base.e9(A_0);
				if (this.a != null)
				{
					this.a.b(this, A_0);
				}
			}
		}

		// Token: 0x06001E18 RID: 7704 RVA: 0x00130D00 File Offset: 0x0012FD00
		private void a(PageWriter A_0)
		{
			bool flag = this.a != null || (base.ApplyDocumentTemplate && (A_0.Document.Template != null || A_0.Document.StampTemplate != null)) || (base.ApplySectionTemplate && A_0.DocumentWriter.CurrentSection != null && (A_0.DocumentWriter.CurrentSection.Template != null || A_0.DocumentWriter.CurrentSection.StampTemplate != null));
			if (flag || this.fh() != null)
			{
				StructureElement structureElement;
				if (this.fh() != null)
				{
					structureElement = this.fh().Parent;
				}
				else
				{
					structureElement = new StructureElement();
				}
				structureElement.Parent = A_0.k();
				A_0.a(structureElement);
			}
			base.e9(A_0);
			if (this.a != null)
			{
				this.a.b(this, A_0);
			}
			if (flag || this.fh() != null)
			{
				if (A_0.k().TagType == null)
				{
					A_0.k().a(new NamedTagType("Template", TagType.Section));
				}
				A_0.a(A_0.k().Parent);
			}
		}

		// Token: 0x06001E19 RID: 7705 RVA: 0x00130E54 File Offset: 0x0012FE54
		internal bool c()
		{
			return this.b;
		}

		// Token: 0x06001E1A RID: 7706 RVA: 0x00130E6C File Offset: 0x0012FE6C
		internal void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001E1B RID: 7707 RVA: 0x00130E78 File Offset: 0x0012FE78
		internal bool d()
		{
			return this.c;
		}

		// Token: 0x06001E1C RID: 7708 RVA: 0x00130E90 File Offset: 0x0012FE90
		internal void b(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001E1D RID: 7709 RVA: 0x00130E9C File Offset: 0x0012FE9C
		internal xv e()
		{
			return this.a;
		}

		// Token: 0x06001E1E RID: 7710 RVA: 0x00130EB4 File Offset: 0x0012FEB4
		internal virtual StructureElement fh()
		{
			return null;
		}

		// Token: 0x04000D4E RID: 3406
		private new xv a;

		// Token: 0x04000D4F RID: 3407
		private new bool b;

		// Token: 0x04000D50 RID: 3408
		private new bool c;
	}
}
