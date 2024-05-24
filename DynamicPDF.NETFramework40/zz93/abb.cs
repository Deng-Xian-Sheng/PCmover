using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000419 RID: 1049
	internal class abb
	{
		// Token: 0x06002BBA RID: 11194 RVA: 0x00193B33 File Offset: 0x00192B33
		internal abb(MergeDocument A_0, PdfDocument A_1, MergeOptions A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06002BBB RID: 11195 RVA: 0x00193B5C File Offset: 0x00192B5C
		internal AppendedPage[] a(int A_0, int A_1)
		{
			aba aba = this.b.f().k8();
			if (this.b.g() != null)
			{
				this.a.RequireLicense(4);
			}
			if (this.c.DocumentInfo)
			{
				this.b.SetDocumentInfo(this.a);
			}
			if (this.c.DocumentProperties)
			{
				this.b.a(this.a);
			}
			if (this.c.OpenAction)
			{
				this.b.n().f(this.a);
			}
			else
			{
				this.a.a(false);
			}
			if (this.c.PageLabelsAndSections)
			{
				this.b.n().a(this.a, A_0, A_1);
			}
			if (this.c.XmpMetadata)
			{
				this.b.n().g(this.a);
			}
			if (this.c.DocumentJavaScript)
			{
				this.b.n().b(this.a);
			}
			if (this.c.EmbeddedFiles)
			{
				this.b.n().c(this.a);
			}
			if (this.c.OutputIntent)
			{
				this.b.b(this.a);
			}
			if (this.c.AllOtherData)
			{
				this.b.n().d(this.a);
			}
			if (this.c.OptionalContentInfo)
			{
				this.b.n().a(this.a);
			}
			if (this.c.LogicalStructure)
			{
				this.b.n().a(this.a, A_0, A_1);
				if (this.b.n().f())
				{
					if (this.a.j() != null && this.a.Tag == null)
					{
						this.a.Tag = new TagOptions();
					}
				}
			}
			AppendedPage[] array = new AppendedPage[A_1];
			if (this.c.FormFields && this.b.Form != null && this.b.Form.b() != null)
			{
				this.e = new acg();
			}
			int num = A_0 - 1;
			for (int i = 0; i < A_1; i++)
			{
				array[i] = new AppendedPage(this.b.Pages[num++], this);
				this.a.Pages.Add(array[i]);
			}
			if (this.c.FormFields && this.b.Form != null)
			{
				this.b.Form.a(this.a, this.e, this.c.FormsXfaData);
			}
			this.a();
			aba.lr();
			return array;
		}

		// Token: 0x06002BBC RID: 11196 RVA: 0x00193ECC File Offset: 0x00192ECC
		internal FormFieldList b()
		{
			if (this.d == null)
			{
				this.d = this.a.a(this.c.RootFormField);
				if (this.b.Form != null && this.b.Form.Fields != null && this.b.Form.Fields.Count > 0)
				{
					this.a.Form.a(this.b.Form);
				}
			}
			return this.d;
		}

		// Token: 0x06002BBD RID: 11197 RVA: 0x00193F70 File Offset: 0x00192F70
		private void a()
		{
			if (this.c.Outlines && this.b.j() != null)
			{
				if (this.c.RootOutline != null && this.b.j().a() != null)
				{
					this.c.RootOutline.ChildOutlines.a(this.b.j().a());
				}
				else if (this.b.j().a() != null)
				{
					this.a.Outlines.a(this.b.j().a());
				}
			}
		}

		// Token: 0x06002BBE RID: 11198 RVA: 0x00194030 File Offset: 0x00193030
		internal acg c()
		{
			return this.e;
		}

		// Token: 0x06002BBF RID: 11199 RVA: 0x00194048 File Offset: 0x00193048
		internal bool d()
		{
			return this.c.FormFields;
		}

		// Token: 0x06002BC0 RID: 11200 RVA: 0x00194068 File Offset: 0x00193068
		internal bool e()
		{
			return this.c.PageAnnotations;
		}

		// Token: 0x06002BC1 RID: 11201 RVA: 0x00194088 File Offset: 0x00193088
		internal bool f()
		{
			return this.c.AllOtherData;
		}

		// Token: 0x06002BC2 RID: 11202 RVA: 0x001940A8 File Offset: 0x001930A8
		internal MergeDocument g()
		{
			return this.a;
		}

		// Token: 0x06002BC3 RID: 11203 RVA: 0x001940C0 File Offset: 0x001930C0
		internal bool h()
		{
			return this.c.LogicalStructure;
		}

		// Token: 0x04001498 RID: 5272
		private MergeDocument a;

		// Token: 0x04001499 RID: 5273
		private PdfDocument b;

		// Token: 0x0400149A RID: 5274
		private MergeOptions c;

		// Token: 0x0400149B RID: 5275
		private FormFieldList d;

		// Token: 0x0400149C RID: 5276
		private acg e = null;
	}
}
