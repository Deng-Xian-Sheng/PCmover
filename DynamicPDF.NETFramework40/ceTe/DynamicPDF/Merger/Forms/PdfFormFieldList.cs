using System;
using System.Collections;
using zz93;

namespace ceTe.DynamicPDF.Merger.Forms
{
	// Token: 0x02000702 RID: 1794
	public class PdfFormFieldList
	{
		// Token: 0x06004633 RID: 17971 RVA: 0x0023E37C File Offset: 0x0023D37C
		internal PdfFormFieldList(PdfForm A_0, PdfFormField A_1, abe A_2)
		{
			int i = 0;
			while (i < A_2.a())
			{
				if (A_2.a(i).hy() == ag9.j)
				{
					ab6 ab = (ab6)A_2.a(i);
					if (ab.a() == null || !ab.a().f())
					{
						this.a(A_0, A_1, ab);
					}
				}
				IL_77:
				i++;
				continue;
				goto IL_77;
			}
		}

		// Token: 0x06004634 RID: 17972 RVA: 0x0023E414 File Offset: 0x0023D414
		private void a(PdfForm A_0, PdfFormField A_1, ab6 A_2)
		{
			if (A_2.a() != null)
			{
				PdfFormField pdfFormField = A_2.a().a(A_2, A_0, A_1);
				this.a.Add(pdfFormField);
				if (pdfFormField.p() != null)
				{
					this.b[pdfFormField.p().kf()] = pdfFormField;
				}
			}
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06004635 RID: 17973 RVA: 0x0023E474 File Offset: 0x0023D474
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x1700043E RID: 1086
		public PdfFormField this[int index]
		{
			get
			{
				return (PdfFormField)this.a[index];
			}
		}

		// Token: 0x1700043F RID: 1087
		public PdfFormField this[string name]
		{
			get
			{
				int num = name.IndexOf('.');
				PdfFormField result;
				if (num < 0)
				{
					result = (PdfFormField)this.b[name];
				}
				else
				{
					result = ((PdfFormField)this.b[name.Substring(0, num)]).ChildFields[name.Substring(num + 1)];
				}
				return result;
			}
		}

		// Token: 0x040026DD RID: 9949
		private ArrayList a = new ArrayList();

		// Token: 0x040026DE RID: 9950
		private Hashtable b = new Hashtable();
	}
}
