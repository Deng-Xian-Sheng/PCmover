using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger.Forms;

namespace zz93
{
	// Token: 0x02000428 RID: 1064
	internal class abq : c8, abp
	{
		// Token: 0x06002C3C RID: 11324 RVA: 0x00196206 File Offset: 0x00195206
		internal abq(PdfFormField A_0) : base(A_0.o())
		{
			this.a = A_0;
		}

		// Token: 0x06002C3D RID: 11325 RVA: 0x00196220 File Offset: 0x00195220
		internal override abp hx()
		{
			return this;
		}

		// Token: 0x06002C3E RID: 11326 RVA: 0x00196233 File Offset: 0x00195233
		internal override void bw(DocumentWriter A_0)
		{
			A_0.WriteReference(this.a.a(A_0.Document.Form.Fields, A_0.Document, 0));
		}

		// Token: 0x06002C3F RID: 11327 RVA: 0x00196260 File Offset: 0x00195260
		internal PdfFormField a()
		{
			return this.a;
		}

		// Token: 0x06002C40 RID: 11328 RVA: 0x00196278 File Offset: 0x00195278
		int abp.b()
		{
			return this.a.l();
		}

		// Token: 0x06002C41 RID: 11329 RVA: 0x00196298 File Offset: 0x00195298
		Resource abp.a(Document A_0, FormFieldList A_1, bool A_2, bool A_3, int A_4, bool A_5)
		{
			FormField formField = this.a.a(A_1, A_0, A_4);
			this.a.a(A_2);
			if (!A_5 || !formField.hb().ab())
			{
				formField.a(false);
			}
			Resource result;
			if (A_2)
			{
				result = formField;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x040014D4 RID: 5332
		private PdfFormField a;
	}
}
