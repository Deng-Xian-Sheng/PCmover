using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005BE RID: 1470
	internal class amp : Page
	{
		// Token: 0x06003A40 RID: 14912 RVA: 0x001F411C File Offset: 0x001F311C
		internal amp(PageDimensions A_0) : base(A_0)
		{
		}

		// Token: 0x06003A41 RID: 14913 RVA: 0x001F4128 File Offset: 0x001F3128
		internal void b(LayoutWriter A_0)
		{
			this.a = A_0.nb();
		}

		// Token: 0x06003A42 RID: 14914 RVA: 0x001F4138 File Offset: 0x001F3138
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

		// Token: 0x06003A43 RID: 14915 RVA: 0x001F418C File Offset: 0x001F318C
		private void a(PageWriter A_0)
		{
			bool flag = this.a != null || (base.ApplyDocumentTemplate && (A_0.Document.Template != null || A_0.Document.StampTemplate != null)) || (base.ApplySectionTemplate && A_0.DocumentWriter.CurrentSection != null && (A_0.DocumentWriter.CurrentSection.Template != null || A_0.DocumentWriter.CurrentSection.StampTemplate != null));
			if (flag || this.np() != null)
			{
				StructureElement structureElement;
				if (this.np() != null)
				{
					structureElement = this.np().Parent;
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
			if (flag || this.np() != null)
			{
				if (A_0.k().TagType == null)
				{
					A_0.k().a(new NamedTagType("Template", TagType.Section));
				}
				A_0.a(A_0.k().Parent);
			}
		}

		// Token: 0x06003A44 RID: 14916 RVA: 0x001F42E0 File Offset: 0x001F32E0
		internal bool c()
		{
			return this.b;
		}

		// Token: 0x06003A45 RID: 14917 RVA: 0x001F42F8 File Offset: 0x001F32F8
		internal void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06003A46 RID: 14918 RVA: 0x001F4304 File Offset: 0x001F3304
		internal bool d()
		{
			return this.c;
		}

		// Token: 0x06003A47 RID: 14919 RVA: 0x001F431C File Offset: 0x001F331C
		internal void b(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06003A48 RID: 14920 RVA: 0x001F4328 File Offset: 0x001F3328
		internal am5 e()
		{
			return this.a;
		}

		// Token: 0x06003A49 RID: 14921 RVA: 0x001F4340 File Offset: 0x001F3340
		internal virtual StructureElement np()
		{
			return null;
		}

		// Token: 0x04001B98 RID: 7064
		private new am5 a;

		// Token: 0x04001B99 RID: 7065
		private new bool b;

		// Token: 0x04001B9A RID: 7066
		private new bool c;
	}
}
