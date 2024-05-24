using System;
using System.Collections.Generic;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.Merger.Forms;

namespace zz93
{
	// Token: 0x0200043E RID: 1086
	internal class acc
	{
		// Token: 0x06002CE5 RID: 11493 RVA: 0x00198C70 File Offset: 0x00197C70
		internal acc(abt A_0, abe A_1, PdfPage A_2)
		{
			this.a = new abp[A_1.a()];
			for (int i = 0; i < this.a.Length; i++)
			{
				if (A_1.a(i).hy() == ag9.j)
				{
					this.a[i] = A_0.b((ab6)A_1.a(i)).a(this, i, A_2);
					if (this.a[i] is acb)
					{
						this.c++;
					}
					else
					{
						this.b++;
					}
				}
				else if (A_1.a(i).hy() == ag9.g)
				{
					this.a[i] = new acb(this, i, (abj)A_1.a(i), A_2);
					this.c++;
				}
				if (this.a[i] is acb)
				{
					if (((acb)this.a[i]).d())
					{
						this.d.Add(A_0.b((ab6)A_1.a(i)).a((ab6)A_1.a(i), A_0.j().Form));
					}
					if (((acb)this.a[i]).e())
					{
						this.e++;
					}
				}
			}
		}

		// Token: 0x06002CE6 RID: 11494 RVA: 0x00198E28 File Offset: 0x00197E28
		internal abp[] a()
		{
			return this.a;
		}

		// Token: 0x06002CE7 RID: 11495 RVA: 0x00198E40 File Offset: 0x00197E40
		internal List<PdfFormField> b()
		{
			return this.d;
		}

		// Token: 0x06002CE8 RID: 11496 RVA: 0x00198E58 File Offset: 0x00197E58
		internal int c()
		{
			return this.e;
		}

		// Token: 0x06002CE9 RID: 11497 RVA: 0x00198E70 File Offset: 0x00197E70
		internal Resource[] a(abb A_0, bool A_1, bool A_2, acg A_3)
		{
			int num = 0;
			if (A_1)
			{
				num += this.b;
			}
			if (A_2)
			{
				num += this.c;
			}
			int num2 = 0;
			Resource[] array = new Resource[num];
			for (int i = 0; i < this.a.Length; i++)
			{
				Resource resource = this.a[i].a(A_0.g(), A_0.b(), A_1, A_2, A_0.g().Pages.Count + 1, A_0.h());
				if (A_3 != null && this.a[i].a() > 0)
				{
					A_3.a(this.a[i].a(), resource);
				}
				if (resource != null)
				{
					array[num2++] = resource;
				}
			}
			return array;
		}

		// Token: 0x06002CEA RID: 11498 RVA: 0x00198F58 File Offset: 0x00197F58
		internal void a(DocumentWriter A_0, FormFieldList A_1, bool A_2, bool A_3, int A_4, bool A_5)
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				Resource resource = this.a[i].a(A_0.Document, A_1, A_2, A_3, A_4, A_5);
				if (resource != null)
				{
					if (resource is FormField)
					{
						if (resource is SignatureField)
						{
							if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Retain || (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit && A_0.Document.d().Output == FormOutput.Retain))
							{
								A_0.WriteReference(resource);
							}
						}
						else if (A_0.Document.d().Output == FormOutput.Retain)
						{
							A_0.WriteReference(resource);
						}
					}
					else if (A_0.Document.d().Output == FormOutput.Flatten)
					{
						if (!resource.hn())
						{
							A_0.WriteReference(resource);
						}
					}
					else
					{
						A_0.WriteReference(resource);
					}
				}
			}
		}

		// Token: 0x06002CEB RID: 11499 RVA: 0x00199088 File Offset: 0x00198088
		internal bool a(PdfFormField A_0)
		{
			bool result;
			if (this.b == 0)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < this.a.Length; i++)
				{
					if (this.a[i] is abq)
					{
						if (A_0 == ((abq)this.a[i]).a())
						{
							return true;
						}
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06002CEC RID: 11500 RVA: 0x00199104 File Offset: 0x00198104
		internal bool a(bool A_0, bool A_1)
		{
			return (A_0 & this.b > 0) | (A_1 & this.c > 0);
		}

		// Token: 0x06002CED RID: 11501 RVA: 0x00199130 File Offset: 0x00198130
		internal void a(PageWriter A_0, FormFieldList A_1, bool A_2, bool A_3, int A_4, bool A_5)
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i] is abq)
				{
					if (((abq)this.a[i]).a() is PdfSignatureField)
					{
						if (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Flatten || (A_0.Document.d().Output == FormOutput.Flatten && A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit))
						{
							Resource resource = this.a[i].a(A_0.Document, A_1, A_2, A_3, A_4, A_5);
							if (resource is FormField)
							{
								((FormField)resource).ce(A_0);
							}
						}
					}
					else if (A_0.Document.d().Output == FormOutput.Flatten)
					{
						Resource resource = this.a[i].a(A_0.Document, A_1, A_2, A_3, A_4, A_5);
						if (resource is FormField)
						{
							((FormField)resource).hc(A_0, A_4);
						}
					}
				}
			}
			if (A_0.Document.d().Output == FormOutput.Flatten)
			{
				foreach (PdfFormField pdfFormField in this.b())
				{
					if (pdfFormField != null)
					{
						pdfFormField.hm(A_4).hc(A_0, A_4);
					}
				}
			}
		}

		// Token: 0x0400151F RID: 5407
		private abp[] a;

		// Token: 0x04001520 RID: 5408
		private int b = 0;

		// Token: 0x04001521 RID: 5409
		private int c = 0;

		// Token: 0x04001522 RID: 5410
		private List<PdfFormField> d = new List<PdfFormField>();

		// Token: 0x04001523 RID: 5411
		private int e = 0;
	}
}
